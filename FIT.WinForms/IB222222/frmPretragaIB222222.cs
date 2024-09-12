using FIT.Data;
using FIT.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IB222222
{
    public partial class frmPretragaIB222222 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<Student> podaciStudent = new List<Student>();
        public frmPretragaIB222222()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;

            UcitajStudente();
        }

        private void UcitajStudente()
        {
            var spol = comboBox1.SelectedItem.ToString();
            var datumOd = dateTimePicker1.Value;
            var datumDo = dateTimePicker2.Value;
            //podaciStudent = db.Studenti.ToList();

            if (spol == "Svi")
            {
                podaciStudent = db.Studenti.Where(x => x.DatumRodjenja > datumOd && x.DatumRodjenja < datumDo).ToList();
            }
            else
            {
                podaciStudent = db.Studenti.Where(x => x.DatumRodjenja > datumOd && x.DatumRodjenja < datumDo && x.Spol == spol).ToList();
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("BrojIndeksa");
            dt.Columns.Add("ImePrezime");
            dt.Columns.Add("Prosjek");
            dt.Columns.Add("DatumRodjenja");
            dt.Columns.Add("Aktivan");

            for (int i = 0; i < podaciStudent.Count; i++)
            {
                var red = dt.NewRow();

                var podatakStudent = podaciStudent[i];

                var ocjena = db.PolozeniPredmeti.Where(x => x.StudentId == podatakStudent.Id).ToList();

                red["BrojIndeksa"] = podaciStudent[i].Indeks;
                red["ImePrezime"] = podatakStudent.Ime + " " + podatakStudent.Prezime;
                red["Prosjek"] = ocjena.Count() == 0 ? 5 : ocjena.Average(x => x.Ocjena);
                red["DatumRodjenja"] = podatakStudent.DatumRodjenja;
                red["Aktivan"] = podatakStudent.Aktivan;

                dt.Rows.Add(red);
            }
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(dataGridView1.Columns[e.ColumnIndex].Name == "Uvjerenja")
            {
                var kliknutiStudent = podaciStudent[e.RowIndex];
                var forma = new frmUvjerenja(kliknutiStudent);
                forma.Show();
            }
            else
            {
                var kliknutiStudent = podaciStudent[e.RowIndex];
                var forma = new frmStudentInfo(kliknutiStudent);
                forma.Show();
            }

        }
    }
}
