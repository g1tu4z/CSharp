using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public class Line
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public Brush brush { get; set; }
    }

    public class GraphData
    {
        public Thickness RectangleMargin { get; set; }
        public Brush RectangleColor { get; set; }
        public Line[] Lines { get; set; }
    }

    public class LineItemsControlViewModel
    {
        public GraphData GraphData { get; set; }

        public LineItemsControlViewModel()
        {
            GraphData = new GraphData
            {
                RectangleMargin = new Thickness(300, 0, 0, 0),
                RectangleColor = new SolidColorBrush(Color.FromArgb(120,125,125,135)),
                Lines = new Line[]
                {
                    new Line{X1=130, Y1=70, X2=130, Y2=111, brush=Brushes.Red},
                    new Line{X1=50, Y1=10, X2=50, Y2=111, brush=Brushes.Green},
                    new Line{X1=220, Y1=90, X2=220, Y2=111, brush=Brushes.Yellow},
                    new Line{X1=320, Y1=30, X2=320, Y2=111, brush=Brushes.Orange},
                }
            };
        }
    }
}
