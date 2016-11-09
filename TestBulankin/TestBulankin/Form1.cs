using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;


namespace TestBulankin
{
    public partial class Form1 : Form
    {        
        private List<int> idList = new List<int> { }; //Лист для сбора id при изменениях строк      
        public Form1()
        {            
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {                
            string query = "Select * from C#Table";
            ConnectMethod(query); // Метод для заполнения грида
            dataGridView1.Columns[0].Visible = false;                   //Скрываем стобик с id     
            for (int i = 1; i < dataGridView1.Columns.Count - 2; i++) //Заполненя комбобокса
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Добавления имени столбца в листбокс при выборе столбца в комбобоксе
        {
            bool check = false;
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                if(listBox1.Items[i]==comboBox1.SelectedItem)
                {
                    check = true;
                    break;
                }
            }
            if(check==false)
                listBox1.Items.Add(comboBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e) // Переводим имена стобцов с русского на англ и составляем из них запрос
        {
            if(listBox1.Items.Count>0)
            {                  
            string query = "Select ";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (i == listBox1.Items.Count - 1)
                    query += translate(listBox1.Items[i].ToString(), true) + ", Sum(Quantity) as Quantity, Sum(Summa) as Summa From C#Table Group by ";
                else
                    query += translate(listBox1.Items[i].ToString(), true) + " ,";
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (i == listBox1.Items.Count - 1)
                    query += translate(listBox1.Items[i].ToString(), true);
                else
                    query += translate(listBox1.Items[i].ToString(), true) + " ,";
            }
            ConnectMethod(query);
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            dataGridView1.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) // Возврат к первоначальному запросу и установка всех кнопок в первоначальный вид
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            Form1_Load(null, null);
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = true;
            idList.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = false;
        }

        void ConnectMethod(string query) //Метод для заполнения грида
        {            
            try
            {
                dataGridView1.Columns.Clear();
                //string _conect = ConfigurationManager.ConnectionStrings["MSSqlConStr"].ConnectionString;
                string _conect = string.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Test.mdf;",
                    Environment.CurrentDirectory);
                BindingSource bs1 = new BindingSource();
                DataTable DT = new DataTable();
                using (SqlConnection con = new SqlConnection(_conect))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.Fill(DT);
                        bs1.DataSource = DT;
                        dataGridView1.DataSource = bs1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неправильно настроен App.config или нет соединения с сервером. \n");
                Environment.Exit(0);
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].HeaderText = translate(dataGridView1.Columns[i].HeaderText, false);
        }

        string translate(string name, bool option) // Метод для переводов имен столбцов
        {
            if(option)
            switch (name)
            {
                case "Дата":
                    name="Dat";
                    break;
                case "Организация":
                    name = "Organisation";
                    break;
                case "Город":
                    name = "City";
                    break;
                case "Страна":
                    name = "Country";
                    break;
                case "Менеджер":
                    name = "Manager";
                    break;
                case "Количество":
                    name = "Quantity";
                    break;
                case "Сумма":
                    name = "Summa";
                    break;
            }
            else
            switch (name)
            {
                case "Dat":
                    name = "Дата";
                    break;
                case "Organisation":
                    name = "Организация";
                    break;
                case "City":
                    name = "Город";
                    break;
                case "Country":
                    name = "Страна";
                    break;
                case "Manager":
                    name = "Менеджер";
                    break;
                case "Quantity":
                    name = "Количество";
                    break;
                case "Summa":
                    name = "Сумма";
                    break;
            }
            return name;
        }

        private void button3_Click(object sender, EventArgs e) //Удаляем выбранную строку по id(который скрыт в гриде)
        {
            string adress = dataGridView1.CurrentCellAddress.Y.ToString();
            adress = dataGridView1.Rows[Convert.ToInt32(adress)].Cells[0].Value.ToString();
            string query = "Delete From C#Table Where id=" + adress;
            executeSQL(query);
            MessageBox.Show("Удалено.");
            Form1_Load(null, null);
        }

        void executeSQL(string query) //Выполнение команд для вставки, удаления, изменения
        {
            //string _conect = ConfigurationManager.ConnectionStrings["MSSqlConStr"].ConnectionString;
            string _conect = string.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Test.mdf;",
                    Environment.CurrentDirectory);
            using (SqlConnection con = new SqlConnection(_conect))
            {
                con.Open();
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();                    
                }
                con.Close();
            }            
        }

        private void button5_Click(object sender, EventArgs e) //Собираем измененные строки из грида и их id из idList и делаем запросы на изменения
        {

            string query = null;                
                for (int i = 0; i < idList.Count; i++)
                {
                    query = string.Format("Update C#Table SET Dat='{0}', Organisation=N'{1}', City=N'{2}', Country=N'{3}', Manager=N'{4}', Quantity={5}, Summa={6} Where Id={7}"
                        , ((DateTime)dataGridView1[1, idList[i]].Value).ToString("dd/MM/yyyy")
                        , dataGridView1[2, idList[i]].Value, dataGridView1[3, idList[i]].Value, dataGridView1[4, idList[i]].Value
                        , dataGridView1[5, idList[i]].Value, (Convert.ToDouble(dataGridView1[6, idList[i]].Value))
                        , (Convert.ToDouble(dataGridView1[7, idList[i]].Value)), dataGridView1[0, idList[i]].Value);
                    executeSQL(query);
                }
                MessageBox.Show("Изменено.");
                idList.Clear();
                button2_Click(null, null);                        
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) // Записуем id изменных строк
        {
            try
            {
                string adress = dataGridView1.CurrentCellAddress.Y.ToString();
                int check = 0;
                for (int i = 0; i < idList.Count; i++)
                {
                    if (idList[i] == Convert.ToInt32(adress))
                    {
                        check += 1;
                        break;
                    }
                }
                if (check == 0)
                {
                    idList.Add(Convert.ToInt32(adress));
                }
                if (idList.All(id => id != Convert.ToInt32(adress)))
                    idList.Add(Convert.ToInt32(adress));
            }
            catch(Exception a)
            {
                MessageBox.Show("Неправильно введены изменения в ячейки. \n\n\n" + a);            
            }
        }        

        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e) //Обработка ошибок в гриде
        {            
                MessageBox.Show("Неправильный формат ввода");            
        }

        private void button4_Click(object sender, EventArgs e) //Первый раз клацая включаем режим добавления новых строк, 2 раз добавляем новые строки
        {
            if (dataGridView1.AllowUserToAddRows == true)
            {
                
                List<string> queryList = new List<string> { }; //Лист со списком запросов на добавление строк                    
                    for (int i = idList[0]+1; i < dataGridView1.RowCount-1; i++)
                    {
                        try
                        {
                            string query = string.Format("Insert Into C#Table Values ('{0}', N'{1}', N'{2}', N'{3}', N'{4}', {5}, {6})"
                                , ((DateTime)dataGridView1[1, i].Value).ToString("dd/MM/yyyy")
                                , dataGridView1[2, i].Value, dataGridView1[3, i].Value, dataGridView1[4, i].Value
                                , dataGridView1[5, i].Value, (Convert.ToDouble(dataGridView1[6, i].Value))
                                , (Convert.ToDouble(dataGridView1[7, i].Value)));
                            queryList.Add(query);
                        }
                        catch(Exception a)
                        {
                            MessageBox.Show("Заполните пустые ячейки \n\n\n" + a);                            
                        }                        
                    }
                    for (int i = 0; i < queryList.Count; i++)
                    {
                        executeSQL(queryList[i]);
                        if (i==queryList.Count-1)
                        MessageBox.Show("Добавлено");
                    }
                    button2_Click(null, null);                
            }
            else
            {
                idList.Clear();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].ReadOnly = true;
                idList.Add(dataGridView1.RowCount - 1);
                dataGridView1.AllowUserToAddRows = true;                
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) //Скрываем лишние кнопки в режиме добавления
        {            
            if (dataGridView1.AllowUserToAddRows == true)
            {
                button1.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для суммирования выберите столбцы в списке и нажмите \"Выбрать итоги\".\n"+
                            "Для удаления выберите нужную строку и нажмите \"Удалить\".\n"+
                            "Для изменения измените нужные строки и нажмите \"Изменить\".\n"+
                            "Для добавления новых записей нажмите \"Добавить\", добавьте нужные строки"+
                            " и нажмите снова \"Добавить\".\n"+
                            "Для отмены или для того, что бы показать всю информацию, нажмите \"Сброс\".");  
        }
    }
}

