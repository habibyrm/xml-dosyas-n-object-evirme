using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace denemestaj
{
    [XmlRoot("Kurlar")]
    public class Kurlar
    {
        [XmlElement("Kur")]
        public List<KurBilgileri> KurListesi { get; set; }
    }

    public class KurBilgileri
    {
        [XmlElement("Kod")]
        public string Kod { get; set; }

        [XmlElement("Aciklama")]
        public string Aciklama { get; set; }

        [XmlElement("Alis")]
        public decimal Alis { get; set; }

        [XmlElement("Satis")]
        public decimal Satis { get; set; }

        [XmlElement("GuncellenmeZamani")]
        public string GuncellenmeZamani { get; set; }
    }

}
