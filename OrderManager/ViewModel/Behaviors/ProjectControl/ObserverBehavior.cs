using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class ObserverBehavior : Behavior<View.ProjectControl>
    {        
        protected override void OnAttached()
        {           
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
        }

        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            Events.Change();
        }
                
        protected override void OnDetaching()
        {            
            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
        }        
    }
}
