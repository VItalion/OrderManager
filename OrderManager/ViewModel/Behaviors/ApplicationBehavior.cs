using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors
{
    class ApplicationBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Closed += AssociatedObject_Closed;
        }

        private void AssociatedObject_Closed(object sender, EventArgs e)
        {
            DB.Context.Dispose();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Closed -= AssociatedObject_Closed;
        }
    }
}
