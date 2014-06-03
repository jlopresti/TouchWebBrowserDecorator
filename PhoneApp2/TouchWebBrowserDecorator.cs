using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using TreeExtensions;

namespace PhoneApp2
{
    public class TouchWebBrowserDecorator
    {
        private WebBrowser _webBrowser;

        public TouchWebBrowserDecorator(WebBrowser browser)
        {
            _webBrowser = browser;
            _webBrowser.Loaded += new RoutedEventHandler(browser_Loaded);
        }

        void browser_Loaded(object sender, RoutedEventArgs e)
        {
            //Child border to handle horizontal manipulation
            var childBorder = _webBrowser.Descendants<Border>().Last();
            childBorder.ManipulationDelta += Border_ManipulationDelta;

            //PanZoomContainer parent (handle event to set handled to false and bubble up event)
            var parentBorder = _webBrowser.Descendants<Border>().Skip(1).First();
            parentBorder.AddHandler(FrameworkElement.ManipulationStartedEvent, new EventHandler<ManipulationStartedEventArgs>(wb_ManipulationStarted), true);
            parentBorder.AddHandler(FrameworkElement.ManipulationDeltaEvent, new EventHandler<ManipulationDeltaEventArgs>(wb_ManipulationDelta), true);
            parentBorder.AddHandler(FrameworkElement.ManipulationCompletedEvent, new EventHandler<ManipulationCompletedEventArgs>(wb_ManipulationCompleted), true);
        }

        private void Border_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (Math.Abs(e.DeltaManipulation.Translation.X) > Math.Abs(e.DeltaManipulation.Translation.Y))
                e.Handled = true;

            if (e.CumulativeManipulation.Scale.X != 0.0 || e.CumulativeManipulation.Scale.Y != 0.0)
                e.Handled = true;
        }
        
        private void wb_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            e.Handled = false;
        }

        private void wb_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            e.Handled = false;
        }

        private void wb_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            e.Handled = false;
        }

    }
}
