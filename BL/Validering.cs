using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BL
{
    public class Validering
    {
       
        public Validering()
        {

        }
        private const string catfolder = "Kategorier";
        private string catFile;

        // om true - låt användaren skapa ny kategori
        public bool ValidateNewCategory(string newCategory)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string kategorierPath = Path.Combine(desktopPath, catfolder);
            catFile = Path.Combine(kategorierPath, "kategorier.xml");

            try
            {
                // Kontrollera om filen existerar
                if (!File.Exists(catFile))
                {
                    Console.WriteLine($"Filen {catFile} kunde inte hittas.");
                    return false;
                }

                // Ladda XML-filen
                XDocument document = XDocument.Load(catFile);

                // Logga befintliga kategorier för felsökning
                Console.WriteLine("Befintliga kategorier:");
                foreach (var cat in document.Descendants("string"))
                {
                    Console.WriteLine($"Kategori: {cat.Value}");
                }

                // Kontrollera om kategorin redan existerar (med textinnehåll istället för attribut)
                bool categoryExists = document.Descendants("string")
                                              .Any(x => x.Value == newCategory);

                if (categoryExists)
                {
                    Console.WriteLine($"Kategorin '{newCategory}' existerar redan.");
                    return false; // Returnera false om kategorin redan existerar
                }

                if (string.IsNullOrWhiteSpace(newCategory))
                {
                    Console.WriteLine("Kategorinamnet får inte vara tomt.");
                    return false;
                }

                Console.WriteLine($"Kategorin '{newCategory}' är giltig och kan skapas.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nu har du allt kebabat till det! >:(");
                Console.WriteLine($"Felmeddelande: {ex.Message}");
                return false;
            }
        }



        //kollar om längden på kategorinamnet är OK
        public bool ValidateText(string input, int minLength, int maxLength, bool allowSpecialCharacters = true)
        {
            if (input.Length < minLength || input.Length > maxLength)
            {
                return false;
            }

            if (!allowSpecialCharacters && input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return false;
            }

            return true;
        }

        //validera RSS URL - returnar true om det är en valid RSS URL
        public bool ValidateRSS(string feedUrl)
        {
            try
            {
                //ladda RSS från URL
                XDocument rssDoc = XDocument.Load(feedUrl);

                XElement rss = rssDoc.Element("rss");
                if (rss != null)
                {
                    XElement channel = rss.Element("channel");
                    if (channel != null)
                    {
                        //varje element
                        XElement title = channel.Element("title");
                        XElement link = channel.Element("link");
                        XElement description = channel.Element("description");

                        //returnar true om alla element existerar
                        return title != null && link != null && description != null;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                //Exceptionhantering :D
                Console.WriteLine($"Error validating RSS feed: {ex.Message}");
                return false;
            }
        }
    }
}
