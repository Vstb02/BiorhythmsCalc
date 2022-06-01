using BiorhythmsCalc.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDrawing.Charts;

namespace BiorhythmsCalc.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            arbitrary.IsEnabled = true;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            arbitrary.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Biorhythm> biorhythms = new List<Biorhythm>();
            int arbitrarys = 0;
            DateTime birthDate = DateTime.Now;

            const int phys = 23;
            const int emot = 28;
            const int intel = 33;

            try
            {
                birthDate = Convert.ToDateTime(BirthDate.Text);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при получении даты рождения");
            }

            if (arbitrary.IsEnabled == true)
            {
                try
                {
                    arbitrarys = Convert.ToInt32(arbitrary.Text);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при получении данных отчета");
                }
            }
            else
            {
                try
                {
                    arbitrarys = Convert.ToInt32(cmbCountdown.Text);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при получении данных отчета");
                }
            }
            DateTime dateCountDown;
            for (int i = 0; i < arbitrarys; i++)
            {
                dateCountDown = Convert.ToDateTime(countDownTime.Text);
                var bior = new Biorhythm()
                {
                    Date = dateCountDown.AddDays(i).ToShortDateString(),
                    Emotional = Math.Round((Math.Sin(2 * Math.PI * ((dateCountDown - birthDate).Days + i) / emot)) * 100, 2),
                    Intellectual = Math.Round((Math.Sin(2 * Math.PI * ((dateCountDown - birthDate).Days + i) / intel)) * 100, 2),
                    Physical = Math.Round((Math.Sin(2 * Math.PI * ((dateCountDown - birthDate).Days + i) / phys)) * 100, 2),
                };
                bior.Total = Math.Round(bior.Emotional + bior.Intellectual + bior.Physical, 2);

                biorhythms.Add(bior);
            }
            Dates.ItemsSource = biorhythms;

            ////////////////////


            // Удаляем прежний график.
            GridForChart.Children.OfType<Canvas>().ToList().ForEach(p => GridForChart.Children.Remove(p));

            Chart chart = null;
            Chart chart1 = null;
            Chart chart2 = null;

            chart = new LineChart();
            chart1 = new LineChart();
            chart2 = new LineChart();

            // Добавляем новую диаграмму на поле контейнера для графиков.
            GridForChart.Children.Add(chart.ChartBackground);
            GridForChart.Children.Add(chart1.ChartBackground);
            GridForChart.Children.Add(chart2.ChartBackground);

            // Принудительно обновляем размеры контейнера для графика.
            GridForChart.UpdateLayout();

            // Создаём график.
            CreateChartEmotional(chart, biorhythms);
            CreateChartPhysical(chart1, biorhythms);
            CreateChartIntellectual(chart2, biorhythms);
        }


        private static void CreateChartEmotional(Chart chart, List<Biorhythm> biorhythms)
        {
            chart.Clear();

            for (int i = 0; i < biorhythms.Count; i++)
            {
                chart.AddValue(biorhythms[i].Emotional);
            }
        }
        private static void CreateChartPhysical(Chart chart, List<Biorhythm> biorhythms)
        {
            chart.Clear();

            for (int i = 0; i < biorhythms.Count; i++)
            {
                chart.AddValue(biorhythms[i].Physical);
            }
        }
        private static void CreateChartIntellectual(Chart chart, List<Biorhythm> biorhythms)
        {
            chart.Clear();

            for (int i = 0; i < biorhythms.Count; i++)
            {
                chart.AddValue(biorhythms[i].Intellectual);
            }
        }
    }
}
