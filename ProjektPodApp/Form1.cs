using BL;
using Pod.Models;
using ProjektPodApp.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net;

namespace ProjektPodApp
{
    public partial class Form1 : Form
    {
        private List<Feed> filteredPodcasts = new List<Feed>();
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
            Validering.EnsureXmlFileExists();

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


                // Rensar alla TextBox-objekt
                ManageRSSTextBox.Clear();
                ManageNameTextBox.Clear();
                CategoryManageTextBox.Clear();

                // Rensar DataGridView-objekt
                ManageDataGridView.Rows.Clear(); 

                // Rensar RichTextBox
                EpisodeDescTextBox.Clear();

                // Rensar ComboBox-objekt
                ManageCategoryComboBox.SelectedIndex = -1;
                ManageFilterComboBox.SelectedIndex = -1;
                // Rensar alla ListBox-objekt
                EpisodeListBox.Items.Clear();

            }
        }
        private async void ManageAddButton_Click(object sender, EventArgs e)
        {
            string rsslink = ManageRSSTextBox.Text;
            string name = ManageNameTextBox.Text;
            string kategori = ManageCategoryComboBox.SelectedItem?.ToString();

            Validering urlValidering = new Validering();
            bool checkURL = urlValidering.ValidateRSS(rsslink);

            if (checkURL)
            {
                try
                {
                    // Använd WebClient för att hämta RSS-strömmen asynkront
                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = Encoding.UTF8;
                        string response = await client.DownloadStringTaskAsync(rsslink); // Endast ett await här

                        XmlDocument rssDoc = new XmlDocument();
                        rssDoc.LoadXml(response); // Laddar in strömmen från responsen

                        XmlNode nameNode = rssDoc.SelectSingleNode("//channel/title");

                        if (nameNode == null)
                        {
                            MessageBox.Show("Kunde inte hitta en podcast vid det namnet.", "Kunde inte hitta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string OfficialName = nameNode.InnerText;
                        var episodes = ParseEpisodes(rssDoc);

                        Feed nyPodd = new Feed(name, OfficialName, kategori, episodes);
                        poddarManager.LaggTillPoddar(nyPodd);

                        //lägg till data till dataGridView
                        int rowIndex = ManageDataGridView.Rows.Add();
                        ManageDataGridView.Rows[rowIndex].Cells[0].Value = nyPodd.Name;
                        ManageDataGridView.Rows[rowIndex].Cells[1].Value = nyPodd.OfficialName;
                        ManageDataGridView.Rows[rowIndex].Cells[2].Value = nyPodd.Category;

                        //anropa AddPodcastToXml (synkront för att undvika ytterligare await)
                        poddarManager.LaggTillPoddar2(nyPodd);

                        //tömmer RSS, namn och kategori-rutorna så att man kan lägga till ny podd direkt
                        ManageRSSTextBox.Clear();
                        ManageNameTextBox.Clear();
                        ManageCategoryComboBox.SelectedIndex = -1;

                        MessageBox.Show("Podden har lagts till", "Allt gick som det skulle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fel vid bearbetning av RSS: {ex.Message}", "Kunde inte bearbeta RSS-strömmen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Felaktig RSS-länk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //parsa episoder methoden
        private List<Episode> ParseEpisodes(XmlDocument rssDoc)
        {
            List<Episode> episodes = new List<Episode>();

            XmlNodeList items = rssDoc.SelectNodes("//channel/item");
            foreach (XmlNode item in items)
            {
                string title = item.SelectSingleNode("title")?.InnerText ?? "Untitled";

                //description och ta bort <tags> med Regex B)
                string description = item.SelectSingleNode("description")?.InnerText ?? "No description";
                description = Regex.Replace(description, "<.*?>", string.Empty);

                DateTime pubDate = DateTime.TryParse(item.SelectSingleNode("pubDate")?.InnerText, out DateTime parsedDate)
                    ? parsedDate : DateTime.MinValue;

                episodes.Add(new Episode(title, description, pubDate));
            }

            return episodes;
        }

        private void ManageEditButton_Click(object sender, EventArgs e)
        {
            if (ManageDataGridView.SelectedRows.Count > 0)
            {
                
                string oldName = ManageDataGridView.SelectedRows[0].Cells[0].Value?.ToString(); // origo selected
                string newName = ManageNameTextBox.Text.Trim();                                 // sigma
                string newCategory = ManageCategoryComboBox.SelectedItem?.ToString();

               
                if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newCategory))
                {
                    DialogResult result = MessageBox.Show("Är du säkert att ändra namn och kategori",
                                                          "Editing a Podcast", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        //hitta existerande podcast med namn
                        Feed oldPodcast = poddarManager.HamtaPoddar().FirstOrDefault(p => p.Name == oldName);

                        if (oldPodcast != null)
                            
                        {
                            Feed updatedPodcast = new Feed(newName, oldPodcast.OfficialName, newCategory, oldPodcast.Episodes);

                            poddarManager.AndraPoddar(oldPodcast, updatedPodcast);

                            ManageDataGridView.SelectedRows[0].Cells[0].Value = updatedPodcast.Name;
                            ManageDataGridView.SelectedRows[0].Cells[2].Value = updatedPodcast.Category;

                            MessageBox.Show("Uppdatering lyckades.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Finns inget data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("vänligen välj ett nytt namn.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Välj en pod som du vill ändra.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ManageRemoveButton_Click(object sender, EventArgs e)
        {
            if (ManageDataGridView.SelectedRows.Count > 0)
            {
                string poddNamn = ManageDataGridView.SelectedRows[0].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(poddNamn))
                {
                    DialogResult result = MessageBox.Show($"Är du säker på att du vill ta bort podden '{poddNamn}'?", "Bekräfta borttagning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        //1. ta bort podden från poddarManager
                        Feed podcastAttTaBort = poddarManager.HamtaPoddar().FirstOrDefault(p => p.Name == poddNamn);
                        if (podcastAttTaBort != null)
                        {
                            poddarManager.TaBortPodd(podcastAttTaBort);
                        }

                        //2. ta bort podden från .xml-filen
                        poddarManager.TaBortPoddar2(poddNamn);

                        //3. ta bort podden från DataGridView
                        ManageDataGridView.Rows.RemoveAt(ManageDataGridView.SelectedRows[0].Index);

                        MessageBox.Show($"Podcast '{poddNamn}' har tagits bort.", "Borttagning lyckades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen välj en podd att ta bort.", "Ingen podd vald", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Validering valideraFinnsRedan = new Validering();
                bool finnsInte = valideraFinnsRedan.ValidateNewCategory(nyKategori);
                if(finnsInte)
                {
                    Validering valideraTecken = new Validering();
                    bool check = valideraTecken.ValidateText(nyKategori, 1, 20, false);
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
                    MessageBox.Show("Kategori med samma namn finns redan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult result = MessageBox.Show($"Vill du ta bort kategorin '{gammalKategori}'?", "Är du säker på att du vill ta bort en kategori?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                kategoriManager.TaBortKategori(gammalKategori); // Anropa borttagningsmetoden i BLL-lagret
                listBoxKategori(); // Uppdatera listan efter borttagning
                FyllKategoriComboBox(); // Uppdatera ComboBox med kategorier
                FiltreraKategorierComboBox(); // Uppdatera filter-ComboBox
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en kategori att ta bort.");
            }

            

        }

        private void ManageFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valdKategori = ManageFilterComboBox.SelectedItem?.ToString();
            List<Feed> poddar = poddarManager.HamtaPoddar(); // Hämtar alla poddar

            // Filtrerar våra poddar baserat på vald kategori
            filteredPodcasts = poddar.Where(pod => pod.Category.Equals(valdKategori)).ToList();

            // Fyller datagridview med filtrerade poddar
            FyllDataGridViewMedPoddar(filteredPodcasts);
        }

        private void FyllDataGridViewMedPoddar()
        {
            List<Feed> poddar = poddarManager.HamtaPoddar();
            ManageDataGridView.Rows.Clear();

            foreach (var podd in poddar)
            {
                int rowIndex = ManageDataGridView.Rows.Add();
                ManageDataGridView.Rows[rowIndex].Cells[0].Value = podd.Name; 
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = podd.OfficialName; 
                ManageDataGridView.Rows[rowIndex].Cells[2].Value = podd.Category;
            }
        }
        private void FyllDataGridViewMedPoddar(IEnumerable<Feed> poddar)
        {
            ManageDataGridView.Rows.Clear();

            foreach (var podd in poddar)
            {
                int rowIndex = ManageDataGridView.Rows.Add();
                ManageDataGridView.Rows[rowIndex].Cells[0].Value = podd.Name;
                ManageDataGridView.Rows[rowIndex].Cells[1].Value = podd.OfficialName;
                ManageDataGridView.Rows[rowIndex].Cells[2].Value = podd.Category;
            }
        }
        private void CategoryCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ManageDataGridView.SelectedRows.Count > 0)
            {
                //hämta name
                string podcastName = ManageDataGridView.SelectedRows[0].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(podcastName))
                {
                    //hämta episoderna för den valda podcasten
                    var episodes = poddarManager.HamtaEpisoder(podcastName);

                    //lägg till varje episod i EpisodeListBox
                    foreach (var episode in episodes)
                    {
                        EpisodeListBox.Items.Add(episode.Title);
                    }
                }
            }
        }

        private void ManageDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
            if (ManageDataGridView.CurrentCell == null)
                return;

            int i = ManageDataGridView.CurrentCell.RowIndex;

           
            List<Feed> poddar = ManageFilterComboBox.SelectedItem == null ? poddarManager.HamtaPoddar() : filteredPodcasts;

            if (i >= 0 && i < poddar.Count)
            {
                var selectedPodcast = poddar[i]; 
                var avsnitt = selectedPodcast.Episodes ?? new List<Episode>();
                EpisodeListBox.Items.Clear();

                foreach (var episod in avsnitt)
                {
                    EpisodeListBox.Items.Add($"{episod.Title}");
                }
            }
        }





        private void EpisodeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EpisodeListBox.SelectedItem != null)
            {
                string selectedEpisodeTitle = EpisodeListBox.SelectedItem.ToString();

                if (ManageDataGridView.CurrentCell != null)
                {
                    int rowIndex = ManageDataGridView.CurrentCell.RowIndex;

                    List<Feed> poddar = ManageFilterComboBox.SelectedItem == null ? poddarManager.HamtaPoddar() : filteredPodcasts;

                    if (rowIndex >= 0 && rowIndex < poddar.Count)
                    {
                        var selectedPodcast = poddar[rowIndex];
                        var selectedEpisode = selectedPodcast.Episodes.FirstOrDefault(ep => ep.Title == selectedEpisodeTitle);

                        EpisodeDescTextBox.Text = selectedEpisode?.Description ?? "Ingen beskrivning tillgänglig";
                    }
                    else
                    {
                        EpisodeDescTextBox.Text = "Ingen beskrivning tillgänglig";
                    }
                }
            }
        }
    }
}