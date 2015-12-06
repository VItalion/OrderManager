using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class SaveChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            ProjectControl.SaveChangeBehavior.SaveChange += ChangeSaved;
        }

        private void ChangeSaved()
        {
            AssociatedObject.IsEnabled = false;
        }

        protected override void OnDetaching()
        {
            ProjectControl.SaveChangeBehavior.SaveChange -= ChangeSaved;
        }
    }
}
