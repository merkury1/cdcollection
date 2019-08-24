using System;
using System.Xml.Serialization;

namespace CDsCollection.Model
{
    [Serializable()]
    [XmlRoot("CATALOG")]
    public class Catalog
    {
        [XmlElement("CD", typeof(CD))]
        public CD[] CDs { get; set; }
    }
}
