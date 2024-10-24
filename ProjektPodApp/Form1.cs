using BL;
using Pod;
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
        private DataLayer <PodLayer> XmlData = new DataLayer<PodLayer>(); //Eftersom det inte finns någon koppling mellan GUI och DL så går inte detta
        private string filePath = "data.xml"; //data.xml finns inte för tillfället

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DU DÄR! Vill du återställa sidan?", "Du försöker återställa sidan.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        private void ManageAddButton_Click(object sender, EventArgs e)
        {

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

        private void ManageAddButton_Click_1(object sender, EventArgs e)
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
                PodLayer nyPodd = new poddar(name, officielltNamn);
                int rowIndex = ManageDataGridView.Rows.Add();


                ManageDataGridView.Rows[rowIndex].Cells[0].Value = name;
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = officielltNamn;

                List<PodLayer> poddar = XmlData.ReadXML(filePath);


                poddar.Add(nyPodd);
                System.Diagnostics.Debug.WriteLine("Podd tillagd");

                XmlData.WriteXML(poddar, filePath);
     

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid bearbetning av RSS: {ex.Message}", "Kunde inte bearbeta RSS-strömmen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ManageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoryAddButton_Click(object sender, EventArgs e)
        {

        }
    }
}