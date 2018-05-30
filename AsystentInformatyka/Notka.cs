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

        public Notka() { }

        public Notka (string _sTitle, string _sDate, string _sText)
        {
            sTitle = _sTitle;
            sDate = _sDate;
            sText = _sTitle;
        }
    }
}
