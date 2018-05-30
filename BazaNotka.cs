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
    }
}
