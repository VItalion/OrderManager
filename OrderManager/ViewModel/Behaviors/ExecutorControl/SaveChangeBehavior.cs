using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class SaveChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += SaveCahnge;
        }

        private void SaveCahnge(object sender, RoutedEventArgs e)
        {            
            var data = ExecutorTab.SelectedExecutor.Executor;

            Events.ExecutorSaveChange(data);
        }
                
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= SaveCahnge;
        }
    }
}
