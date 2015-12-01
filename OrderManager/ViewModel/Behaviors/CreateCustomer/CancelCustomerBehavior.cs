﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CreateCustomer
{
    class CancelCustomerBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += CloseWindow;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<View.CreateCustomer>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CloseWindow;
        }
    }
}
