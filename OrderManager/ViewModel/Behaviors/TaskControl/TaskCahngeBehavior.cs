using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TaskControl
{
    class TaskCahngeBehavior : Behavior<View.TaskControl>
    {
        protected override void OnAttached()
        {
            AssociatedObject.KeyDown += ControlCahnge;
        }

        private void ControlCahnge(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Events.TaskChange();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyDown -= ControlCahnge;
        }
    }
}
