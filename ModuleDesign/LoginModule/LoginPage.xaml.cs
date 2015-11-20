using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ModuleDesign
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            CreateValidateImage();
        }

        private void CreateValidateImage()
        {
            string code = LoginHelper.CreateValidateCode();
            LoginHelper.CreateValidateImage(code, img, Convert.ToInt32(bdImage.Width), Convert.ToInt32(bdImage.Height));
        }

        private void bdImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreateValidateImage();
        }
    }
}
