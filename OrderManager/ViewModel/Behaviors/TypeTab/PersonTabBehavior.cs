using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TypeTab
{
    class PersonTabBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += CreatePersonTab;
        }

        private void CreatePersonTab(object sender, RoutedEventArgs e)
        {
            Events.CreatePersonTab();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CreatePersonTab;
        }
    }
}
