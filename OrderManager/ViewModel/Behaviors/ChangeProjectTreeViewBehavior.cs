using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors
{
    class ChangeProjectTreeViewBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {
            ProjectControl.TextBoxBehavior.Change += ChangeEventHandler;
            ProjectControl.StatusChangeBehavior.Change += ChangeEventHandler;
            ProjectControl.DataChangeBehavior.Change += ChangeEventHandler;
            ProjectControl.SaveChangeBehavior.SaveChange += SaveChangeEventHandler;
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
            ProjectControl.TextBoxBehavior.Change -= ChangeEventHandler;
            ProjectControl.StatusChangeBehavior.Change -= ChangeEventHandler;
            ProjectControl.DataChangeBehavior.Change -= ChangeEventHandler;
            ProjectControl.SaveChangeBehavior.SaveChange -= SaveChangeEventHandler;
        }
    }
}
