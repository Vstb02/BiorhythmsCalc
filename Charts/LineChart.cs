using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


//====================================================
// Описание работы классов и методов исходника на:
// https://www.interestprograms.ru
// Исходные коды программ и игр
//====================================================


namespace WpfDrawing.Charts
{
    internal class LineChart : Chart
    {
        private readonly double _lineThickness = 4;
        private readonly double _sizePoint = 20;


        public override void AddValue(double value)
        {
            // Получаем все значения которые уже есть в графике.
            List<double> listValues = ChartBackground.Children.OfType<Ellipse>().Select(p => (double)p.Tag).ToList();

            // Вычисляем новую длину отрезка по лилинии, чтобы график поместился 
            // полностью на ширину поля.
            double lengthSectionLine = listValues.Count > 0 ? WidthChart / listValues.Count : WidthChart;

            // Добавляем новое значение в график.
            listValues.Add(value);

            // Для ограничения высоты графика, вне зависимости от абсолютных значений,
            // вычислим общий знаменатель. И самое большое значение будет на максимальной
            // допустимой высоте. остальные пропорционально ниже.
            double maxValue = listValues.Max();
            double denominator = maxValue / HeightChart;

            // Удалим текущие элементы графика.
            Clear();

            // Инициализация новой ломаной линии.
            Polyline _polyline = new();
            _polyline.Stroke = Brushes.BlueViolet;
            _polyline.StrokeThickness = _lineThickness;
            _polyline.StrokeDashCap = PenLineCap.Flat;
            _polyline.StrokeLineJoin = PenLineJoin.Round;
            _polyline.HorizontalAlignment = HorizontalAlignment.Left;
            ChartBackground.Children.Add(_polyline);


            // Создание графика по текущим абсолютным значениям.
            // Абсолютные значения сохраняются в свойствах Ellipse.Tag
            foreach (double val in listValues)
            {
                // Счётчик добавленных в график узловых точек.
                int count = ChartBackground.Children.OfType<Ellipse>().Count();

                // Относительная высота точки от нижнего края.
                // Для этого все абсолютные значения делятся на общий знаменатель,
                // чтобы максимальная высота точек не выходила выше установленной.
                double heightPoint = val / denominator;

                // Координаты узловой точки.
                double x = (count * lengthSectionLine) + (ChartBackground.ActualWidth - WidthChart) / 2;
                double y = heightPoint;

                // Узловая точка графика.
                Ellipse point = CreatePoint(x, y, _sizePoint, val);
                ChartBackground.Children.Add(point);

                // Надпись около узловой точки.
                Label title = CreateTitle(x - (_sizePoint / 2), y, val);
                ChartBackground.Children.Add(title);

                // Отрезок линии соединяющий предыдущую и текущую узловую точку.
                _polyline.Points.Add(new Point(x, ChartBackground.ActualHeight - y /* переворачиваем значение: отсчёт идёт от bottom*/));
            }
        }


        public override void Clear() => ChartBackground.Children.Clear();


        #region Private


        /// <summary>
        /// Создание узловой точки графика.
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата</param>
        /// <param name="value">абсолютное значение точки</param>
        /// <returns></returns>
        private Ellipse CreatePoint(double x, double y, double diameter, double value)
        {
            Random random = new();

            Ellipse point = new()
            {
                StrokeThickness = 2,
                Width = diameter,
                Height = diameter,
                Fill = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256))),
                Stroke = Brushes.White,
                Tag = value
            };

            Canvas.SetLeft(point, x - diameter / 2);
            // Отсчёт координат графика идёт от нижнего края.
            Canvas.SetBottom(point, y - diameter / 2);

            return point;
        }


        /// <summary>
        /// Создание текстовой надписи около узловой точки.
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата</param>
        /// <param name="value">абсолютное значение выводится как текст</param>
        /// <returns></returns>
        private Label CreateTitle(double x, double y, double value)
        {
            Label title = new()
            {
                Content = value,
                Padding = new Thickness(0, 0, 0, 10)
            };

            Canvas.SetLeft(title, x);
            // Отсчёт координат графика идёт от нижнего края.
            Canvas.SetBottom(title, y);

            return title;
        }


        #endregion
    }
}
