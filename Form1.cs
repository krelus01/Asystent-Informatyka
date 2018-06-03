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
        bool _editMode = false;
        int _selectedIndex = 0;

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show(_BazaNotka.OdczytZXML(), "Komunikat");
            DisplayTable();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime _date = DateTime.Now;
            string _sTitle = _date.ToString("g") + ' ' + textBox1.Text +
                ' ' + textBox2.Text;
            Notka _Notka = new Notka(_sTitle, _date.ToString("g"), 
                richTextBox1.Text, textBox1.Text, 
                textBox3.Text, textBox2.Text);
            _BazaNotka.Dodaj(_Notka);
            ZapisBazy();
            FillTable();
            ClearTextboxes();
        }

        private void ClearTextboxes()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            richTextBox1.Text = String.Empty;
        }

        private void FillTable()
        {
            _tabela.Clear();

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
            _ShowImg.Name = "_ShowNote";
            dataGridView1.Columns.Add(_ShowImg);
            DataGridViewButtonColumn _Remove = new DataGridViewButtonColumn();
            _Remove.HeaderText = "Usuń";
            _Remove.Name = "_Remove";
            dataGridView1.Columns.Add(_Remove);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn 
                && senderGrid.Columns[e.ColumnIndex].Name == "_Remove" 
                && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (MessageBox.Show("Jesteś pewny?", "Potwierdzenie Usunięcia",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _BazaNotka.Usun((int)dataGridView1.Rows[senderGrid.Rows[e.RowIndex].Index].Index);
                    FillTable();
                    ZapisBazy();
                }
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn 
                && senderGrid.Columns[e.ColumnIndex].Name == "_ShowNote" 
                && e.RowIndex >= 0)
            {
                _selectedIndex = (int)dataGridView1.Rows[senderGrid.Rows[e.RowIndex].Index].Index;
                richTextBox1.Text = _BazaNotka.AtrZIndeks(_selectedIndex, 3);
                textBox1.Text = _BazaNotka.AtrZIndeks(_selectedIndex, 4);
                textBox2.Text = _BazaNotka.AtrZIndeks(_selectedIndex, 6);
                textBox3.Text = _BazaNotka.AtrZIndeks(_selectedIndex, 5);
                button2.Enabled = true;
                _editMode = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (_editMode)
            {
                _BazaNotka.EditIndex(_selectedIndex, richTextBox1.Text, 3);
                _BazaNotka.EditIndex(_selectedIndex, textBox1.Text, 4);
                _BazaNotka.EditIndex(_selectedIndex, textBox2.Text, 6);
                _BazaNotka.EditIndex(_selectedIndex, textBox3.Text, 5);
            }
            _editMode = false;
            FillTable();
            ZapisBazy();
        }

        private void ZapisBazy ()
        {
            string msg = _BazaNotka.ZapisDoXML();
            if (msg != "Zapis do pliku XML przeprowadzony poprawnie.")
                MessageBox.Show(msg, "Komunikat");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            _editMode = false;
            _selectedIndex = 0;
            button2.Enabled = false;
        }
    }
}
