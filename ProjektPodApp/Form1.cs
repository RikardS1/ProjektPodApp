using BL;
using Pod.Models;
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
        private PoddarManager poddarManager = new PoddarManager();

        public Form1()
        {
            
            InitializeComponent();
            kategoriManager = new KategoriManager();
            FyllKategoriComboBox(); //metod som fyller comboboxen med kategorier - se metodkropp längre ner
            FiltreraKategorierComboBox();
            FyllDataGridViewMedPoddar();
            listBoxKategori();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ladda poddar i DataGridView när formuläret laddas
            FyllDataGridViewMedPoddar();

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
            string kategori = ManageCategoryComboBox.SelectedItem?.ToString();

            try
            {
                XmlDocument rssDoc = new XmlDocument();
                rssDoc.Load(rsslink);

                XmlNode nameNode = rssDoc.SelectSingleNode("//channel/title");

                if (nameNode == null)
                {
                    MessageBox.Show("Kunde inte hitta en podcast vid det namnet.", "Kunde inte hitta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string OfficialName = nameNode.InnerText;

                // Skapa en ny instans av Feed för att representera podcasten
                Feed nyPodd = new Feed(name, OfficialName, kategori);

                // Lägg till Feed-objektet i poddarManager
                poddarManager.LaggTillPoddar(nyPodd);

                // Lägg till i DataGridView
                int rowIndex = ManageDataGridView.Rows.Add();
                ManageDataGridView.Rows[rowIndex].Cells[0].Value = nyPodd.Name;
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = nyPodd.OfficialName;
                ManageDataGridView.Rows[rowIndex].Cells[2].Value = nyPodd.Category;
                MessageBox.Show("Podden har lagts till", "test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid bearbetning av RSS: {ex.Message}", "Kunde inte bearbeta RSS-strömmen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ManageEditButton_Click(object sender, EventArgs e)
        {
            if (ManageDataGridView.SelectedRows.Count > 0)
            {
                // Get the old podcast details from the selected row
                string oldName = ManageDataGridView.SelectedRows[0].Cells[0].Value?.ToString();
                string newName = ManageNameTextBox.Text.Trim();
                string newCategory = ManageCategoryComboBox.SelectedItem?.ToString();

                // Ensure both the new name and new category are provided
                if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newCategory))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to edit the selected podcast?",
                                                          "Editing a Podcast", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Find the existing podcast by its name
                        Feed oldPodcast = poddarManager.HamtaPoddar().FirstOrDefault(p => p.Name == oldName);

                        if (oldPodcast != null)
                        {
                            // Create a new Feed instance with updated details
                            Feed updatedPodcast = new Feed(newName, oldPodcast.OfficialName, newCategory);

                            // Update the podcast using the AndraPoddar method in poddarManager
                            poddarManager.AndraPoddar(oldPodcast, updatedPodcast);

                            // Reflect changes in the DataGridView
                            ManageDataGridView.SelectedRows[0].Cells[0].Value = updatedPodcast.Name;
                            ManageDataGridView.SelectedRows[0].Cells[2].Value = updatedPodcast.Category;

                            MessageBox.Show("The podcast has been successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The selected podcast could not be found in the data source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a new name and category for the podcast.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a podcast from the list to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string nyKategori = CategoryManageTextBox.Text.Trim(); //trim tar bort oönskade mellanslag 
            if (!string.IsNullOrEmpty(nyKategori))
            {
                Validering validering = new Validering();
                bool check = validering.ValidateText(nyKategori, 1, 20, false);
                if(check)
                {

                kategoriManager.LaggTillKategori(nyKategori); //anropa metod i BLL-lagret
                listBoxKategori(); //fyller listboxen igen för att se den nya kategorin
                CategoryManageTextBox.Clear(); //rensar textbox efter att vi lagt till kategorin
                }
                else
                {
                    MessageBox.Show("Ange en valid kategori.");
                }
            }

            else
            {
                MessageBox.Show("Ange en kategori.");
            }
        }
        private void FiltreraKategorierComboBox() //metod som filtrerar kategoirer. Använder samma metoder i BLL som FyllKategoriComboBox gör.
        {
            List<string> kategorier = kategoriManager.HamtaKategorier();
            ManageFilterComboBox.Items.Clear();
            ManageFilterComboBox.Items.AddRange(kategorier.ToArray());
        }
        private void listBoxKategori()
        {
            List<string> kategorier = kategoriManager.HamtaKategorier();
            CategoryCurrent.Items.Clear();
            CategoryCurrent.Items.AddRange(kategorier.ToArray());
        }
        private void CategoryEditButton_Click(object sender, EventArgs e)
        {
            string gammalKategori = CategoryCurrent.SelectedItem?.ToString(); 
            string nyKategori = CategoryManageTextBox.Text.Trim(); 

            if (!string.IsNullOrEmpty(gammalKategori) && !string.IsNullOrEmpty(nyKategori))
            {
                DialogResult result = MessageBox.Show("Är du säker på att du vill ändra på kategorin", "Du försöker ändra på en kategori", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //Kod för att göra ändringar till kategorin
                }
                kategoriManager.AndraKategori(gammalKategori, nyKategori); // Anropa metoden i BLL-lagret
                listBoxKategori(); // Uppdatera listboxen
                FyllKategoriComboBox(); 
                FiltreraKategorierComboBox();
                CategoryManageTextBox.Clear(); // Rensa textfältet
            }
            else
            {
                MessageBox.Show("Vänligen välj en kategori och ange ett nytt namn.");
            }
            

        }

        private void CategoryRemoveButton_Click(object sender, EventArgs e)
        {
            string gammalKategori = CategoryCurrent.SelectedItem?.ToString(); // Hämta den valda kategorin

            if (!string.IsNullOrEmpty(gammalKategori))
            {
                DialogResult result = MessageBox.Show($"Vill du ta bort kategorin (NAMN HÄR)", "Är du säker på att du vill ta bort en kategori?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    //Kod för att ta bort en kategori
                }
                kategoriManager.TaBortKategori(gammalKategori); // Anropa borttagningsmetoden i BLL-lagret
                listBoxKategori(); // Uppdatera listan efter borttagning
                FyllKategoriComboBox(); // Uppdatera ComboBox med kategorier
                FiltreraKategorierComboBox(); // Uppdatera filter-ComboBox
            }
            else
            {
                MessageBox.Show("Vänligen välj en kategori att ta bort.");
            }

            

        }

        private void ManageFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valdKategori = ManageFilterComboBox.SelectedItem?.ToString(); // Hämta vald kategori
            List<Feed> poddar = poddarManager.HamtaPoddar(); // Hämta alla poddar

            // Filtrera poddar baserat på vald kategori
            var filter = poddar.Where(pod => pod.Category.Equals(valdKategori))
                               .Select(pod => pod);

            // Fyll `DataGridView` med de filtrerade poddarna
            FyllDataGridViewMedPoddar(filter);
        }
        private void FyllDataGridViewMedPoddar()
        {
            List<Feed> poddar = poddarManager.HamtaPoddar(); // Hämta poddar från PoddarManager
            ManageDataGridView.Rows.Clear(); // Töm DataGridView

            foreach (var podd in poddar)
            {
                int rowIndex = ManageDataGridView.Rows.Add(); // Lägg till en ny rad
                ManageDataGridView.Rows[rowIndex].Cells[0].Value = podd.Name; 
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = podd.OfficialName; 
                ManageDataGridView.Rows[rowIndex].Cells[2].Value = podd.Category;
            }
        }
        private void FyllDataGridViewMedPoddar(IEnumerable<Feed> poddar)
        {
            ManageDataGridView.Rows.Clear(); // Töm DataGridView

            foreach (var podd in poddar)
            {
                int rowIndex = ManageDataGridView.Rows.Add(); // Lägg till en ny rad
                ManageDataGridView.Rows[rowIndex].Cells[0].Value = podd.Name;
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = podd.OfficialName;
                ManageDataGridView.Rows[rowIndex].Cells[2].Value = podd.Category;
            }
        }
        private void CategoryCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}