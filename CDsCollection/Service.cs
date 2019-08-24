using CDsCollection.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CDsCollection
{
    public class Service : IService
    {
        List<CD> CDs;

        public Service()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
            var stream = XmlReader.Create("https://www.w3schools.com/xml/cd_catalog.xml");
            var cdCatalog = (Catalog)serializer.Deserialize(stream);

            if (cdCatalog != null)
                CDs = cdCatalog.CDs.ToList();
        }

        public List<CD> GetCDCollection()
        {
            return CDs;
        }
    }
}
