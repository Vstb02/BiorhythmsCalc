using BiorhythmsCalc.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiorhythmsCalc.Charts
{
    /// <summary>
    /// Построение графиков
    /// </summary>
    public static class Chart
    {
        /// <summary>
        /// Построение графика для двух людей
        /// </summary>
        /// <param name="biorhythms"></param>
        /// <param name="Labels"></param>
        /// <param name="chart"></param>
        public static void GetChartForTwo(ObservableCollection<Biorhythm> biorhythms, ref List<string> Labels, CartesianChart chart)
        {
            Labels.Clear();

            ChartValues<double> PhysicalValues = new ChartValues<double>();
            ChartValues<double> EmotionalValues = new ChartValues<double>();
            ChartValues<double> IntellectualValues = new ChartValues<double>();
            SeriesCollection series = new SeriesCollection();
            foreach (Biorhythm bior in biorhythms)
            {
                PhysicalValues.Add(bior.Physical);
                EmotionalValues.Add(bior.Emotional);
                IntellectualValues.Add(bior.Intellectual);
                Labels.Add(bior.Date.ToString());
            }

            series.Add(new LineSeries
            {
                Title = "Физические ритмы",
                Values = PhysicalValues,
            });
            series.Add(new LineSeries
            {
                Title = "Эмоциональные ритмы",
                Values = EmotionalValues
            });
            series.Add(new LineSeries
            {
                Title = "Интеллектуальные ритмы",
                Values = IntellectualValues
            });
            chart.AxisY = new AxesCollection()
            {
                new Axis()
                {
                    Title = "Значения",
                    MinValue = -200,
                    MaxValue = 200,
                }
            };

            chart.Series = series;
            chart.Update();
        }
        /// <summary>
        /// Построение графика
        /// </summary>
        /// <param name="biorhythms"></param>
        /// <param name="Labels"></param>
        /// <param name="chart"></param>
        public static void GetChart(ObservableCollection<Biorhythm> biorhythms, ref List<string> Labels, CartesianChart chart)
        {
            Labels.Clear();

            ChartValues<double> PhysicalValues = new ChartValues<double>();
            ChartValues<double> EmotionalValues = new ChartValues<double>();
            ChartValues<double> IntellectualValues = new ChartValues<double>();
            SeriesCollection series = new SeriesCollection();
            foreach (Biorhythm bior in biorhythms)
            {
                PhysicalValues.Add(bior.Physical);
                EmotionalValues.Add(bior.Emotional);
                IntellectualValues.Add(bior.Intellectual);
                Labels.Add(bior.Date.ToString());
            }

            series.Add(new LineSeries
            {
                Title = "Физические ритмы",
                Values = PhysicalValues,
            });
            series.Add(new LineSeries
            {
                Title = "Эмоциональные ритмы",
                Values = EmotionalValues
            });
            series.Add(new LineSeries
            {
                Title = "Интеллектуальные ритмы",
                Values = IntellectualValues
            });
            chart.AxisY = new AxesCollection()
            {
                new Axis()
                {
                    Title = "Значения",
                    MinValue = -100,
                    MaxValue = 100,
                }
            };

            chart.Series = series;
            chart.Update();
        }
    }
}
