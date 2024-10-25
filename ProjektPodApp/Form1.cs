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
        private readonly BusinessLayer _BusinessLayer;
        private readonly string filePath = "data.xml"; //data.xml finns inte för tillfället

        public Form1()
        {
            InitializeComponent();
            _BusinessLayer = new BusinessLayer(filePath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ladda poddar i DataGridView när formuläret laddas
            LoadPodcastsToGrid();
        }

        private void LoadPodcastsToGrid()
        {
            List<PodLayer> poddar = _BusinessLayer.GetAllPodcasts();
            foreach (PodLayer podd in poddar)
            {
                int rowIndex = ManageDataGridView.Rows.Add();
                ManageDataGridView.Rows[rowIndex].Cells[0].Value = podd.ID;
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = podd.Title;
            }
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DU DÄR! Vill du återställa sidan?", "Du försöker återställa sidan.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        private void ManageAddButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Du har klickat på lägg till-knappen", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                PodLayer nyPodd = new PodLayer(name, officielltNamn);
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
    }
}