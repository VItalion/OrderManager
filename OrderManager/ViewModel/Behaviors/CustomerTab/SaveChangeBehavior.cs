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
    class SaveChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += SaveChange;
            Events.OnPersonChange += OnChangeEventHandler;
            Events.OnSaveChangeCustomer += Events_OnSaveChangeCustomer;
            Events.OnCancelChangeCustomer += Events_OnCancelChangeCustomer;
        }

        private void SaveChange(object sender, RoutedEventArgs e)
        {
            Events.CustomerSaveChange(AssociatedObject.DataContext as Model.Customer);
        }

        private void Events_OnCancelChangeCustomer()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void Events_OnSaveChangeCustomer(Model.Customer obj)
        {
            AssociatedObject.IsEnabled = false;
        }

        private void OnChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= SaveChange;
            Events.OnPersonChange -= OnChangeEventHandler;
            Events.OnSaveChangeCustomer -= Events_OnSaveChangeCustomer;
            Events.OnCancelChangeCustomer -= Events_OnCancelChangeCustomer;
        }
    }
}
