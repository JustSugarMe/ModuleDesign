using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModuleDesign
{
    public class LoginHelper
    {
        public static string CreateValidateCode()
        {
            string result = string.Empty;
            string[] codes = new string[34] { "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J","K", "L", "M", "N", "P", 
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            Random random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 6; i++)
            {
                result += codes[random.Next(codes.Length)];
            }

            return result;
        }

        public static void CreateValidateImage(string code, Image image, int width, int height)
        {
            Color[] colors = { Colors.Black, Colors.Red, Colors.Blue, Colors.Green, 
                                Colors.Orange, Colors.Brown, Colors.Brown };

            Grid grid = new Grid();

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.Margin = new Thickness(4);
            grid.Children.Add(stackPanel);

            Canvas canvas = new Canvas();
            canvas.Width = width;
            canvas.Height = height;
            canvas.HorizontalAlignment = HorizontalAlignment.Center;
            canvas.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(canvas);

            Random random = new Random(Guid.NewGuid().GetHashCode());

            for (int codeNumber = 0; codeNumber < code.Length; codeNumber++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = code[codeNumber].ToString();
                textBlock.Projection = new PlaneProjection()
                {
                    RotationX = random.Next(-40, 40),
                    RotationY = random.Next(-40, 40),
                    RotationZ = random.Next(-20, 20)
                };
                textBlock.Margin = new Thickness(35 * codeNumber, 0, 0, 0);
                textBlock.FontSize = 64;
                textBlock.FontFamily = new FontFamily("SimSun");
                textBlock.Foreground = new SolidColorBrush(colors[random.Next(colors.Length)]);
                stackPanel.Children.Add(textBlock);
            }

            for (int lineNumber = 0; lineNumber < 10; lineNumber++)
            {
                Polyline line = new Polyline();
                for (int pointNumber = 0; pointNumber < 20; pointNumber++)
                {
                    line.Points.Add(new Point(random.NextDouble() * width, random.NextDouble() * height));
                }
                line.Stroke = new SolidColorBrush(colors[random.Next(colors.Length)]);
                line.StrokeThickness = 1;
                canvas.Children.Add(line);
            }

            //for (int pointNumber = 0; pointNumber < 2; pointNumber++)
            //{
            //    Ellipse ellipse = new Ellipse();
            //    //canvas.Children.Add(new Ellipse(random.Next(width), random.Next(height)));
            //}

            WriteableBitmap writeableBitmap = new WriteableBitmap(grid, new TransformGroup());
            writeableBitmap.Render(grid, new TransformGroup());
            image.Source = writeableBitmap;
        }
    }
}


//Random r = new Random(DateTime.Now.Millisecond);
//public void CreatImage(string Text, Image imgsource, int iw, int ih)
//{
//    Grid Gx = new Grid();
//    Canvas cv1 = new Canvas();
//    for (int i = 0; i < 6; i++)
//    {
//        Polyline p = new Polyline();
//        for (int ix = 0; ix < r.Next(3, 6); ix++)
//        {
//            p.Points.Add(new Point(r.NextDouble() * iw,
//                r.NextDouble() * ih));
//        }
//        byte[] Buffer = new byte[3];
//        r.NextBytes(Buffer);
//        SolidColorBrush SC = new SolidColorBrush(Color.FromArgb(255,
//            Buffer[0], Buffer[1], Buffer[2]));
//        p.Stroke = SC;
//        p.StrokeThickness = 0.5;
//        cv1.Children.Add(p);
//    }
//    Canvas cv2 = new Canvas();
//    int y = 0;
//    int lw = 6;
//    double w = (iw - lw) / Text.Length;
//    int h = (int)ih;
//    foreach (char x in Text)
//    {
//        byte[] Buffer = new byte[3];
//        r.NextBytes(Buffer);
//        SolidColorBrush SC = new SolidColorBrush(Color.FromArgb(255,
//            Buffer[0], Buffer[1], Buffer[2]));
//        TextBlock t = new TextBlock();
//        t.TextAlignment = TextAlignment.Center;
//        t.FontSize = r.Next(h - 3, h);
//        t.Foreground = SC;
//        t.Text = x.ToString();
//        t.Projection = new PlaneProjection()
//        {
//            RotationX = r.Next(-30, 30),
//            RotationY = r.Next(-30, 30),
//            RotationZ = r.Next(-10, 10)
//        };
//        cv2.Children.Add(t);
//        Canvas.SetLeft(t, lw / 2 + y * w);
//        Canvas.SetTop(t, 0);
//        y++;
//    }
//    Gx.Children.Add(cv1);
//    Gx.Children.Add(cv2);
//    WriteableBitmap W = new WriteableBitmap(Gx, new TransformGroup());
//    W.Render(Gx, new TransformGroup());
//    imgsource.Source = W;


