using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Dynamic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;


namespace TestBulankin
{
    internal partial class MainForm : Form
    {
        private List<int> idList = new List<int> { }; //Лист для сбора id при изменениях строк
        private Dictionary<string, string> Translate = new Dictionary<string, string> { }; //Словарь для перевода имен        
        private DataContext db = new DataContext(string.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Test.mdf;",
                    Environment.CurrentDirectory));
        public MainForm()
        {            
            InitializeComponent();
            Translate.Add("Dat", "Дата");
            Translate.Add("Organisation", "Организация");
            Translate.Add("City", "Город");
            Translate.Add("Country", "Страна");
            Translate.Add("Manager", "Менеджер");
            Translate.Add("Quantity", "Количество");
            Translate.Add("Summa", "Сумма");
        }
        

        private void MainForm_Load(object sender, EventArgs e)
        {            
            var query = from data in db.GetTable<TableClass>() select data;
            TableGrid.DataSource = query;
            TableGrid.Columns[0].Visible = false;
            for (int i = 1; i < TableGrid.Columns.Count; i++) // Переименовуем имена столбцов на русский
                TableGrid.Columns[i].HeaderText = translate(TableGrid.Columns[i].HeaderText, false);
            for (int i = 1; i < TableGrid.Columns.Count - 2; i++) //Заполненя комбобокса
                ComboBofColumns.Items.Add(TableGrid.Columns[i].HeaderText);
        }

        private void ComboBofColumns_SelectedIndexChanged(object sender, EventArgs e) // Добавления имени столбца в листбокс при выборе столбца в комбобоксе
        {
            bool check = false;
            for(int i = 0; i < ListBofColumns.Items.Count; i++)
            {
                if(ListBofColumns.Items[i]==ComboBofColumns.SelectedItem)
                {
                    check = true;
                    break;
                }
            }
            if(check==false)
                ListBofColumns.Items.Add(ComboBofColumns.SelectedItem);
        }

        private void SumButton_Click(object sender, EventArgs e) // Переводим имена стобцов с русского на англ и составляем из них запрос
            {                        
            string groupingQuery = $"new({string.Join(", ", ListBofColumns.Items.Cast<string>().Select(s => translate(s, true)))})";
            string selectQuery = string.Join(", ", ListBofColumns.Items.Cast<string>().Select(s => $"Key.{translate(s, true)}"));            
            var query = db.GetTable<TableClass>().GroupBy(groupingQuery, "new(Quantity,Summa)")
                .Select($"new({selectQuery}, Sum(Quantity) as Quantity, Sum(Summa) as Summa)");
            TableGrid.DataSource = query;            
            DeleteButton.Visible = false;
            AddButton.Visible = false;
            ChangeButton.Visible = false;
            TableGrid.ReadOnly = true;            
        }

        private void DefaultButton_Click(object sender, EventArgs e)// Возврат к первоначальному запросу и установка всех кнопок в первоначальный вид
            {
            ListBofColumns.Items.Clear();
            ComboBofColumns.Items.Clear();            
            DeleteButton.Visible = true;
            AddButton.Visible = true;
            ChangeButton.Visible = true;
            SumButton.Visible = true;
            idList.Clear();
            TableGrid.AllowUserToAddRows = false;
            TableGrid.ReadOnly = false;
            TableGrid.Rows.Clear();
            int columnsCount = TableGrid.Columns.Count;
            for (int i = 0; i < columnsCount; i++)
                TableGrid.Columns.RemoveAt(0);
            MainForm_Load(null, null);
        }
        

        private string translate(string name, bool option) // Метод для переводов имен столбцов
        {
            if(!option)
            name=Translate.Where(f => f.Key == name).Select(f => f.Value).SingleOrDefault();
            else
            {
                name = Translate.Where(f => f.Value == name).Select(f => f.Key).SingleOrDefault();
            }            
            return name;
        }

        private void DeleteButton_Click(object sender, EventArgs e) //Удаляем выбранную строку по id(который скрыт в гриде)
        {
            int RowID = TableGrid.CurrentCellAddress.Y;
            int.TryParse(TableGrid.Rows[RowID].Cells[0].Value.ToString(), out RowID);
            string _conect = string.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Test.mdf;",
                    Environment.CurrentDirectory);
            DataContext db = new DataContext(_conect);
            var query = (from data in db.GetTable<TableClass>()
                         where data.Id == RowID
                         select data).SingleOrDefault();
            try
            {
                db.GetTable<TableClass>().DeleteOnSubmit(query);
                db.SubmitChanges();
                MessageBox.Show("Удалено.");
            }
            catch
            {
                MessageBox.Show("Ошибка :Не удалено.");
            }
            DefaultButton_Click(null, null);
        }        

        private void ChangeButton_Click(object sender, EventArgs e) //Собираем измененные строки из грида и их id из idList и делаем запросы на изменения
        {            
            List<TableClass> ChangeList = new List<TableClass> { };
            for (int i = 0; i < idList.Count; i++)
                {
                ChangeList.Add((from data in db.GetTable<TableClass>()
                                where data.Id == Convert.ToInt32(TableGrid[0, idList[i]].Value)
                                select data).SingleOrDefault());
                ChangeList[i].Dat = Convert.ToDateTime(TableGrid[1, idList[i]].Value);
                ChangeList[i].Organisation = (TableGrid[2, idList[i]].Value.ToString().Length <= 50) ? TableGrid[2, idList[i]].Value.ToString() : TableGrid[2, idList[i]].Value.ToString().Substring(0, 50);
                ChangeList[i].City = (TableGrid[3, idList[i]].Value.ToString().Length <= 50) ? TableGrid[3, idList[i]].Value.ToString() : TableGrid[3, idList[i]].Value.ToString().Substring(0, 50);
                ChangeList[i].Country = (TableGrid[4, idList[i]].Value.ToString().Length <= 50) ? TableGrid[4, idList[i]].Value.ToString() : TableGrid[4, idList[i]].Value.ToString().Substring(0, 50);
                ChangeList[i].Manager = (TableGrid[5, idList[i]].Value.ToString().Length <= 50) ? TableGrid[5, idList[i]].Value.ToString() : TableGrid[5, idList[i]].Value.ToString().Substring(0, 50);
                ChangeList[i].Quantity = Convert.ToDecimal(TableGrid[6, idList[i]].Value);
                ChangeList[i].Summa = Convert.ToDecimal(TableGrid[6, idList[i]].Value);
                }
            try
            {
                db.SubmitChanges();
                MessageBox.Show("Изменено.");
                idList.Clear();
                DefaultButton_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Ошибка: не изменено.");
            }
                
        }

        private void TableGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) // Записуем id изменных строк
        {
            try
            {
                int RowID = TableGrid.CurrentCellAddress.Y;                             
                if (idList.All(id => id != Convert.ToInt32(RowID)))
                    idList.Add(Convert.ToInt32(RowID));
            }
            catch(Exception a)
            {
                MessageBox.Show("Неправильно введены изменения в ячейки. \n\n\n" + a);            
            }
        }

        private void TableGrid_DataError(object sender, DataGridViewDataErrorEventArgs e) //Обработка ошибок в гриде
        {            
                MessageBox.Show("Неправильный формат ввода");            
        }

        private void AddButton_Click(object sender, EventArgs e) //Первый раз клацая включаем режим добавления новых строк, 2 раз добавляем новые строки
        {
            if (TableGrid.AllowUserToAddRows == true)
            {


                List<string> queryList = new List<string> { }; //Лист со списком запросов на добавление строк        

                string _conect = string.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Test.mdf;",
                    Environment.CurrentDirectory);
                DataContext db = new DataContext(_conect);                
                List<TableClass> myList = new List<TableClass> { };

                for (int i = idList[0] + 1; i < TableGrid.RowCount - 1; i++)
                {
                    try
                    {                        
                        myList.Add(new TableClass { Dat = Convert.ToDateTime(TableGrid[1, i].Value)
                            , Organisation = (TableGrid[2, i].Value.ToString().Length<=50) ? TableGrid[2, i].Value.ToString() : TableGrid[2, i].Value.ToString().Substring(0, 50)
                            , City = (TableGrid[3, i].Value.ToString().Length <= 50) ? TableGrid[3, i].Value.ToString() : TableGrid[3, i].Value.ToString().Substring(0, 50)
                            , Country = (TableGrid[4, i].Value.ToString().Length <= 50) ? TableGrid[4, i].Value.ToString() : TableGrid[4, i].Value.ToString().Substring(0, 50)
                            , Manager = (TableGrid[5, i].Value.ToString().Length <= 50) ? TableGrid[5, i].Value.ToString() : TableGrid[5, i].Value.ToString().Substring(0, 50)
                            , Quantity = Convert.ToDecimal(TableGrid[6, i].Value)
                            , Summa = Convert.ToDecimal(TableGrid[7, i].Value) });
                    }
                    catch 
                    {
                        MessageBox.Show("Заполните пустые ячейки");
                    }
                }                
                if (myList.Count > 0)
                {
                    try
                    {
                        db.GetTable<TableClass>().InsertAllOnSubmit(myList);
                        db.SubmitChanges();
                        MessageBox.Show("Добавлено");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка: не добавлено");
                    }
                    DefaultButton_Click(null, null);
                }                              
            }            
            else
            {
                idList.Clear();
                for (int i = 0; i < TableGrid.RowCount; i++)
                    TableGrid.Rows[i].ReadOnly = true;
                idList.Add(TableGrid.RowCount - 1);
                TableGrid.AllowUserToAddRows = true;                
            }
        }

        private void TableGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) //Скрываем лишние кнопки в режиме добавления
        {            
            if (TableGrid.AllowUserToAddRows == true)
            {
                SumButton.Visible = false;
                DeleteButton.Visible = false;
                ChangeButton.Visible = false;
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для суммирования выберите столбцы в списке и нажмите \"Выбрать итоги\".\n" +
                            "Для удаления выберите нужную строку и нажмите \"Удалить\".\n" +
                            "Для изменения измените нужные строки и нажмите \"Изменить\".\n" +
                            "Для добавления новых записей нажмите \"Добавить\", добавьте нужные строки" +
                            " и нажмите снова \"Добавить\".\n" +
                            "Для отмены или для того, что бы показать всю информацию, нажмите \"Сброс\".");

            //using (SqlConnection con = new SqlConnection(_conect))
            //{
            //    con.Open();
            //    string sql = "INSERT INTO C#Table VALUES(@param1 ,@param2 ,@param3 ,@param4 ,@param5 ,@param6 ,@param7), (@param8 ,@param9 ,@param10 ,@param11 ,@param12 ,@param13 ,@param14)";
            //    SqlCommand cmd = new SqlCommand(sql, con);
            //    cmd.Parameters.Add("@param1", SqlDbType.Date).Value = "01-02-2015";
            //    cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = "фывфыв";
            //    cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = "фывфыфывыфвв";
            //    cmd.Parameters.Add("@param4", SqlDbType.NVarChar, 50).Value = "фыпа";
            //    cmd.Parameters.Add("@param5", SqlDbType.NVarChar, 50).Value = "фпавп";
            //    cmd.Parameters.Add("@param6", SqlDbType.Decimal, 13).Value = 23525.533;
            //    cmd.Parameters["@param6"].Precision = 13;
            //    cmd.Parameters["@param6"].Scale = 2;
            //    cmd.Parameters.Add("@param7", SqlDbType.Decimal, 13).Value = 23535.35235;
            //    cmd.Parameters["@param7"].Precision = 13;
            //    cmd.Parameters["@param7"].Scale = 2;
            //    cmd.Prepare();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
        }        
    }
}

