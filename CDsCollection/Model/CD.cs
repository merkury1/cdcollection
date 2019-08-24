using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CDsCollection.Model
{
    [Serializable()]
    [DataContract]
    public class CD
    {
        [XmlElement("TITLE")]
        [DataMember]
        public string Title { get; set; }

        [XmlElement("ARTIST")]
        [DataMember]
        public string Artist { get; set; }

        [XmlElement("COUNTRY")]
        [DataMember]
        public string Country { get; set; }

        [XmlElement("COMPANY")]
        [DataMember]
        public string Company { get; set; }

        [XmlElement("PRICE")]
        [DataMember]
        public double Price { get; set; }

        [XmlElement("YEAR")]
        [DataMember]
        public int Year { get; set; }
    }
}
