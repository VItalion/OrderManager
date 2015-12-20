using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CreateExecutor
{
    class CreateExecutorBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += Create;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            ExecutorTab.SelectedExecutor.Current = b.DataContext as Model.Executor;
            Events.CreateExecutor(ExecutorTab.SelectedExecutor.Current);
                       
            Application.Current.Windows.OfType<View.CreateExecutor>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= Create;
        }
    }
}
