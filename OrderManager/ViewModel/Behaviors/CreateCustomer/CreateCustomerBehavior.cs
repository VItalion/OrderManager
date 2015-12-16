using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CreateCustomer
{
    class CreateCustomerBehavior : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            AssociatedObject.Click += Create;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var b = e.OriginalSource as Button;
            var data = b.DataContext as Model.Customer;

            Events.CreateCustomer(data);

            Application.Current.Windows.OfType<View.CreateCustomer>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= Create;
        }
    }
}
