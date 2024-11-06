namespace ProjektPodApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ManageFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ManageRSSTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ManageNameTextBox = new System.Windows.Forms.TextBox();
            this.ManageDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManageAddButton = new System.Windows.Forms.Button();
            this.ManageCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ManageRemoveButton = new System.Windows.Forms.Button();
            this.ManageEditButton = new System.Windows.Forms.Button();
            this.EpisodeListBox = new System.Windows.Forms.ListBox();
            this.EpisodeDescTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CategoryAddButton = new System.Windows.Forms.Button();
            this.CategoryRemoveButton = new System.Windows.Forms.Button();
            this.CategoryEditButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.CategoryManageTextBox = new System.Windows.Forms.TextBox();
            this.CategoryCurrent = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ManageDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F);
            this.label1.Location = new System.Drawing.Point(669, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "KebabCast™";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lägg till poddar:";
            // 
            // ManageFilterComboBox
            // 
            this.ManageFilterComboBox.FormattingEnabled = true;
            this.ManageFilterComboBox.Location = new System.Drawing.Point(388, 902);
            this.ManageFilterComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageFilterComboBox.Name = "ManageFilterComboBox";
            this.ManageFilterComboBox.Size = new System.Drawing.Size(151, 28);
            this.ManageFilterComboBox.TabIndex = 2;
            this.ManageFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.ManageFilterComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(260, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Skriv in RSS:";
            // 
            // ManageRSSTextBox
            // 
            this.ManageRSSTextBox.Location = new System.Drawing.Point(262, 82);
            this.ManageRSSTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageRSSTextBox.Name = "ManageRSSTextBox";
            this.ManageRSSTextBox.Size = new System.Drawing.Size(202, 26);
            this.ManageRSSTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(16, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Namn på podd:";
            // 
            // ManageNameTextBox
            // 
            this.ManageNameTextBox.Location = new System.Drawing.Point(20, 165);
            this.ManageNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageNameTextBox.Name = "ManageNameTextBox";
            this.ManageNameTextBox.Size = new System.Drawing.Size(196, 26);
            this.ManageNameTextBox.TabIndex = 6;
            // 
            // ManageDataGridView
            // 
            this.ManageDataGridView.AllowUserToAddRows = false;
            this.ManageDataGridView.AllowUserToDeleteRows = false;
            this.ManageDataGridView.AllowUserToResizeRows = false;
            this.ManageDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ManageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.TitleColumn,
            this.Category});
            this.ManageDataGridView.Location = new System.Drawing.Point(20, 226);
            this.ManageDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageDataGridView.Name = "ManageDataGridView";
            this.ManageDataGridView.ReadOnly = true;
            this.ManageDataGridView.RowHeadersWidth = 51;
            this.ManageDataGridView.RowTemplate.Height = 24;
            this.ManageDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ManageDataGridView.Size = new System.Drawing.Size(754, 662);
            this.ManageDataGridView.TabIndex = 7;
            this.ManageDataGridView.Tag = "";
            this.ManageDataGridView.SelectionChanged += new System.EventHandler(this.ManageDataGridView_SelectionChanged);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Namn";
            this.NameColumn.MinimumWidth = 8;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 150;
            // 
            // TitleColumn
            // 
            this.TitleColumn.HeaderText = "Titel";
            this.TitleColumn.MinimumWidth = 8;
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.ReadOnly = true;
            this.TitleColumn.Width = 150;
            // 
            // Category
            // 
            this.Category.HeaderText = "Kategori";
            this.Category.MinimumWidth = 8;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 150;
            // 
            // ManageAddButton
            // 
            this.ManageAddButton.Location = new System.Drawing.Point(417, 155);
            this.ManageAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageAddButton.Name = "ManageAddButton";
            this.ManageAddButton.Size = new System.Drawing.Size(96, 45);
            this.ManageAddButton.TabIndex = 8;
            this.ManageAddButton.Text = "Lägg ägg";
            this.ManageAddButton.UseVisualStyleBackColor = true;
            this.ManageAddButton.Click += new System.EventHandler(this.ManageAddButton_Click);
            // 
            // ManageCategoryComboBox
            // 
            this.ManageCategoryComboBox.FormattingEnabled = true;
            this.ManageCategoryComboBox.Location = new System.Drawing.Point(250, 165);
            this.ManageCategoryComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageCategoryComboBox.Name = "ManageCategoryComboBox";
            this.ManageCategoryComboBox.Size = new System.Drawing.Size(126, 28);
            this.ManageCategoryComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label5.Location = new System.Drawing.Point(246, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kategori:";
            // 
            // ManageRemoveButton
            // 
            this.ManageRemoveButton.Location = new System.Drawing.Point(578, 894);
            this.ManageRemoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageRemoveButton.Name = "ManageRemoveButton";
            this.ManageRemoveButton.Size = new System.Drawing.Size(96, 45);
            this.ManageRemoveButton.TabIndex = 11;
            this.ManageRemoveButton.Text = "Ta bort";
            this.ManageRemoveButton.UseVisualStyleBackColor = true;
            this.ManageRemoveButton.Click += new System.EventHandler(this.ManageRemoveButton_Click);
            // 
            // ManageEditButton
            // 
            this.ManageEditButton.Location = new System.Drawing.Point(680, 894);
            this.ManageEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageEditButton.Name = "ManageEditButton";
            this.ManageEditButton.Size = new System.Drawing.Size(96, 45);
            this.ManageEditButton.TabIndex = 12;
            this.ManageEditButton.Text = "Ändra";
            this.ManageEditButton.UseVisualStyleBackColor = true;
            this.ManageEditButton.Click += new System.EventHandler(this.ManageEditButton_Click);
            // 
            // EpisodeListBox
            // 
            this.EpisodeListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.EpisodeListBox.FormattingEnabled = true;
            this.EpisodeListBox.HorizontalScrollbar = true;
            this.EpisodeListBox.ItemHeight = 26;
            this.EpisodeListBox.Location = new System.Drawing.Point(812, 229);
            this.EpisodeListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EpisodeListBox.Name = "EpisodeListBox";
            this.EpisodeListBox.Size = new System.Drawing.Size(392, 290);
            this.EpisodeListBox.TabIndex = 13;
            this.EpisodeListBox.SelectedIndexChanged += new System.EventHandler(this.EpisodeListBox_SelectedIndexChanged);
            // 
            // EpisodeDescTextBox
            // 
            this.EpisodeDescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.EpisodeDescTextBox.Location = new System.Drawing.Point(812, 626);
            this.EpisodeDescTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EpisodeDescTextBox.Name = "EpisodeDescTextBox";
            this.EpisodeDescTextBox.Size = new System.Drawing.Size(392, 262);
            this.EpisodeDescTextBox.TabIndex = 14;
            this.EpisodeDescTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label6.Location = new System.Drawing.Point(808, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 26);
            this.label6.TabIndex = 15;
            this.label6.Text = "Avsnitt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(808, 605);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Poddbeskrivning:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label8.Location = new System.Drawing.Point(1257, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 26);
            this.label8.TabIndex = 17;
            this.label8.Text = "Hantera kategorier:";
            // 
            // CategoryAddButton
            // 
            this.CategoryAddButton.Location = new System.Drawing.Point(1466, 785);
            this.CategoryAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategoryAddButton.Name = "CategoryAddButton";
            this.CategoryAddButton.Size = new System.Drawing.Size(96, 45);
            this.CategoryAddButton.TabIndex = 19;
            this.CategoryAddButton.Text = "Lägg till";
            this.CategoryAddButton.UseVisualStyleBackColor = true;
            this.CategoryAddButton.Click += new System.EventHandler(this.CategoryAddButton_Click);
            // 
            // CategoryRemoveButton
            // 
            this.CategoryRemoveButton.Location = new System.Drawing.Point(1262, 785);
            this.CategoryRemoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategoryRemoveButton.Name = "CategoryRemoveButton";
            this.CategoryRemoveButton.Size = new System.Drawing.Size(96, 45);
            this.CategoryRemoveButton.TabIndex = 20;
            this.CategoryRemoveButton.Text = "Ta bort";
            this.CategoryRemoveButton.UseVisualStyleBackColor = true;
            this.CategoryRemoveButton.Click += new System.EventHandler(this.CategoryRemoveButton_Click);
            // 
            // CategoryEditButton
            // 
            this.CategoryEditButton.Location = new System.Drawing.Point(1364, 785);
            this.CategoryEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategoryEditButton.Name = "CategoryEditButton";
            this.CategoryEditButton.Size = new System.Drawing.Size(96, 45);
            this.CategoryEditButton.TabIndex = 21;
            this.CategoryEditButton.Text = "Ändra";
            this.CategoryEditButton.UseVisualStyleBackColor = true;
            this.CategoryEditButton.Click += new System.EventHandler(this.CategoryEditButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(1572, 925);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(96, 45);
            this.RefreshButton.TabIndex = 22;
            this.RefreshButton.Text = "Återställ";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label9.Location = new System.Drawing.Point(302, 902);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 26);
            this.label9.TabIndex = 23;
            this.label9.Text = "Filtrera:";
            // 
            // CategoryManageTextBox
            // 
            this.CategoryManageTextBox.Location = new System.Drawing.Point(1262, 751);
            this.CategoryManageTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.CategoryManageTextBox.Name = "CategoryManageTextBox";
            this.CategoryManageTextBox.Size = new System.Drawing.Size(180, 26);
            this.CategoryManageTextBox.TabIndex = 24;
            // 
            // CategoryCurrent
            // 
            this.CategoryCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.CategoryCurrent.FormattingEnabled = true;
            this.CategoryCurrent.ItemHeight = 30;
            this.CategoryCurrent.Location = new System.Drawing.Point(1262, 229);
            this.CategoryCurrent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.CategoryCurrent.Name = "CategoryCurrent";
            this.CategoryCurrent.Size = new System.Drawing.Size(380, 454);
            this.CategoryCurrent.TabIndex = 25;
            this.CategoryCurrent.SelectedIndexChanged += new System.EventHandler(this.CategoryCurrent_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1258, 725);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Namn på kategori:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1684, 985);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CategoryCurrent);
            this.Controls.Add(this.CategoryManageTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.CategoryEditButton);
            this.Controls.Add(this.CategoryRemoveButton);
            this.Controls.Add(this.CategoryAddButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EpisodeDescTextBox);
            this.Controls.Add(this.EpisodeListBox);
            this.Controls.Add(this.ManageEditButton);
            this.Controls.Add(this.ManageRemoveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ManageCategoryComboBox);
            this.Controls.Add(this.ManageAddButton);
            this.Controls.Add(this.ManageDataGridView);
            this.Controls.Add(this.ManageNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ManageRSSTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ManageFilterComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "KebabCast V1.0";
            ((System.ComponentModel.ISupportInitialize)(this.ManageDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ManageFilterComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ManageRSSTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ManageNameTextBox;
        private System.Windows.Forms.DataGridView ManageDataGridView;
        private System.Windows.Forms.Button ManageAddButton;
        private System.Windows.Forms.ComboBox ManageCategoryComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ManageRemoveButton;
        private System.Windows.Forms.Button ManageEditButton;
        private System.Windows.Forms.ListBox EpisodeListBox;
        private System.Windows.Forms.RichTextBox EpisodeDescTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CategoryAddButton;
        private System.Windows.Forms.Button CategoryRemoveButton;
        private System.Windows.Forms.Button CategoryEditButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CategoryManageTextBox;
        private System.Windows.Forms.ListBox CategoryCurrent;
        private System.Windows.Forms.Label label10;
    }
}

