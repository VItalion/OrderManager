using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class ChangeProjectTreeViewBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {
            Events.OnProjectChange += ChangeEventHandler;
            
            Events.OnProjectSaveChange += SaveChangeEventHandler;
        }

        private void SaveChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void ChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        protected override void OnDetaching()
        {
            Events.OnProjectChange -= ChangeEventHandler;

            Events.OnProjectSaveChange -= SaveChangeEventHandler;
        }
    }
}
