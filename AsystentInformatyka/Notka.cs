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
    class Notka
    {
        [XmlElement("sTitle")]
        private string sTitle;
        [XmlElement("sDate")]
        private string sDate;
        [XmlElement("sText")]
        private string sText;
        [XmlElement("ShopNumber")]
        private string sShopNumber;
        [XmlElement("sPhoneNumber")]
        private string sPhoneNumber;
        [XmlElement("sPersonData")]
        private string sPersonData;

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
            sText = _sTitle;
            sShopNumber = _sShopNumber;
            sPhoneNumber = _sPhoneNumber;
            sPersonData = _sPersonData;
        }
    }
}
