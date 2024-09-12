using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IB222222
{
    public class PolozeniPredmeti
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PredmetId { get; set; }
        public int Ocjena { get; set; }
        public string DatumPolaganja { get; set; }
        public string Napomena { get; set; }
    }
}
