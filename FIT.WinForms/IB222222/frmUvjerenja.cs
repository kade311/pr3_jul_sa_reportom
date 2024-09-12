using FIT.Data;
using FIT.Data.IB222222;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;
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
    public partial class frmUvjerenja : Form
    {
        private Student kliknutiStudent;
        DLWMSDbContext db = new DLWMSDbContext();
        List<StudentiUvjerenja> podaciUvjerenja = new List<StudentiUvjerenja>();
        public frmUvjerenja()
        {
            InitializeComponent();
        }

        public frmUvjerenja(Student kliknutiStudent)
        {
            InitializeComponent();
            this.kliknutiStudent = kliknutiStudent;
            UcitajUvjerenja();
        }

        private void UcitajUvjerenja()
        {
            podaciUvjerenja = db.StudentiUvjerenja.Where(x => x.StudentId == kliknutiStudent.Id).ToList();
            dgvUvjerenja.AutoGenerateColumns = false;
            dgvUvjerenja.DataSource = podaciUvjerenja;
            this.Text = "Broj uvjerenja ->" + podaciUvjerenja.Count();
        }

        private void dgvUvjerenja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUvjerenja.Columns[e.ColumnIndex].Name == "Brisi")
            {
                var kliknutoUvjerenje = podaciUvjerenja[e.RowIndex];
                DialogResult odabir = MessageBox.Show("Jeste li sigurni da zelite obrisati uvjerenje?", "Upozerenje!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (odabir == DialogResult.Yes)
                {
                    db.StudentiUvjerenja.Remove(kliknutoUvjerenje);
                    db.SaveChanges();
                    UcitajUvjerenja();
                }
                else if (odabir == DialogResult.No)
                {
                    MessageBox.Show("Malo sam se salio");
                }

            }
            else if (dgvUvjerenja.Columns[e.ColumnIndex].Name == "Printaj")
            {

                var kliknutoUvjerenje = podaciUvjerenja[e.RowIndex];
                kliknutoUvjerenje.Printano = 1;
                db.SaveChanges();
                UcitajUvjerenja();
                var izvjestaj = new frmIzvjestaji(kliknutiStudent, kliknutoUvjerenje);
                izvjestaj.ShowDialog();
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {

            var forma = new frmNovoUvjerenje(kliknutiStudent);
            if (DialogResult.OK == forma.ShowDialog())
            {
                UcitajUvjerenja();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (jeValidno())
            {
                var vrsta = cmbVrsta.Text;
                var svrha = txtSvrha.Text;
                var brojZahtjeva = int.Parse(txtBrojZahtjeva.Text);

                Thread t = new Thread(() => GenerisiThread(vrsta, svrha, brojZahtjeva));
                t.Start();
            }
        }

        private void GenerisiThread(string vrsta, string svrha, int brojZahtjeva)
        {
            string Tekst = "";
            for (int i = 0;i<brojZahtjeva;i++)
            {
                var novoUvjerenje = new StudentiUvjerenja()
                {
                    StudentId = kliknutiStudent.Id,
                    Vrijeme = DateTime.Now.ToString(),
                    Vrsta = cmbVrsta.Text,
                    Svrha = txtSvrha.Text,
                    Uplatnica = podaciUvjerenja[0].Uplatnica,
                    Printano = 0
                };
                db.StudentiUvjerenja.Add(novoUvjerenje);
                db.SaveChanges();
                Tekst += $"{DateTime.Now.ToString("HH:mm:ss")} -> {vrsta} {kliknutiStudent.ToString()} u svrhu {svrha} {Environment.NewLine}";
            }
            Action action = () =>
            {
                txtInfo.Text = Tekst;
                UcitajUvjerenja();
            };
            BeginInvoke(action);
        }

        private bool jeValidno()
        {
            return Helpers.Validator.ProvjeriUnos(txtSvrha, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(cmbVrsta, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(txtBrojZahtjeva, err, Kljucevi.ReqiredValue);
        }
    }
}
