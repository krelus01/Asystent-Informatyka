using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsystentInformatyka
{
    class BazaNotka
    {
        [XmlElement("Notka")]
        List<Notka> ListaDziel; //Deklaracja listy zawierającej obiekty typu Dzielo
        Notka _Dzielo = new Notka();

        private static BazaNotka obiekt = null;

        private BazaNotka() { }


        public BazaNotka(int rozmiar) //Konstruktor listy
        {
            ListaDziel = new List<Notka>();
        }

        public static BazaNotka GetInstance()
        {

            if (obiekt == null) obiekt = new BazaNotka(5000);
            return obiekt;
        }

        public void Dodaj(Notka _Notka)
        {
            ListaDziel.Add(_Notka);
        }

        public void Usun(int index)
        {
            ListaDziel.RemoveAt(index);
        }

        public int SizeOfList()
        {
            return ListaDziel.Count();
        }
    }
}
