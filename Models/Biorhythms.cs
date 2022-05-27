using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiorhythmsCalc.Models
{
    public class Biorhythms
    {
        public DateTime Date { get; set; }
        public double Physical { get; set; }
        public double Emotional { get; set; }
        public double Intellectual { get; set; }
        public double Total { get; set; }
    }
}
