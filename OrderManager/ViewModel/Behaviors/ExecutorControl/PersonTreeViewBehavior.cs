using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class PersonTreeViewBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {
            Events.OnPersonChange += OnPersonChangeEventHandler;
            Events.OnExecutorSaveCahnge += Events_OnExecutorSaveCahnge;
            Events.OnExecutorCancelChange += Events_OnExecutorCancelChange;
        }

        private void Events_OnExecutorCancelChange()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void Events_OnExecutorSaveCahnge(Model.Executor obj)
        {
            AssociatedObject.IsEnabled = true;
        }

        private void OnPersonChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        protected override void OnDetaching()
        {
            Events.OnPersonChange -= OnPersonChangeEventHandler;
            Events.OnExecutorSaveCahnge -= Events_OnExecutorSaveCahnge;
            Events.OnExecutorCancelChange -= Events_OnExecutorCancelChange;
        }
    }
}
