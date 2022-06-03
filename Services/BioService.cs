using BiorhythmsCalc.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiorhythmsCalc.Services
{
    /// <summary>
    /// Расчеты биоритмов
    /// </summary>
    public static class BioService
    {
        const int phys = 23;
        const int emot = 28;
        const int intel = 33;

        /// <summary>
        /// Получение списка биоритмов для одного человека
        /// </summary>
        /// <param name="arbitrarys"></param>
        /// <param name="dateCountDown"></param>
        /// <param name="birthDate"></param>
        /// <param name="biorhythms"></param>
        /// <returns>List<Biorhythm> biorhythms</returns>
        public static ObservableCollection<Biorhythm> GetListBiorhythm(int arbitrarys, DateTime dateCountDown, DateTime birthDate, ObservableCollection<Biorhythm> biorhythms)
        {
            biorhythms.Clear();

            for (int i = 0; i < arbitrarys; i++)
            {
                var bior = new Biorhythm()
                {
                    Date = dateCountDown.AddDays(i).ToShortDateString(),
                    Emotional = Math.Round(GetEmotional(dateCountDown, birthDate, i), 2),
                    Intellectual = Math.Round(GetIntellectual(dateCountDown, birthDate, i), 2),
                    Physical = Math.Round(GetPhysical(dateCountDown, birthDate, i), 2),
                };

                bior.Total = Math.Round((bior.Emotional + bior.Intellectual + bior.Physical) / 3, 2);

                biorhythms.Add(bior);
            }
            return biorhythms;
        }

        /// <summary>
        /// Получение списка биоритмов для двух человек
        /// </summary>
        /// <param name="arbitrarys"></param>
        /// <param name="dateCountDown"></param>
        /// <param name="birthDate"></param>
        /// <param name="birtDate1"></param>
        /// <param name="biorhythms"></param>
        /// <returns></returns>
        public static ObservableCollection<Biorhythm> GetListBiorhythm(int arbitrarys, DateTime dateCountDown, DateTime birthDate, DateTime birthDate1, ObservableCollection<Biorhythm> biorhythms)
        {
            biorhythms.Clear();

            for (int i = 0; i < arbitrarys; i++)
            {
                var bior = new Biorhythm()
                {
                    Date = dateCountDown.AddDays(i).ToShortDateString(),
                    Emotional = Math.Round(GetEmotional(dateCountDown, birthDate, i) + GetEmotional(dateCountDown, birthDate1, i), 2),
                    Intellectual = Math.Round(GetIntellectual(dateCountDown, birthDate, i) + GetIntellectual(dateCountDown, birthDate1, i), 2),
                    Physical = Math.Round(GetPhysical(dateCountDown, birthDate, i) + GetPhysical(dateCountDown, birthDate1, i), 2),
                };

                bior.Total = Math.Round((bior.Emotional + bior.Intellectual + bior.Physical) / 3, 2);

                biorhythms.Add(bior);
            }
            return biorhythms;
        }

        /// <summary>
        /// Получение эмоциональных данных
        /// </summary>
        /// <param name="dateCountDown"></param>
        /// <param name="birthDate"></param>
        /// <param name="i"></param>
        /// <returns>double</returns>
        public static double GetEmotional(DateTime dateCountDown, DateTime birthDate, int i)
        {
            return (Math.Sin(2 * Math.PI * ((dateCountDown - birthDate).Days + i) / emot)) * 100;
        }

        /// <summary>
        /// Получение интеллектуальных данных
        /// </summary>
        /// <param name="dateCountDown"></param>
        /// <param name="birthDate"></param>
        /// <param name="i"></param>
        /// <returns>double</returns>
        public static double GetIntellectual(DateTime dateCountDown, DateTime birthDate, int i)
        {
            return (Math.Sin(2 * Math.PI * ((dateCountDown - birthDate).Days + i) / intel)) * 100;
        }

        /// <summary>
        /// Получение физических данных
        /// </summary>
        /// <param name="dateCountDown"></param>
        /// <param name="birthDate"></param>
        /// <param name="i"></param>
        /// <returns>double</returns>
        public static double GetPhysical(DateTime dateCountDown, DateTime birthDate, int i)
        {
            return (Math.Sin(2 * Math.PI * ((dateCountDown - birthDate).Days + i) / phys)) * 100;
        }
    }
}
