using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class CancelChangeProjectBehavior : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            AssociatedObject.Click += CancelChangeEventHandler;

            Events.OnProjectChange += ObserverBehavior_Change;
            Events.OnProjectSaveChange += Events_OnProjectSaveChange;
            Events.OnProjectCancelChange += Events_OnProjectCancelChange;
        }

        private void CancelChangeEventHandler(object sender, RoutedEventArgs e)
        {
            Events.ProjectCancelChange();
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
            AssociatedObject.Click -= CancelChangeEventHandler;

            Events.OnProjectChange -= ObserverBehavior_Change;
            Events.OnProjectSaveChange -= Events_OnProjectSaveChange;
            Events.OnProjectCancelChange -= Events_OnProjectCancelChange;
        }
    }
}
