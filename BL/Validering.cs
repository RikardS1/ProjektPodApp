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

        public bool ValideraURL(string feedUrl)
        {
            try
            {
                //ladda RSS från URL
                XDocument rssDocument = XDocument.Load(feedUrl);

                XElement rss = rssDocument.Element("rss");
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
