using BL;
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DU DÄR! Vill du återställa sidan?", "Du försöker återställa sidan.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            
        }

        private void ManageAddButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har klickat på lägg till-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string rsslink = ManageRSSTextBox.Text;
            string name = ManageNameTextBox.Text;
            //adfadfadfadfadf

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid bearbetning av RSS: {ex.Message}", "Kunde inte bearbeta RSS-strömmen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ManageEditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har klickat på ändra-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ManageRemoveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har klickat på ta bort-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Du har klickat på ändra-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CategoryRemoveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har klickat på ta bort-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void ManageRSSTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        //Gör alla textrutor tomma
        public void RestControls(Control reset)
        {
            foreach (Control content in reset.Controls)
            {
                if (reset is TextBox)
                {
                    ((TextBox)reset).Clear();
                }

            }
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