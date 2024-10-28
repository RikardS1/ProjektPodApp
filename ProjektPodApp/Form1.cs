﻿using BL;
using ProjektPodApp.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ProjektPodApp
{
    public partial class Form1 : Form
    {
        private XmlDocument RssDoc;
        private XmlNodeList RssItems;
        private KategoriManager kategoriManager; //fält som refererar till BLL-lagret

        private string filePath = "data.xml"; //data.xml finns inte för tillfället

        public Form1()
        {
            
            InitializeComponent();
            kategoriManager = new KategoriManager();
            FyllKategoriComboBox(); //metod som fyller comboboxen med kategorier - se metodkropp längre ner
            //listBoxRedigeraKategorierFyll();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ladda poddar i DataGridView när formuläret laddas
           
        }

        //Knapp för att tömma alla textrutor
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("DU DÄR! Vill du återställa sidan?", "Du försöker återställa sidan.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (result == DialogResult.Yes)
            {
                //Tömmer alla TextBoxes
                ManageRSSTextBox.Clear();
                ManageNameTextBox.Clear();
                CategoryManageTextBox.Clear();
                //RichTextBox
                EpisodeDescTextBox.Clear();

                //Tömmer alla ComboBoxes
                ManageCategoryComboBox.SelectedIndex = -1;
                ManageFilterComboBox.SelectedIndex = -1;

                //Tömmer alla ListBoxes
                EpisodeListBox.ClearSelected();
                CategoryCurrent.ClearSelected();

                //Tömmer alla DataGridViewBoxes
                ManageDataGridView.Rows.Clear();
            }
            
        }

        private void ManageAddButton_Click(object sender, EventArgs e)
        {
            string rsslink = ManageRSSTextBox.Text;
            string name = ManageNameTextBox.Text;

            try
            {
                XmlDocument rssDoc = new XmlDocument();
                rssDoc.Load(rsslink);

                XmlNode nameNode = rssDoc.SelectSingleNode("//channel/title");

                if (nameNode == null)
                {
                    MessageBox.Show("Kunde inte hitta en podcast vid det namnet.", "Kunde inte hitta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string officielltNamn = nameNode.InnerText;
                //Feed nyPodd = new Feed(name, officielltNamn);
                int rowIndex = ManageDataGridView.Rows.Add();

                ManageDataGridView.Rows[rowIndex].Cells[0].Value = name;
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = officielltNamn;
                //List<PodLayer> poddar = XmlSer(filePath);
                //poddar.Add(nyPodd);

                MessageBox.Show("Podden har lagts till", "test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid bearbetning av RSS: {ex.Message}", "Kunde inte bearbeta RSS-strömmen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ManageEditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Är du säker på att du vill ändra på podden?", "Du försöker ändra på en podd", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Kod för att göra ändringar till en podd
            }
        }

        private void ManageRemoveButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Du har klickat på ta bort-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            DialogResult result = MessageBox.Show("Är du säker på att du vill ta bort podden från listan?", "Du försöker radera en podd", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Tagits bort", "Podden har tagits bort!", MessageBoxButtons.OK);
                //MessageBox.Show($"Podden {PoddNamn} har tagitsbort", "Podden har tagits bort!", MessageBoxButtons.OK);
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Är du säker på att du inte vill ta bort podden?", "Är du verkligen säker på att den inte ska bort?", MessageBoxButtons.YesNo);

                while (result == DialogResult.Yes)
                {
                    MessageBox.Show("Är du säker på att du inte vill ta bort podden?", "Är du verkligen säker på att den inte ska bort?", MessageBoxButtons.YesNo);
                }
                while (result == DialogResult.No)
                {
                    MessageBox.Show("Är du säker på att du inte vill ta bort podden?", "Är du verkligen säker på att den inte ska bort?", MessageBoxButtons.YesNo);
                }
            }
        }

        private void ManageRSSTextBox_TextChanged(object sender, EventArgs e)
        {
            string rssLink = ManageRSSTextBox.Text;

            if (string.IsNullOrEmpty(rssLink))
            {
                MessageBox.Show("Vänligen skriv in en RSS-länk", "RSS-Länk saknas!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FyllKategoriComboBox() //metod som fyller cb. Hämtar data från DAL-lagret med hjälp av mellanhanden BLL
        {
            List<string> kategorier = kategoriManager.HamtaKategorier();
            ManageCategoryComboBox.Items.Clear();
            ManageCategoryComboBox.Items.AddRange(kategorier.ToArray());
        }
        private void CategoryAddButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har klickat på lägg till-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CategoryEditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Är du säker på att du vill ändra på kategorin", "Du försöker ändra på en kategori", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Kod för att göra ändringar till kategorin
            }

        }

        private void CategoryRemoveButton_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show($"Vill du ta bort kategorin {kategorNamn}", "Är du säker på att du vill ta bort en kategori?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            DialogResult result = MessageBox.Show($"Vill du ta bort kategorin (NAMN HÄR)", "Är du säker på att du vill ta bort en kategori?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (result == DialogResult.Yes)
            {
                //Kod för att ta bort en kategori
            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void ManageRSSTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ManageCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ManageFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> kategorier = kategoriManager.HamtaKategorier();
            ManageFilterComboBox.Items.Clear();
            ManageFilterComboBox.Items.AddRange(kategorier.ToArray());
        }
    }
}