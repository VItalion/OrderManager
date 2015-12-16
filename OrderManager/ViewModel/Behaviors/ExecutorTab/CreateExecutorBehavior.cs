using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorTab
{
    class CreateExecutorBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += NewExecutor;
        }

        private void NewExecutor(object sender, RoutedEventArgs e)
        {            
            var window = new View.CreateExecutor();
            window.DataContext = new Model.Executor();
            window.Show();
        }
                
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= NewExecutor;
        }
    }
}
