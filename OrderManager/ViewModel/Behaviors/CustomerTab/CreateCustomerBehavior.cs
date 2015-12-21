﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CustomerTab
{
    class CreateCustomerBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += NewCustomer;
        }

        private void NewCustomer(object sender, RoutedEventArgs e)
        {
            var window = new View.CreateCustomer();
            SelectedCustomer.Customer = new Model.Customer();
            SelectedCustomer.Current = new Model.Customer();
            window.DataContext = SelectedCustomer.Current;
            window.Show();
        }

        
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= NewCustomer;
        }
    }
}
