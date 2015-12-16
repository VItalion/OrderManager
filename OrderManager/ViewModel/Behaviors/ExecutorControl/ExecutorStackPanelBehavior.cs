using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class ExecutorStackPanelBehavior : Behavior<StackPanel>
    {
        protected override void OnAttached()
        {
            Events.OnSelectExecutor += OnSelectExecutorEventHandler;
            Events.OnExecutorCancelChange += OnCancelChange;
        }

        private void OnCancelChange()
        {
            AssociatedObject.Children.Clear();

            var control = new View.ExecutorPanel();
            control.DataContext = ExecutorTab.SelectedExecutor.Executor;

            using (var context = new DataContext())
            {
                var data = context.Executors.Where((e) => e.Id == ExecutorTab.SelectedExecutor.Executor.Id).Single();
                control.DataContext = data;
            }
            AssociatedObject.Children.Add(control);
        }

        private async void OnSelectExecutorEventHandler(Executor obj)
        {
            AssociatedObject.Children.Clear();

            var control = new View.ExecutorPanel();
            AssociatedObject.Children.Add(control);

            await System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(()=> control.DataContext = obj);                
            });
        }

        protected override void OnDetaching()
        {
            Events.OnSelectExecutor -= OnSelectExecutorEventHandler;
            Events.OnExecutorCancelChange -= OnCancelChange;
        }
    }
}
