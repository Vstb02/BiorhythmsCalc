using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


//====================================================
// Описание работы классов и методов исходника на:
// https://www.interestprograms.ru
// Исходные коды программ и игр
//====================================================

namespace WpfDrawing.Charts
{
    internal abstract class Chart
    {
        // Коэффициент высоты графика относительно высоты контейнера.
        private readonly double _factor = 0.666666666666667;
        protected readonly double PaddingChart = 10;
        protected double WidthChart;
        protected double HeightChart;
        public readonly Canvas ChartBackground = new();

        public Chart()
        {
            ChartBackground.Margin = new Thickness(0);
            ChartBackground.SizeChanged += ChartBackground_SizeChanged;
        }

        private void ChartBackground_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Инициализация ширины и высоты графиков.
            WidthChart = e.NewSize.Width - (PaddingChart * 2);

            // Верхний предел графика на 10 линии снизу.
            HeightChart = e.NewSize.Height * _factor;

        }

        public abstract void AddValue(double value);
        public abstract void Clear();



        private Brush DrawLines(double actualwidth, double widthchart, double padding)
        {
            double W = actualwidth;
            double w = widthchart;
            double offset = padding;

            // --- Величины для относительных расчетов ---

            // W - (абсолютная величина как общий знаменатель)
            // (Относительная ширина контейнера графика (рисуется сетка заднего фона)) = 1 (W/W)

            // x - (Относительная ширина поля графика) = w/W
            double x = w / W;

            // delta - (Относительное смещение сетки заднего фона графика) = offset/W
            double delta = offset / W;

            // --- 

            // Количество линий по горизонтали и вертикали.
            // По вертикали всего 15 линий, но график только до 10-ой.
            int numLines = 10;

            DrawingBrush brush = new()
            {
                // Режим задающий правило заполнения фона элемента плитками 
                TileMode = TileMode.Tile,

                // Область просмотра задана относительными величинами.
                // График будет иметь в высоту и в ширину одинаковое кол-во линий.
                Viewport = new Rect(delta, 0, x / numLines, _factor / numLines),

                // Рисуем прямоугольник, формирующий фоновую сетку.
                Drawing = new GeometryDrawing()
                {
                    Pen = new(Brushes.Black, 0.05),
                    Brush = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                    Geometry = new RectangleGeometry(new Rect(0, 0, 45, 20))
                }
            };

            return brush;
        }
    }
}
