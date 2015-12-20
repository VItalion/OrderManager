using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class CustomerStackPanelBehavior : Behavior<StackPanel>
    {
        protected override void OnAttached()
        {
            Events.OnSelectCustomer += OnSelectCustomerEventHandler;
            Events.OnCancelChangeCustomer += OnCancelChangeEventHandler;
            Events.OnShowCustomerInformation += ShowGeneralInformation;            
        }

        private void ShowGeneralInformation()
        {
            List<Customer> list = new List<Customer>();
            foreach (var Customer in DB.Context.Customers)
            {
                list.Add(new Customer() { FullName = Customer.FullName, Country = Customer.Country, City = Customer.City });
            }

            if (list.Count != 0)
            {
                DataGrid grid = new DataGrid();
                grid.IsReadOnly = true;
                grid.ItemsSource = list;
                AssociatedObject.Children.Clear();
                AssociatedObject.Children.Add(grid);
            }
            else
            {
                TextBlock tb = new TextBlock();
                tb.Text = "Заказчики отсутствуют";
                AssociatedObject.Children.Clear();
                AssociatedObject.Children.Add(tb);
            }
        }

        private void OnCancelChangeEventHandler()
        {
            AssociatedObject.Children.Clear();

            var control = new View.CustomerPanel();
            control.DataContext = new Model.Customer(SelectedCustomer.Customer);
            SelectedCustomer.Current = new Model.Customer(SelectedCustomer.Customer);
            
            //var data = DB.Context.Customers.Where((c) => c.Id == SelectedCustomer.Current.Id).Single();
            //control.DataContext = data;
            
            AssociatedObject.Children.Add(control);
        }

        private async void OnSelectCustomerEventHandler(Model.Customer obj)
        {
            AssociatedObject.Children.Clear();

            var control = new View.CustomerPanel();
            AssociatedObject.Children.Add(control);
            Events.PersonChange();
            control.IsEnabled = false;
            await System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(() =>
                {
                    var data = new Model.Customer(obj);
                    control.DataContext = data;
                });
            });
            control.IsEnabled = true;
            Events.CustomerCancelChange();
        }
                
        protected override void OnDetaching()
        {
            Events.OnSelectCustomer -= OnSelectCustomerEventHandler;
            Events.OnCancelChangeCustomer -= OnCancelChangeEventHandler;
            Events.OnShowCustomerInformation -= ShowGeneralInformation;
        }
    }

    class Customer
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }        
    }
}
