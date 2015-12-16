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
    class ChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            Events.OnPersonChange += OnChangeEventHandler;
            Events.OnExecutorSaveCahnge += OnSaveChangeEventHandler;
            Events.OnExecutorCancelChange += OnCancelChangeEventHandler;
        }

        private void OnCancelChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void OnSaveChangeEventHandler(Executor obj)
        {
            AssociatedObject.IsEnabled = false;
        }

        private void OnChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        protected override void OnDetaching()
        {
            Events.OnPersonChange -= OnChangeEventHandler;
            Events.OnExecutorSaveCahnge -= OnSaveChangeEventHandler;
            Events.OnExecutorCancelChange -= OnCancelChangeEventHandler;
        }
    }
}
