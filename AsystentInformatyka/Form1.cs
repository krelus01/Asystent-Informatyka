using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsystentInformatyka
{
    public partial class Form1 : Form
    {
        BazaNotka _BazaNotka = new BazaNotka(5000);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime _date = DateTime.Now;
            string _sTitle = _date.ToLongDateString() + ' ' + textBox1.Text +
                ' ' + textBox2.Text;
            Notka _Notka = new Notka(_sTitle, _date.ToLongDateString(), 
                richTextBox1.Text, textBox1.Text, 
                textBox2.Text, textBox3.Text);
            _BazaNotka.Dodaj(_Notka);
        }
    }
}
