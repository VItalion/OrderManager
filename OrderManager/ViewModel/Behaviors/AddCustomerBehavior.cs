using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors
{
    class AddCustomerBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += AddCustomer;
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            View.CreateCustomer cc = new View.CreateCustomer();
            cc.DataContext = new Model.Customer();
            cc.ShowDialog();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AddCustomer;
        }
    }
}
