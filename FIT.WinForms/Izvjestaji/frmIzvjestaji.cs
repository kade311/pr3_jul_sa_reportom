using FIT.Data;
using FIT.Data.IB222222;
using FIT.Infrastructure;
using Microsoft.Reporting.WinForms;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private Student kliknutiStudent;
        private StudentiUvjerenja kliknutoUvjerenje;
        DLWMSDbContext db = new DLWMSDbContext();

        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        public frmIzvjestaji(Student kliknutiStudent, StudentiUvjerenja kliknutoUvjerenje)
        {
            InitializeComponent();
            this.kliknutiStudent = kliknutiStudent;
            this.kliknutoUvjerenje = kliknutoUvjerenje;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();

            var status = kliknutiStudent.Aktivan == true ? "AKTIVAN" : "NEAKTIVAN";
            var brojPolozenih = db.PolozeniPredmeti.Count(x=>x.StudentId == kliknutiStudent.Id).ToString();
            var ocjena = db.PolozeniPredmeti.Where(x=>x.StudentId==kliknutiStudent.Id).ToList();
            var prosjek = ocjena.Count()==0 ? "5" : ocjena.Average(x=>x.Ocjena).ToString();

            var queryPredmeti = db.PolozeniPredmeti.Where(x=>x.StudentId==kliknutiStudent.Id).Join(db.Predmeti,pp=>pp.PredmetId,p=>p.Id, (pp,p)=> new {nazivPredmeta = p.Naziv, ocjenaPredmeta = pp.Ocjena }).ToList();
            var predmetOcjena = queryPredmeti.Count() == 0 ? "Nema polozenih predmeta" : string.Join(",", queryPredmeti.Select(x=>$"{x.nazivPredmeta}({x.ocjenaPredmeta})"));

            rpc.Add(new ReportParameter("vrstaUvjerenja", kliknutoUvjerenje.Vrsta));
            rpc.Add(new ReportParameter("imeStudenta", kliknutiStudent.Ime + " " + kliknutiStudent.Prezime));
            rpc.Add(new ReportParameter("indeksStudenta", kliknutiStudent.Indeks));
            rpc.Add(new ReportParameter("svrhaUvjerenja", kliknutoUvjerenje.Svrha));
            rpc.Add(new ReportParameter("statusStudenta", status));
            rpc.Add(new ReportParameter("brojPolozenih", brojPolozenih));
            rpc.Add(new ReportParameter("prosjecnaOcjena", prosjek));
            rpc.Add(new ReportParameter("listaPredmeta", predmetOcjena));

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.RefreshReport();
        }
    }
}
