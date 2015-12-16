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
    class CancelChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += CancelChange;
        }

        private void CancelChange(object sender, RoutedEventArgs e)
        {
            Events.ExecutorCancelChange();
        }
                
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CancelChange;
        }
    }
}
