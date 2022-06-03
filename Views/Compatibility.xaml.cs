using BiorhythmsCalc.Charts;
using BiorhythmsCalc.Helpers;
using BiorhythmsCalc.Models;
using BiorhythmsCalc.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BiorhythmsCalc.Views
{
    /// <summary>
    /// Логика взаимодействия для Compatibility.xaml
    /// </summary>
    public partial class Compatibility : Page
    {
        /// <summary>
        /// Список лейблов на графике
        /// </summary>
        List<string> Labels = new List<string>();
        /// <summary>
        /// Коллекция данных биоритмов
        /// </summary>
        ObservableCollection<Biorhythm> biorhythms = new ObservableCollection<Biorhythm>();

        public Compatibility()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Включаем текстбокс с вводом количества дней
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            arbitrary.IsEnabled = true;
        }

        /// <summary>
        /// Выключаем текстбокс с вводом количества дней
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            arbitrary.IsEnabled = false;
        }

        /// <summary>
        /// Построение граика и занесение данных в список статистики пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int arbitrarys = 0;
            DateTime birthDate = DateTime.Now;
            DateTime birthDate1 = DateTime.Now;
            DateTime dateCountDown = DateTime.Now;

            try
            {
                dateCountDown = Convert.ToDateTime(countDownTime.Text);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при получении даты отсчета");
            }

            try
            {
                birthDate = Convert.ToDateTime(BirthDate.Text);
                birthDate1 = Convert.ToDateTime(BirthDate1.Text);
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
                    MessageBox.Show("Произошла ошибка при получении данных длительности");
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
                    MessageBox.Show("Произошла ошибка при получении данных длительности");
                }
            }
            biorhythms.Clear();
            biorhythms = BioService.GetListBiorhythm(arbitrarys, dateCountDown, birthDate, birthDate1, biorhythms);
            Dates.ItemsSource = biorhythms;
            Stat.Stats(Dates, list, birthDate, birthDate1, arbitrarys, dateCountDown, biorhythms);

            Chart.GetChartForTwo(biorhythms, ref Labels, chart);
        }

        /// <summary>
        /// Экспорт данных в csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Export.ExportDataToCsv(biorhythms, "datafilefortwo", list);
        }

        /// <summary>
        /// Показ даты на граифке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateon_Checked(object sender, RoutedEventArgs e)
        {
            chart.AxisX = new AxesCollection()
                {
                    new Axis()
                    {
                        Title = "Дата",
                        Labels = Labels,
                    }
                };
        }

        /// <summary>
        /// Отключение даты на графике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateon_UnChecked(object sender, RoutedEventArgs e)
        {
            chart.AxisX = new AxesCollection()
                {
                    new Axis()
                    {
                        Title = "Дата",
                        MinValue = 0,
                    }
                };
        }
    }
}
