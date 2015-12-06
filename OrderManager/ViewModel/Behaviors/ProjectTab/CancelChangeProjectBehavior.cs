using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class CancelChangeProjectBehavior : Behavior<Button>
    {
        public static event Action CancelChange;
        protected override void OnAttached()
        {
            AssociatedObject.Click += CancelChangeEventHandler;
        }

        private void CancelChangeEventHandler(object sender, RoutedEventArgs e)
        {
            if (CancelChange != null)
                CancelChange();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CancelChangeEventHandler;
        }
    }
}
