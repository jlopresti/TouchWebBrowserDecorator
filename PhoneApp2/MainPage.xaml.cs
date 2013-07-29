using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp2.Resources;
using TreeExtensions;
using Microsoft.Phone.Controls;
using System.Windows.Input;
namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        private TouchWebBrowserDecorator decorator;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            decorator = new TouchWebBrowserDecorator(wb);
        }
    }
}