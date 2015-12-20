using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class CustomerBehavior : Behavior<TreeViewItem>
    {
        protected override void OnAttached()
        {
            //AssociatedObject.Selected += SelectCustomer;
            AssociatedObject.Loaded += AssociatedObject_Loaded;

            /*Events.OnCreateCustomer += OnCreateCustomerEventHandler;
            Events.OnDeleteCustomer += OnDeleteCustomerEventHandler;
            Events.OnSaveChangeCustomer += OnSaveChangeCustomer;
            Events.OnCancelChangeCustomer += OnCancelChangeEventHandler;*/
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.DataContext = DB.Context.Customers.ToList();
            Update();
        }

        /*private void OnCancelChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void OnSaveChangeCustomer(Customer obj)
        {
            var data = DB.Context.Customers.Where(e => e.Id == obj.Id).Single();
            data.FullName = obj.FullName;
            data.Country = obj.Country;
            data.City = obj.City;
            data.Street = obj.Street;
            data.Photo = obj.Photo;
            obj.Projects.CopyTo(data.Projects.ToArray(), 0);
            
            DB.Context.SaveChanges();

            AssociatedObject.IsEnabled = true;
        }

        private void OnDeleteCustomerEventHandler(Customer obj)
        {
            var customer = DB.Context.Customers.Where(e => e.Id == obj.Id).Single();

            DB.Context.Customers.Remove(customer);
            DB.Context.SaveChanges();

            AssociatedObject.DataContext = DB.Context.Customers.ToList();
        }

        private void OnCreateCustomerEventHandler(Customer obj)
        {
            DB.Context.Customers.Add(obj);
            DB.Context.SaveChanges();

            AssociatedObject.DataContext = DB.Context.Customers.ToList();
            Events.CustomerSaveChange(obj);
        }

        private void SelectCustomer(object sender, RoutedEventArgs e)
        {
            var p = AssociatedObject.Parent as TreeView;
            var current = p.SelectedItem as Model.Customer;

            Events.SelectCustomer(current);
        }*/

        protected override void OnDetaching()
        {
            //AssociatedObject.Selected -= SelectCustomer;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;

            /*Events.OnCreateCustomer -= OnCreateCustomerEventHandler;
            Events.OnDeleteCustomer -= OnDeleteCustomerEventHandler;
            Events.OnSaveChangeCustomer -= OnSaveChangeCustomer;
            Events.OnCancelChangeCustomer -= OnCancelChangeEventHandler;*/
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
            SelectedCustomer.Customer = AssociatedObject.DataContext as Customer;
        }

        private void SelectCustomer(object sender, MouseButtonEventArgs e)
        {
            SelectedCustomer.Customer = (sender as TreeViewItem).DataContext as Customer;
            Events.SelectCustomer(SelectedCustomer.Customer);
        }
    }
}
