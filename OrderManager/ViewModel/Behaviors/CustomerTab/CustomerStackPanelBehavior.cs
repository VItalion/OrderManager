using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class CustomerStackPanelBehavior : Behavior<StackPanel>
    {
        protected override void OnAttached()
        {
            Events.OnSelectCustomer += OnSelectCustomerEventHandler;
            Events.OnCancelChangeCustomer += OnCancelChangeEventHandler;
        }

        private void OnCancelChangeEventHandler()
        {
            AssociatedObject.Children.Clear();

            var control = new View.CustomerPanel();
            control.DataContext = SelectedCustomer.Customer;
           
            using (var context = new DataContext())
            {
                var data = context.Customers.Where((c) => c.Id == SelectedCustomer.Customer.Id).Single();
                control.DataContext = data;
            }
            AssociatedObject.Children.Add(control);
        }

        private async void OnSelectCustomerEventHandler(Customer obj)
        {
            AssociatedObject.Children.Clear();

            var control = new View.CustomerPanel();
            AssociatedObject.Children.Add(control);

            await System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(() => control.DataContext = obj);
            });
        }
                
        protected override void OnDetaching()
        {
            Events.OnSelectCustomer -= OnSelectCustomerEventHandler;
            Events.OnCancelChangeCustomer -= OnCancelChangeEventHandler;
        }
    }
}
