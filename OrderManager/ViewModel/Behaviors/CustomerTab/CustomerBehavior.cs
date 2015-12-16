using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class CustomerBehavior : Behavior<TreeViewItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Selected += SelectCustomer;
            AssociatedObject.Loaded += AssociatedObject_Loaded;

            Events.OnCreateCustomer += OnCreateCustomerEventHandler;
            Events.OnDeleteCustomer += OnDeleteCustomerEventHandler;
            Events.OnSaveChangeCustomer += OnSaveChangeCustomer;
            Events.OnCancelChangeCustomer += OnCancelChangeEventHandler;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new DataContext())
            {
                AssociatedObject.DataContext = context.Customers.ToList();
            }
        }

        private void OnCancelChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void OnSaveChangeCustomer(Customer obj)
        {
            var context = new DataContext();
            try
            {
                var data = context.Customers.Where(e => e.Id == obj.Id).Single();
                data = obj;

                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
            }
            finally
            {
                context.Dispose();
                AssociatedObject.IsEnabled = true;
            }
        }

        private void OnDeleteCustomerEventHandler(Customer obj)
        {
            using (var context = new DataContext())
            {
                var customer = context.Customers.Where(e => e.Id == obj.Id).Single();

                context.Customers.Remove(customer);
                context.SaveChanges();

                AssociatedObject.DataContext = context.Customers.ToList();
            }
        }

        private void OnCreateCustomerEventHandler(Customer obj)
        {
            using (var context = new DataContext())
            {
                context.Customers.Add(obj);
                context.SaveChanges();

                AssociatedObject.DataContext = context.Customers.ToList();
                Events.CustomerSaveChange(obj);
            }
        }

        private void SelectCustomer(object sender, RoutedEventArgs e)
        {
            var p = AssociatedObject.Parent as TreeView;
            var current = p.SelectedItem as Model.Customer;

            Events.SelectCustomer(current);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Selected -= SelectCustomer;

            Events.OnCreateCustomer -= OnCreateCustomerEventHandler;
            Events.OnDeleteCustomer -= OnDeleteCustomerEventHandler;
            Events.OnSaveChangeCustomer -= OnSaveChangeCustomer;
            Events.OnCancelChangeCustomer -= OnCancelChangeEventHandler;
        }
    }
}
