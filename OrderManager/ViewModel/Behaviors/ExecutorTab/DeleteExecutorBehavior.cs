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
    class DeleteExecutorBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += DeleteExecutor;
        }

        private void DeleteExecutor(object sender, RoutedEventArgs e)
        {
            Events.DeleteExecutor(SelectedExecutor.Executor);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= DeleteExecutor;
        }
    }
}
