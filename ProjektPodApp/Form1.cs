using BL;
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

namespace ProjektPodApp
{
    public partial class Form1 : Form
    {
        private XmlDocument RssDoc;
        private XmlNodeList RssItems;
        //private DataLayer<T> XmlData = new DataLayer<T>(); //Eftersom det inte finns någon koppling mellan GUI och DL så går inte detta
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
            string rsslink = ManageRSSTextBox.Text;
            string name = ManageNameTextBox.Text;

            try
            {
                XmlDocument rssDoc = new XmlDocument();

                XmlNode nameNode = rssDoc.SelectSingleNode("//channel/title");

                if (nameNode == null)
                {
                    MessageBox.Show("Kunde inte hitta en podcast vid det namnet.", "Kunde inte hitta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        private void ManageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}