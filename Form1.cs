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
        BazaNotka _BazaNotka = BazaNotka.GetInstance();
        DataTable _tabela = new DataTable();

        public Form1()
        {
            InitializeComponent();
            DisplayTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime _date = DateTime.Now;
            string _sTitle = _date.ToString("g") + ' ' + textBox1.Text +
                ' ' + textBox2.Text;
            Notka _Notka = new Notka(_sTitle, _date.ToString("g"), 
                richTextBox1.Text, textBox1.Text, 
                textBox2.Text, textBox3.Text);
            _BazaNotka.Dodaj(_Notka);
            FillTable();
        }

        private void FillTable()
        {
            for (int i = 0; i <= _BazaNotka.SizeOfList() - 1; i++)
            {
                _tabela.Rows.Add(_BazaNotka.AtrZIndeks(i, 1), _BazaNotka.AtrZIndeks(i, 2), _BazaNotka.AtrZIndeks(i, 4),
                                 _BazaNotka.AtrZIndeks(i, 5), _BazaNotka.AtrZIndeks(i, 6));
            }
        }

        private void DisplayTable()
        {
            _tabela.Columns.Add("Tytuł", typeof(string));
            _tabela.Columns.Add("Data", typeof(string));
            _tabela.Columns.Add("Nr. sklepu", typeof(string));
            _tabela.Columns.Add("Nr. tel.", typeof(string));
            _tabela.Columns.Add("Imię, nazwisko", typeof(string));
            FillTable();
            dataGridView1.DataSource = _tabela;

            DataGridViewButtonColumn _ShowImg = new DataGridViewButtonColumn();
            _ShowImg.HeaderText = "Pokaż";
            _ShowImg.Name = "_ShowImg";
            dataGridView1.Columns.Add(_ShowImg);
            DataGridViewButtonColumn _Remove = new DataGridViewButtonColumn();
            _Remove.HeaderText = "Usuń";
            _Remove.Name = "_Remove";
            dataGridView1.Columns.Add(_Remove);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //Ustawia szerokość kolumn względem zawartości
        }
    }
}
