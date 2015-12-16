using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class ChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            Events.OnProjectChange += ObserverBehavior_Change;
            Events.OnProjectSaveChange += Events_OnProjectSaveChange;
            Events.OnProjectCancelChange += Events_OnProjectCancelChange;
        }

        private void Events_OnProjectCancelChange()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void Events_OnProjectSaveChange()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void ObserverBehavior_Change()
        {            
            AssociatedObject.IsEnabled = true;
        }
        
        protected override void OnDetaching()
        {
            Events.OnProjectChange -= ObserverBehavior_Change;
            Events.OnProjectSaveChange -= Events_OnProjectSaveChange;
            Events.OnProjectCancelChange -= Events_OnProjectCancelChange;
        }
    }
}
