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
            Events.OnChange += ObserverBehavior_Change;
        }
        
        private void ObserverBehavior_Change()
        {            
            AssociatedObject.IsEnabled = true;
        }
        
        protected override void OnDetaching()
        {
            Events.OnChange -= ObserverBehavior_Change;
        }
    }
}
