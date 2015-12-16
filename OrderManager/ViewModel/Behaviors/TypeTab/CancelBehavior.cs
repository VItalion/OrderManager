using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TypeTab
{
    class CancelBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += Cancel;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<View.SelectTabType>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= Cancel;
        }
    }
}
