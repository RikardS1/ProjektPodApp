using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Pod;


namespace BL
{
    public class BusinessLayer

    {
        private readonly Serializer<PodLayer> _xmlRepository;
        private readonly string _filePath;

        public BusinessLayer(string filePath)
        {
            _xmlRepository = new Serializer<PodLayer>(); // Serializer för PodLayer-klassen
            _filePath = filePath;
        }

        // Hämta alla poddar från XML-filen
        public List<PodLayer> GetAllPodcasts()
        {
            return _xmlRepository.XmlDeSer(_filePath); // Deserialisera (läs) från XML
        }

        // Lägg till en ny podd och spara den till XML
        public void AddPodcast(PodLayer newPodd)
        {
            var poddar = _xmlRepository.XmlDeSer(_filePath); // Läs befintliga poddar från XML
            poddar.Add(newPodd); // Lägg till ny podd
            _xmlRepository.XmlSer(poddar, _filePath); // Spara uppdaterad lista till XML
        }
    }
}


