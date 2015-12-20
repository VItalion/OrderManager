using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class CustomerBehavior : Behavior<TreeViewItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.PreviewMouseLeftButtonDown += ShowGlobalInformation;
            Events.OnCreateCustomer += OnCreateCustomerEventHandler;
            Events.OnDeleteCustomer += OnDeleteCustomerEventHandler;
            Events.OnSaveChangeCustomer += OnSaveChangeCustomer;
        }

        private void ShowGlobalInformation(object sender, MouseButtonEventArgs e)
        {
            Events.ShowCustomerInformation();
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.DataContext = DB.Context.Customers.ToList();
            Update();
        }

        private void OnCancelChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void OnSaveChangeCustomer(Model.Customer obj)
        {            
            Update();
            AssociatedObject.IsEnabled = true;
        }

        private void OnDeleteCustomerEventHandler(Model.Customer obj)
        {
            var customer = DB.Context.Customers.Where(e => e.Id == obj.Id).Single();            
            DB.Context.Customers.Remove(customer);
            SelectedCustomer.Current = null;
            SelectedCustomer.Customer = null;
            DB.Context.SaveChanges();

            Update();
        }

        private void OnCreateCustomerEventHandler(Model.Customer obj)
        {
            DB.Context.Customers.Add(obj);
            DB.Context.SaveChanges();
            
            Update();
            Events.CustomerSaveChange(obj);
        }
        
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.PreviewMouseLeftButtonDown -= ShowGlobalInformation;
            Events.OnCreateCustomer -= OnCreateCustomerEventHandler;
            Events.OnDeleteCustomer -= OnDeleteCustomerEventHandler;
            Events.OnSaveChangeCustomer -= OnSaveChangeCustomer;           
        }

        private void Update()
        {
            AssociatedObject.Items.Clear();

            foreach (var customer in DB.Context.Customers)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = customer.FullName;
                item.PreviewMouseLeftButtonDown += SelectCustomer;
                item.PreviewMouseRightButtonDown += SelectData;

                if (customer.Projects != null)
                    foreach (var project in customer.Projects)
                    {
                        TreeViewItem projectItem = new TreeViewItem();
                        projectItem.Header = project.Name;
                        item.Items.Add(projectItem);
                    }

                item.DataContext = customer;

                AssociatedObject.Items.Add(item);
            }
        }

        private void SelectData(object sender, MouseButtonEventArgs e)
        {
            var item = sender as TreeViewItem;
            SelectedCustomer.Customer = new Model.Customer(item.DataContext as Model.Customer);
            SelectedCustomer.Current = item.DataContext as Model.Customer;
        }

        private void SelectCustomer(object sender, MouseButtonEventArgs e)
        {
            var item = sender as TreeViewItem;
            var data = item.DataContext as Model.Customer;
            SelectedCustomer.Current = data;            
            Events.SelectCustomer(SelectedCustomer.Current);
        }
    }
}
