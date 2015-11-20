using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModuleDesign
{
    public class LoginHelper
    {
        public static string CreateCode()
        {
            string result = string.Empty;
            string[] codes = new string[32] { "2", "3", "4", "5", "6", "7", "8", "9",
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J","K", "M", "N", "P", 
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            Random random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 6; i++)
            {
                result += codes[random.Next(codes.Length)];
            }

            return result;
        }

        public static void CreateImage(string code, Image image, int width, int height)
        {
            Color[] colors = { Colors.Black, Colors.Red, Colors.Blue, Colors.Green, 
                                Colors.Orange, Colors.Brown, Colors.Brown };

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.Margin = new Thickness(4);

            Random random = new Random(Guid.NewGuid().GetHashCode());

            for (int codeNumber = 0; codeNumber < code.Length; codeNumber++)
            {
                TextBlock textBlock = DrawCodes(code, colors, random, codeNumber);
                stackPanel.Children.Add(textBlock);
            }

            //for (int lineNumber = 0; lineNumber < 10; lineNumber++)
            //{
            //    Polyline line = DrawLines(width, height, colors, random);
            //    stackPanel.Children.Add(line);
            //}

            WriteableBitmap writeableBitmap = new WriteableBitmap(stackPanel, new TransformGroup());
            writeableBitmap.Render(stackPanel, new TransformGroup());
            image.Source = writeableBitmap;
        }

        private static Polyline DrawLines(int width, int height, Color[] colors, Random random)
        {
            Polyline line = new Polyline();
            for (int pointNumber = 0; pointNumber < random.Next(3, 6); pointNumber++)
            {
                double x = random.NextDouble() * width;
                double y = random.NextDouble() * height;
                line.Points.Add(new Point(x, y));
            }
            line.Stroke = new SolidColorBrush(colors[random.Next(colors.Length)]);
            line.StrokeThickness = 1;
            return line;
        }

        private static TextBlock DrawCodes(string code, Color[] colors, Random random, int codeNumber)
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
            return textBlock;
        }
    }
}


