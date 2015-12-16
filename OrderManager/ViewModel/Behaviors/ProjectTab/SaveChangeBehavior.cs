using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class SaveChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += SaveChange;
        }

        private void SaveChange(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var data = b.DataContext as Model.Executor;

            Events.ExecutorSaveChange(data);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= SaveChange;
        }
    }
}
