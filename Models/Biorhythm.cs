using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiorhythmsCalc.Models
{
    /// <summary>
    /// Биоритмы
    /// </summary>
    public class Biorhythm
    {
        /// <summary>
        /// Дата
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Физический показатель
        /// </summary>
        public double Physical { get; set; }
        /// <summary>
        /// Эмоциональный показатель
        /// </summary>
        public double Emotional { get; set; }
        /// <summary>
        /// Интеллектуальный показатель
        /// </summary>
        public double Intellectual { get; set; }
        /// <summary>
        /// Среднее значение все показателей
        /// </summary>
        public double Total { get; set; }
    }
}
