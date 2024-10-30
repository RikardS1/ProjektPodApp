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
        private XmlDocument RssDoc;
        private XmlNodeList RssItems;
        private KategoriManager kategoriManager; //fält som refererar till BLL-lagret
        private PoddarManager poddarManager = new PoddarManager();
        private string xmlFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "Podd",
        "savedxml.xml"
    );

        public Form1()
        {
            
            InitializeComponent();
            kategoriManager = new KategoriManager();
            FyllKategoriComboBox(); //metod som fyller comboboxen med kategorier - se metodkropp längre ner
            FiltreraKategorierComboBox();
            FyllDataGridViewMedPoddar();
            listBoxKategori();
            EnsureXmlFileExists();

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

                        // Lägg till data till dataGridView
                        int rowIndex = ManageDataGridView.Rows.Add();
                        ManageDataGridView.Rows[rowIndex].Cells[0].Value = nyPodd.Name;
                        ManageDataGridView.Rows[rowIndex].Cells[1].Value = nyPodd.OfficialName;
                        ManageDataGridView.Rows[rowIndex].Cells[2].Value = nyPodd.Category;

                        // Anropa AddPodcastToXml (synkront för att undvika ytterligare await)
                        AddPodcastToXml(nyPodd);

                        MessageBox.Show("Podden har lagts till", "test", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //skriver till .xml
        private void AddPodcastToXml(Feed podcast)
        {
            XmlDocument doc = new XmlDocument();

            if (!File.Exists(xmlFilePath))
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlNode root = doc.CreateElement("Podcasts");
                doc.AppendChild(root);
                doc.InsertBefore(xmlDeclaration, root);
                doc.Save(xmlFilePath);
            }

            doc.Load(xmlFilePath);
            XmlNode rootNode = doc.DocumentElement;

            XmlElement podcastElement = doc.CreateElement("Podcast");

            XmlElement nameElement = doc.CreateElement("Name");
            nameElement.InnerText = podcast.Name;
            podcastElement.AppendChild(nameElement);

            XmlElement officialNameElement = doc.CreateElement("OfficialName");
            officialNameElement.InnerText = podcast.OfficialName;
            podcastElement.AppendChild(officialNameElement);

            XmlElement categoryElement = doc.CreateElement("Category");
            categoryElement.InnerText = podcast.Category;
            podcastElement.AppendChild(categoryElement);

            XmlElement episodesElement = doc.CreateElement("Episodes");

            foreach (var episode in podcast.Episodes)
            {
                XmlElement episodeElement = doc.CreateElement("Episode");

                XmlElement episodeTitle = doc.CreateElement("Title");
                episodeTitle.InnerText = episode.Title;
                episodeElement.AppendChild(episodeTitle);

                XmlElement episodeDescription = doc.CreateElement("Description");
                episodeDescription.InnerText = episode.Description;
                episodeElement.AppendChild(episodeDescription);

                XmlElement episodePubDate = doc.CreateElement("PublishedDate");
                episodePubDate.InnerText = episode.PublishedDate.ToString("yyyy-MM-dd");
                episodeElement.AppendChild(episodePubDate);

                episodesElement.AppendChild(episodeElement);
            }

            podcastElement.AppendChild(episodesElement);
            rootNode.AppendChild(podcastElement);


            doc.Save(xmlFilePath);
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
                        TaBortPodcastFrånXml(poddNamn);

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

        private void TaBortPodcastFrånXml(string poddNamn)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode rootNode = doc.DocumentElement;
            XmlNode poddNode = rootNode.SelectSingleNode($"Podcast[Name='{poddNamn}']");

            if (poddNode != null)
            {
                rootNode.RemoveChild(poddNode);
                doc.Save(xmlFilePath);
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
                if(!finnsInte)
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
            if (ManageDataGridView.SelectedRows.Count > 0)
            {
                //hämta name
                string podcastName = ManageDataGridView.SelectedRows[0].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(podcastName))
                {
                    //hämta episoderna för den valda podcasten
                    var episodes = poddarManager.HamtaEpisoder(podcastName);

                    //rensa EpisodeListBox innan den fylls med nya episoder
                    EpisodeListBox.Items.Clear();

                    //lägg till varje episod i EpisodeListBox
                    foreach (var episode in episodes)
                    {
                        EpisodeListBox.Items.Add(episode.Title);
                    }
                }
            }
        }
        private void EnsureXmlFileExists()
        {
            //kolla om dir finns
            string directoryPath = Path.GetDirectoryName(xmlFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(xmlFilePath))
            {
                using (XmlWriter writer = XmlWriter.Create(xmlFilePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Podcasts"); // Root element
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        private void ManageDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var manager = new PoddarManager();

                if (ManageDataGridView.CurrentCell == null) // Check if there is a selected cell
                    return;

                var i = ManageDataGridView.CurrentCell.RowIndex;
                var feeds = manager.HamtaPoddar();

                // Ensure index is within bounds
                if (i >= 0 && i < feeds.Count)
                {
                    var avsnitt = feeds[i].Episodes ?? new List<Episode>(); // Use an empty list if Episodes is null

                    EpisodeListBox.Items.Clear(); // Clear previous items before adding new ones

                    foreach (var episod in avsnitt)
                    {
                        EpisodeListBox.Items.Add($"{episod.Title}");
                    }
                }
                else
                {
                    MessageBox.Show("Vald Podd är out of range för index!", "Error: Out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("En NullReferenceException inträffade: " + ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EpisodeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EpisodeListBox.SelectedItem != null)
            {
                // Hämta den valda episodens titel
                string selectedEpisodeTitle = EpisodeListBox.SelectedItem.ToString();

                // Hämta podden som är markerad i DataGridView
                if (ManageDataGridView.SelectedRows.Count > 0)
                {
                    string selectedPodcastName = ManageDataGridView.SelectedRows[0].Cells[0].Value?.ToString();

                    // Hämta avsnittet med hjälp av poddarManager
                    var episodes = poddarManager.HamtaEpisoder(selectedPodcastName);
                    var selectedEpisode = episodes.FirstOrDefault(ep => ep.Title == selectedEpisodeTitle);

                    // Visa beskrivningen i EpisodeDescTextBox
                    if (selectedEpisode != null)
                    {
                        EpisodeDescTextBox.Text = selectedEpisode.Description;
                    }
                    else
                    {
                        EpisodeDescTextBox.Text = "Ingen beskrivning tillgänglig.";
                    }
                }
            }
        }

    }
}