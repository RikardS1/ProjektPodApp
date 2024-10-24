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
            this.CategoryCurrent = new System.Windows.Forms.GroupBox();
            this.CategoryAddButton = new System.Windows.Forms.Button();
            this.CategoryRemoveButton = new System.Windows.Forms.Button();
            this.CategoryEditButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.NameColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ManageDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F);
            this.label1.Location = new System.Drawing.Point(507, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "KebabCast™";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hantera poddar:";
            // 
            // ManageFilterComboBox
            // 
            this.ManageFilterComboBox.FormattingEnabled = true;
            this.ManageFilterComboBox.Location = new System.Drawing.Point(18, 111);
            this.ManageFilterComboBox.Name = "ManageFilterComboBox";
            this.ManageFilterComboBox.Size = new System.Drawing.Size(73, 28);
            this.ManageFilterComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Skriv in RSS:";
            // 
            // ManageRSSTextBox
            // 
            this.ManageRSSTextBox.Location = new System.Drawing.Point(14, 191);
            this.ManageRSSTextBox.Name = "ManageRSSTextBox";
            this.ManageRSSTextBox.Size = new System.Drawing.Size(169, 26);
            this.ManageRSSTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Namn på podd:";
            // 
            // ManageNameTextBox
            // 
            this.ManageNameTextBox.Location = new System.Drawing.Point(14, 277);
            this.ManageNameTextBox.Name = "ManageNameTextBox";
            this.ManageNameTextBox.Size = new System.Drawing.Size(106, 26);
            this.ManageNameTextBox.TabIndex = 6;
            // 
            // ManageDataGridView
            // 
            this.ManageDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ManageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColum,
            this.TitleColumn1,
            this.Categori});
            this.ManageDataGridView.Location = new System.Drawing.Point(21, 338);
            this.ManageDataGridView.Name = "ManageDataGridView";
            this.ManageDataGridView.RowHeadersWidth = 51;
            this.ManageDataGridView.RowTemplate.Height = 24;
            this.ManageDataGridView.Size = new System.Drawing.Size(502, 475);
            this.ManageDataGridView.TabIndex = 7;
            this.ManageDataGridView.Tag = "";
            this.ManageDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManageDataGridView_CellContentClick);
            // 
            // ManageAddButton
            // 
            this.ManageAddButton.Location = new System.Drawing.Point(222, 191);
            this.ManageAddButton.Name = "ManageAddButton";
            this.ManageAddButton.Size = new System.Drawing.Size(84, 37);
            this.ManageAddButton.TabIndex = 8;
            this.ManageAddButton.Text = "Lägg ägg";
            this.ManageAddButton.UseVisualStyleBackColor = true;
            this.ManageAddButton.Click += new System.EventHandler(this.ManageAddButton_Click_1);
            // 
            // ManageCategoryComboBox
            // 
            this.ManageCategoryComboBox.FormattingEnabled = true;
            this.ManageCategoryComboBox.Location = new System.Drawing.Point(222, 111);
            this.ManageCategoryComboBox.Name = "ManageCategoryComboBox";
            this.ManageCategoryComboBox.Size = new System.Drawing.Size(115, 28);
            this.ManageCategoryComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kategori:";
            // 
            // ManageRemoveButton
            // 
            this.ManageRemoveButton.Location = new System.Drawing.Point(216, 263);
            this.ManageRemoveButton.Name = "ManageRemoveButton";
            this.ManageRemoveButton.Size = new System.Drawing.Size(78, 37);
            this.ManageRemoveButton.TabIndex = 11;
            this.ManageRemoveButton.Text = "Ta bort";
            this.ManageRemoveButton.UseVisualStyleBackColor = true;
            // 
            // ManageEditButton
            // 
            this.ManageEditButton.Location = new System.Drawing.Point(334, 231);
            this.ManageEditButton.Name = "ManageEditButton";
            this.ManageEditButton.Size = new System.Drawing.Size(78, 37);
            this.ManageEditButton.TabIndex = 12;
            this.ManageEditButton.Text = "Ändra";
            this.ManageEditButton.UseVisualStyleBackColor = true;
            // 
            // EpisodeListBox
            // 
            this.EpisodeListBox.FormattingEnabled = true;
            this.EpisodeListBox.ItemHeight = 20;
            this.EpisodeListBox.Location = new System.Drawing.Point(639, 322);
            this.EpisodeListBox.Name = "EpisodeListBox";
            this.EpisodeListBox.Size = new System.Drawing.Size(312, 224);
            this.EpisodeListBox.TabIndex = 13;
            // 
            // EpisodeDescTextBox
            // 
            this.EpisodeDescTextBox.Location = new System.Drawing.Point(637, 587);
            this.EpisodeDescTextBox.Name = "EpisodeDescTextBox";
            this.EpisodeDescTextBox.Size = new System.Drawing.Size(312, 206);
            this.EpisodeDescTextBox.TabIndex = 14;
            this.EpisodeDescTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(647, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Avsnitt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 567);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Poddbeskrivning:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1170, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Aktuell kategori";
            // 
            // CategoryCurrent
            // 
            this.CategoryCurrent.Location = new System.Drawing.Point(1173, 263);
            this.CategoryCurrent.Name = "CategoryCurrent";
            this.CategoryCurrent.Size = new System.Drawing.Size(324, 205);
            this.CategoryCurrent.TabIndex = 18;
            this.CategoryCurrent.TabStop = false;
            this.CategoryCurrent.Text = "groupBox1";
            // 
            // CategoryAddButton
            // 
            this.CategoryAddButton.Location = new System.Drawing.Point(1162, 494);
            this.CategoryAddButton.Name = "CategoryAddButton";
            this.CategoryAddButton.Size = new System.Drawing.Size(90, 37);
            this.CategoryAddButton.TabIndex = 19;
            this.CategoryAddButton.Text = "Lägg till";
            this.CategoryAddButton.UseVisualStyleBackColor = true;
            this.CategoryAddButton.Click += new System.EventHandler(this.CategoryAddButton_Click);
            // 
            // CategoryRemoveButton
            // 
            this.CategoryRemoveButton.Location = new System.Drawing.Point(1162, 582);
            this.CategoryRemoveButton.Name = "CategoryRemoveButton";
            this.CategoryRemoveButton.Size = new System.Drawing.Size(90, 37);
            this.CategoryRemoveButton.TabIndex = 20;
            this.CategoryRemoveButton.Text = "Ta bort";
            this.CategoryRemoveButton.UseVisualStyleBackColor = true;
            // 
            // CategoryEditButton
            // 
            this.CategoryEditButton.Location = new System.Drawing.Point(1162, 538);
            this.CategoryEditButton.Name = "CategoryEditButton";
            this.CategoryEditButton.Size = new System.Drawing.Size(90, 35);
            this.CategoryEditButton.TabIndex = 21;
            this.CategoryEditButton.Text = "Ändra";
            this.CategoryEditButton.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(1446, 814);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(96, 49);
            this.RefreshButton.TabIndex = 22;
            this.RefreshButton.Text = "Återställ";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // NameColum
            // 
            this.NameColum.HeaderText = "Namn";
            this.NameColum.MinimumWidth = 8;
            this.NameColum.Name = "NameColum";
            this.NameColum.Width = 150;
            // 
            // TitleColumn1
            // 
            this.TitleColumn1.HeaderText = "Titel";
            this.TitleColumn1.MinimumWidth = 8;
            this.TitleColumn1.Name = "TitleColumn1";
            this.TitleColumn1.Width = 150;
            // 
            // Categori
            // 
            this.Categori.HeaderText = "Kategori";
            this.Categori.MinimumWidth = 8;
            this.Categori.Name = "Categori";
            this.Categori.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 878);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.CategoryEditButton);
            this.Controls.Add(this.CategoryRemoveButton);
            this.Controls.Add(this.CategoryAddButton);
            this.Controls.Add(this.CategoryCurrent);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.GroupBox CategoryCurrent;
        private System.Windows.Forms.Button CategoryAddButton;
        private System.Windows.Forms.Button CategoryRemoveButton;
        private System.Windows.Forms.Button CategoryEditButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categori;
    }
}

