using BiorhythmsCalc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiorhythmsCalc.Helpers
{
    /// <summary>
    /// Экспорт данных
    /// </summary>
    public static class Export
    {
        /// <summary>
        /// Экспорт данных статистики и биоритмов в csv
        /// </summary>
        /// <param name="DG"></param>
        /// <param name="filename"></param>
        /// <param name="list"></param>
        public static void ExportDataToCsv(ObservableCollection<Biorhythm> DG, string filename, ListBox list)
        {
            string path = filename + ".csv";
            string text = "Статистика: \n";
            var data = DG.ToArray();
            var RowCount = data.Length;
            var ColumnCount = 3;
            Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

            DataArray[0, 0] = "Дата";
            DataArray[0, 1] = "Эмоц.";
            DataArray[0, 2] = "Физич.";
            DataArray[0, 3] = "Интеллект.";

            for (int i = 0; i < RowCount; i++)
            {
                DataArray[i + 1, 0] = data[i].Date;
                DataArray[i + 1, 1] = data[i].Emotional;
                DataArray[i + 1, 2] = data[i].Physical;
                DataArray[i + 1, 3] = data[i].Intellectual;
            }

            foreach (var item in list.Items)
            {
                text += item + "\n";
            }

            using (StreamWriter writer = new StreamWriter(path, false, Encoding.Unicode))
            {
                writer.WriteLine(text);
            }
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.Unicode))
            {
                for (int i = 0; i < RowCount + 1; i++)
                {
                    for (int j = 0; j < ColumnCount + 1; j++)
                    {
                        writer.Write("{0,10} | ", DataArray[i, j]);
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
