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
using System.Xml.Serialization;

namespace denemestaj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public KurBilgileri XmlBilgileriOlustur(string xmlIcerigi)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlIcerigi);

            KurBilgileri kurlar = new KurBilgileri();

            return kurlar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AltinkaynakWebService.DataServiceSoapClient client = new AltinkaynakWebService.DataServiceSoapClient();
                AltinkaynakWebService.AuthHeader authHeader = new AltinkaynakWebService.AuthHeader();
                authHeader.Username = "AltinkaynakWebServis";
                authHeader.Password = "AltinkaynakWebServis";

                // GetCurrency() metodunu çağırma
                var response = client.GetCurrency(authHeader);
                // Örneğin, XML verisini bir web servisten çekiyorsunuz
                string xmlData = response.ToString();

                // Serializer ile XML'i Kurlar nesnesine çeviriyoruz
                XmlSerializer serializer = new XmlSerializer(typeof(Kurlar));

                using (StringReader reader = new StringReader(xmlData))
                {
                    Kurlar kurlar = (Kurlar)serializer.Deserialize(reader);

                    // Kurlar nesnesini kullanarak formda işlem yapabilirsiniz
                    string listle=null;
                    foreach (var kur in kurlar.KurListesi)
                    {
                         listle+=($"Kod: {kur.Kod}, Alış: {kur.Alis}, Satış: {kur.Satis}, Güncellenme Zamanı: {kur.GuncellenmeZamani}\n");
                        // Örneğin bir datagridview'e ekleme yapabilirsiniz
                    }

                    MessageBox.Show(listle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
