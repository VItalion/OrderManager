using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class DeleteCustomerBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += DeleteCustomer;
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            Events.DeleteCustomer(SelectedCustomer.Current);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= DeleteCustomer;
        }
    }
}
