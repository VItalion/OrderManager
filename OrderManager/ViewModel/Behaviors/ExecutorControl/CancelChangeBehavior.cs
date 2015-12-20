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
            Events.OnExecutorSaveCahnge += SaveChangeEventHandler;
            Events.OnExecutorCancelChange += CancelChangeEventHandler;
            Events.OnPersonChange += Events_OnPersonChange;
        }

        private void Events_OnPersonChange()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void CancelChange(object sender, RoutedEventArgs e)
        {
            Events.ExecutorCancelChange();
        }

        private void CancelChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void SaveChangeEventHandler(Model.Executor obj)
        {
            AssociatedObject.IsEnabled = false;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CancelChange;
            Events.OnExecutorSaveCahnge -= SaveChangeEventHandler;
            Events.OnExecutorCancelChange -= CancelChangeEventHandler;
            Events.OnPersonChange -= Events_OnPersonChange;
        }
    }
}
