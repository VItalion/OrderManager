using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class ProjcetControlBehavior : Behavior<View.ProjectControl>
    {
        protected override void OnAttached()
        {            
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
        }

        private void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Events.ProjectChange();
        }
         
        protected override void OnDetaching()
        {            
            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
        }
    }
}
