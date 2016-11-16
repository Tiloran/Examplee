namespace TestBulankin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableGrid = new System.Windows.Forms.DataGridView();
            this.ListBofColumns = new System.Windows.Forms.ListBox();
            this.ComboBofColumns = new System.Windows.Forms.ComboBox();
            this.SumButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.InterfaceLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            this.MainLayoutPanel.SuspendLayout();
            this.InterfaceLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableGrid
            // 
            this.TableGrid.AllowUserToAddRows = false;
            this.TableGrid.AllowUserToDeleteRows = false;
            this.TableGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableGrid.Location = new System.Drawing.Point(3, 3);
            this.TableGrid.MultiSelect = false;
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.Size = new System.Drawing.Size(574, 320);
            this.TableGrid.TabIndex = 0;
            this.TableGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellEndEdit);
            this.TableGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.TableGrid_DataError);
            this.TableGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.TableGrid_RowsAdded);
            // 
            // ListBofColumns
            // 
            this.ListBofColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBofColumns.FormattingEnabled = true;
            this.ListBofColumns.Location = new System.Drawing.Point(182, 23);
            this.ListBofColumns.Name = "ListBofColumns";
            this.ListBofColumns.Size = new System.Drawing.Size(101, 69);
            this.ListBofColumns.TabIndex = 1;
            // 
            // ComboBofColumns
            // 
            this.ComboBofColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBofColumns.FormattingEnabled = true;
            this.ComboBofColumns.Location = new System.Drawing.Point(289, 23);
            this.ComboBofColumns.Name = "ComboBofColumns";
            this.ComboBofColumns.Size = new System.Drawing.Size(101, 21);
            this.ComboBofColumns.TabIndex = 2;
            this.ComboBofColumns.SelectedIndexChanged += new System.EventHandler(this.ComboBofColumns_SelectedIndexChanged);
            // 
            // SumButton
            // 
            this.SumButton.Location = new System.Drawing.Point(432, 23);
            this.SumButton.Name = "SumButton";
            this.SumButton.Size = new System.Drawing.Size(92, 30);
            this.SumButton.TabIndex = 3;
            this.SumButton.Text = "Выбрать итоги";
            this.SumButton.UseVisualStyleBackColor = true;
            this.SumButton.Click += new System.EventHandler(this.SumButton_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(432, 102);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(92, 29);
            this.DefaultButton.TabIndex = 4;
            this.DefaultButton.Text = "Сброс";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список выбраных";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выберите столбец";
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.Controls.Add(this.InterfaceLayoutPanel, 0, 1);
            this.MainLayoutPanel.Controls.Add(this.TableGrid, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 2;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(580, 466);
            this.MainLayoutPanel.TabIndex = 7;
            // 
            // InterfaceLayoutPanel
            // 
            this.InterfaceLayoutPanel.ColumnCount = 4;
            this.InterfaceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InterfaceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InterfaceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InterfaceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.InterfaceLayoutPanel.Controls.Add(this.SumButton, 3, 1);
            this.InterfaceLayoutPanel.Controls.Add(this.DefaultButton, 3, 2);
            this.InterfaceLayoutPanel.Controls.Add(this.DeleteButton, 2, 2);
            this.InterfaceLayoutPanel.Controls.Add(this.ComboBofColumns, 2, 1);
            this.InterfaceLayoutPanel.Controls.Add(this.ListBofColumns, 1, 1);
            this.InterfaceLayoutPanel.Controls.Add(this.label2, 2, 0);
            this.InterfaceLayoutPanel.Controls.Add(this.label1, 1, 0);
            this.InterfaceLayoutPanel.Controls.Add(this.AddButton, 0, 2);
            this.InterfaceLayoutPanel.Controls.Add(this.ChangeButton, 1, 2);
            this.InterfaceLayoutPanel.Controls.Add(this.HelpButton, 0, 1);
            this.InterfaceLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterfaceLayoutPanel.Location = new System.Drawing.Point(3, 329);
            this.InterfaceLayoutPanel.Name = "InterfaceLayoutPanel";
            this.InterfaceLayoutPanel.RowCount = 3;
            this.InterfaceLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.InterfaceLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InterfaceLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.InterfaceLayoutPanel.Size = new System.Drawing.Size(574, 134);
            this.InterfaceLayoutPanel.TabIndex = 8;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DeleteButton.Location = new System.Drawing.Point(311, 102);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(92, 29);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddButton.Location = new System.Drawing.Point(25, 102);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(92, 29);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChangeButton.Location = new System.Drawing.Point(168, 102);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(92, 29);
            this.ChangeButton.TabIndex = 9;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HelpButton.Location = new System.Drawing.Point(25, 45);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(92, 29);
            this.HelpButton.TabIndex = 10;
            this.HelpButton.Text = "Подсказка";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 466);
            this.Controls.Add(this.MainLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(450, 505);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C#Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            this.MainLayoutPanel.ResumeLayout(false);
            this.InterfaceLayoutPanel.ResumeLayout(false);
            this.InterfaceLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TableGrid;
        private System.Windows.Forms.ListBox ListBofColumns;
        private System.Windows.Forms.ComboBox ComboBofColumns;
        private System.Windows.Forms.Button SumButton;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel InterfaceLayoutPanel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button HelpButton;
    }
}

