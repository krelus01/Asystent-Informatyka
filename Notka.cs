using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace AsystentInformatyka
{
    [XmlRoot("Notka")]
    public class Notka
    {
        [XmlElement("sTitle")]
        public string sTitle;
        [XmlElement("sDate")]
        public string sDate;
        [XmlElement("sText")]
        public string sText;
        [XmlElement("ShopNumber")]
        public string sShopNumber;
        [XmlElement("sPhoneNumber")]
        public string sPhoneNumber;
        [XmlElement("sPersonData")]
        public string sPersonData;

        public Notka() { }


        /// <summary>
        /// Konstruktor klasy, do podania: tytuł notki, datę, treść, nr. sklepu, nr. tel i dane osoby
        /// </summary>
        /// <param name="_indeks"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public Notka (string _sTitle, string _sDate, string _sText, string _sShopNumber, string _sPhoneNumber, string _sPersonData)
        {
            sTitle = _sTitle;
            sDate = _sDate;
            sText = _sText;
            sShopNumber = _sShopNumber;
            sPhoneNumber = _sPhoneNumber;
            sPersonData = _sPersonData;
        }
    }
}
