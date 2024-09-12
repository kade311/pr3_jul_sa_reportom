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
    public partial class frmStudentInfo : Form
    {
        private Student kliknutiStudent;
        DLWMSDbContext db = new DLWMSDbContext();

        public frmStudentInfo()
        {
            InitializeComponent();
        }

        public frmStudentInfo(Student kliknutiStudent)
        {
            InitializeComponent();
            this.kliknutiStudent = kliknutiStudent;
            pbSlika.Image = Helpers.Ekstenzije.ToImage(kliknutiStudent.Slika);
            lblIme.Text = kliknutiStudent.Ime;

            List<PolozeniPredmeti> polozeniPredmeti = db.PolozeniPredmeti.Where(x => x.StudentId == kliknutiStudent.Id).ToList();
            
            lblProsjek.Text = polozeniPredmeti.Count() == 0 ? "5" : polozeniPredmeti.Average(x => x.Ocjena).ToString();
        }
    }
}
