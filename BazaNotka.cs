using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace AsystentInformatyka
{
    public class BazaNotka
    {
        [XmlElement("Notka")]
        List<Notka> ListaNotka; //Deklaracja listy zawierającej obiekty typu Dzielo
        Notka _Notka = new Notka();

        private static BazaNotka obiekt = null;

        private BazaNotka() { }


        public BazaNotka(int rozmiar) //Konstruktor listy
        {
            ListaNotka = new List<Notka>();
        }

        public static BazaNotka GetInstance()
        {

            if (obiekt == null) obiekt = new BazaNotka(5000);
            return obiekt;
        }

        public void Dodaj(Notka _Notka)
        {
            ListaNotka.Add(_Notka);
        }

        public void Usun(int index)
        {
            ListaNotka.RemoveAt(index);
        }

        public int SizeOfList()
        {
            return ListaNotka.Count();
        }

        /// <summary>
        /// Funkcja wyciągająca z podanego indeksu atrybut podany we fladze:
        /// 1-tytuł, 2-data, 3-treść, 4-nr. sklepu, 5-nr. telefonu, 6-dane osobowe
        /// </summary>
        /// <param name="_indeks"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public string AtrZIndeks(int _indeks, int flag)
        {
            if (flag < 0 && flag > 6)
                flag = 1;
            switch (flag)
            {
                case 1:
                    return ListaNotka[_indeks].sTitle;
                case 2:
                    return ListaNotka[_indeks].sDate;
                case 3:
                    return ListaNotka[_indeks].sText;
                case 4:
                    return ListaNotka[_indeks].sShopNumber;
                case 5:
                    return ListaNotka[_indeks].sPhoneNumber;
                case 6:
                    return ListaNotka[_indeks].sPersonData;
                default:
                    return ListaNotka[_indeks].sTitle;

            }
        }

        /// <summary>
        /// Funkcja edytująca istniejący na liście obiekt, atrybut wybierany z flagi:
        /// 1-tytuł, 2-data, 3-treść, 4-nr. sklepu, 5-nr. telefonu, 6-dane osobowe
        /// </summary>
        /// <param name="_indeks"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public void EditIndex(int _indeks, string NewWartosc, int flag)
        {
            if (flag < 0 && flag > 6)
                flag = 1;
            switch (flag)
            {
                case 1:
                    ListaNotka[_indeks].sTitle = NewWartosc;
                    break;
                case 2:
                    ListaNotka[_indeks].sDate = NewWartosc;
                    break;
                case 3:
                    ListaNotka[_indeks].sText = NewWartosc;
                    break;
                case 4:
                    ListaNotka[_indeks].sShopNumber = NewWartosc;
                    break;
                case 5:
                    ListaNotka[_indeks].sPhoneNumber = NewWartosc;
                    break;
                case 6:
                    ListaNotka[_indeks].sPersonData = NewWartosc;
                    break;
                default:
                    ListaNotka[_indeks].sTitle = NewWartosc;
                    break;
            }
        }

        public string ZapisDoXML()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Notka>));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, ListaNotka);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("Notki_user.xml");
                    stream.Close();
                }
                return "Zapis do pliku XML przeprowadzony poprawnie.";
            }
            catch (Exception ex)
            {
                return ex.Message + ", " + ex.InnerException;
            }
        }

        public string OdczytZXML()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("Notki_user.xml");
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(List<Notka>);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        ListaNotka = (List<Notka>)serializer.Deserialize(reader);
                        reader.Close();
                    }
                    read.Close();
                }
                return "Odczyt z pliku XML przeprowadzony poprawnie.";
            }
            catch (Exception ex)
            {
                return ex.Message + ", " + ex.InnerException;
            }
        }
    }
}
