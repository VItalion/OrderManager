using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class SaveChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += SaveCahnge;
            Events.OnExecutorSaveCahnge += SaveChangeEventHandler;
            Events.OnExecutorCancelChange += CancelChangeEventHandler;
            Events.OnPersonChange += Events_OnPersonChange;
        }

        private void Events_OnPersonChange()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void CancelChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void SaveChangeEventHandler(Model.Executor obj)
        {
            AssociatedObject.IsEnabled = false;
        }

        private void SaveCahnge(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            ExecutorTab.SelectedExecutor.Current = b.DataContext as Model.Executor;
            var data = ExecutorTab.SelectedExecutor.Current;

            Events.ExecutorSaveChange(data);
        }
                
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= SaveCahnge;
            Events.OnExecutorSaveCahnge -= SaveChangeEventHandler;
            Events.OnExecutorCancelChange -= CancelChangeEventHandler;
            Events.OnPersonChange -= Events_OnPersonChange;
        }
    }
}
