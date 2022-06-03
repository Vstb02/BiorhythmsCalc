using BiorhythmsCalc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiorhythmsCalc.Helpers
{
    /// <summary>
    /// Статистика пользователя
    /// </summary>
    public static class Stat
    {
        /// <summary>
        /// Статистика для одного человека
        /// </summary>
        /// <param name="Dates"></param>
        /// <param name="list"></param>
        /// <param name="birthDate"></param>
        /// <param name="arbitrarys"></param>
        /// <param name="dateCountDown"></param>
        /// <param name="biorhythms"></param>
        public static void Stats(ListBox list, DateTime birthDate, int arbitrarys, DateTime dateCountDown, ObservableCollection<Biorhythm> biorhythms)
        {
            double maxEm = double.MinValue;
            double maxInt = double.MinValue;
            double maxPhys = double.MinValue;
            double maxSum = double.MinValue;
            string maxEmDate = String.Empty;
            string maxIntDate = String.Empty;
            string maxPhysDate = String.Empty;
            string maxSumDate = String.Empty;

            foreach (Biorhythm bior in biorhythms)
            {
                if (bior.Physical > maxPhys)
                {
                    maxPhys = bior.Physical;
                    maxPhysDate = bior.Date;
                }
                if (bior.Emotional > maxEm)
                {
                    maxEm = bior.Emotional;
                    maxEmDate = bior.Date;
                }
                if (bior.Intellectual > maxInt)
                {
                    maxInt = bior.Intellectual;
                    maxIntDate = bior.Date;
                }
                if (bior.Total > maxSum)
                {
                    maxSum = bior.Total;
                    maxSumDate = bior.Date;
                }
            }


            list.Items.Clear();
            list.Items.Add($"Дата рождения 1 - {birthDate.ToShortDateString()}");
            list.Items.Add($"Длительность прогноза - {arbitrarys}");
            list.Items.Add($"Период с - {dateCountDown.ToShortDateString()} - {dateCountDown.AddDays(arbitrarys).ToShortDateString() }");
            list.Items.Add($"Эмоциональный максимум - {maxEm}: {maxEmDate}");
            list.Items.Add($"Интеллектуальный максимум - {maxInt}: {maxIntDate}");
            list.Items.Add($"Физический максимум - {maxPhys}: {maxPhysDate}");
            list.Items.Add($"Максимальное среднее значение - {maxSum}: {maxSumDate}");
        }


        /// <summary>
        /// Статистика для двух человек
        /// </summary>
        /// <param name="Dates"></param>
        /// <param name="list"></param>
        /// <param name="birthDate"></param>
        /// <param name="arbitrarys"></param>
        /// <param name="dateCountDown"></param>
        /// <param name="biorhythms"></param>
        public static void Stats(DataGrid Dates, ListBox list, DateTime birthDate, DateTime birthDate1, int arbitrarys, DateTime dateCountDown, ObservableCollection<Biorhythm> biorhythms)
        {
            double maxEm = double.MinValue;
            double maxInt = double.MinValue;
            double maxPhys = double.MinValue;
            double maxSum = double.MinValue;
            string maxEmDate = String.Empty;
            string maxIntDate = String.Empty;
            string maxPhysDate = String.Empty;
            string maxSumDate = String.Empty;

            Dates.ItemsSource = biorhythms;

            foreach (Biorhythm bior in biorhythms)
            {
                if (bior.Physical > maxPhys)
                {
                    maxPhys = bior.Physical;
                    maxPhysDate = bior.Date;
                }
                if (bior.Emotional > maxEm)
                {
                    maxEm = bior.Emotional;
                    maxEmDate = bior.Date;
                }
                if (bior.Intellectual > maxInt)
                {
                    maxInt = bior.Intellectual;
                    maxIntDate = bior.Date;
                }
                if (bior.Total > maxSum)
                {
                    maxSum = bior.Total;
                    maxSumDate = bior.Date;
                }
            }


            list.Items.Clear();
            list.Items.Add($"Дата рождения 1 - {birthDate.ToShortDateString()}");
            list.Items.Add($"Дата рождения 2 - {birthDate1.ToShortDateString()}");
            list.Items.Add($"Длительность прогноза - {arbitrarys}");
            list.Items.Add($"Период с - {dateCountDown.ToShortDateString()} - {dateCountDown.AddDays(arbitrarys).ToShortDateString() }");
            list.Items.Add($"Эмоциональный максимум - {maxEm}: {maxEmDate}");
            list.Items.Add($"Интеллектуальный максимум - {maxInt}: {maxIntDate}");
            list.Items.Add($"Физический максимум - {maxPhys}: {maxPhysDate}");
            list.Items.Add($"Максимальное среднее значение - {maxSum}: {maxSumDate}");
        }
    }
}
