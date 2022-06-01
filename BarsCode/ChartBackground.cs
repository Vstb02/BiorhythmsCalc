using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


//====================================================
// Описание работы классов и методов исходника на:
// https://www.interestprograms.ru
// Исходные коды программ и игр
//====================================================

namespace WpfDrawing.BarsCode
{
    internal class ChartBackground : Grid
    {
        private SolidColorBrush _bg = new(Color.FromArgb(255, 180, 200, 180));
        private Grid _grid = new();
        private Grid _paddinggrid = new();

        public  UIElementCollection ChartItems
        {
            get => _paddinggrid.Children;
        }


        public ChartBackground()
        {
            Background = new SolidColorBrush(Color.FromArgb(150, 190, 220, 190));

            Children.Add(_paddinggrid);
            _paddinggrid.Margin = new(0);
            //DrawLine();
        }



        public void DrawLine()
        {
            for (int i = 0; i <= 6; i++)
            {
                Line line = new();
                line.X1 = 10;
                line.Y1 = -i * 50 + _paddinggrid.Margin.Bottom;
                line.X2 = 450;
                line.Y2 = -i * 50 + _paddinggrid.Margin.Bottom;
                line.Stroke = new SolidColorBrush(Color.FromArgb(80, 0, 0, 0));
                line.StrokeDashArray = new DoubleCollection() { 5 };
                line.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                line.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                Children.Add(line);
            }
        }
    }
}
