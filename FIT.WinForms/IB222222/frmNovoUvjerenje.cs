using FIT.Data;
using FIT.Data.IB222222;
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
    public partial class frmNovoUvjerenje : Form
    {
        private Student kliknutiStudent;
        DLWMSDbContext db = new DLWMSDbContext();
        public frmNovoUvjerenje()
        {
            InitializeComponent();
        }

        public frmNovoUvjerenje(Student kliknutiStudent)
        {
            InitializeComponent();
            this.kliknutiStudent = kliknutiStudent;
        }

        private void pbUplatnica_DoubleClick(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbUplatnica.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (jeValidno())
            {
                var novoUvjerenje = new StudentiUvjerenja()
                {
                    StudentId = kliknutiStudent.Id,
                    Vrijeme = DateTime.Now.ToString(),
                    Vrsta = cmbVrsta.Text,
                    Svrha = txtSvrha.Text,
                    Uplatnica = Helpers.Ekstenzije.ToByteArray(pbUplatnica.Image),
                    Printano = 0
                };
                db.StudentiUvjerenja.Add(novoUvjerenje);
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private bool jeValidno()
        {
            return Helpers.Validator.ProvjeriUnos(pbUplatnica, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(txtSvrha, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(cmbVrsta, err, Kljucevi.ReqiredValue);
        }
    }
}
