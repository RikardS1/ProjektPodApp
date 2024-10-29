using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BL
{
    public class Validering
    {
        //ska innehålla hantering av exceptions osv
        public Validering()
        {

        }
        //om true - låt användaren skapa ny kategori
        public bool ValidateNewCategory(string newCategory) 
        {
            try
            {
                XDocument document = XDocument.Load("Pod.xml"); //kolla så att patch och descendants stämmer vid namn
                string checkOK = newCategory;
                var categoryExists = document.Descendants("kategori").Any(x => (string)x.Attribute("name") == checkOK);
                if (categoryExists)
                {
                    return false;
                } 
                if (checkOK != "")
                {
                    return false;
                }
                return true;


            } catch (Exception ex) {
                Console.WriteLine("Nu har du allt kebabat till det! >:(");
                return true;
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
