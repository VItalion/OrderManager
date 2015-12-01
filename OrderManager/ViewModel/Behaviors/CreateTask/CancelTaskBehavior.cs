using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CreateTask
{
    public class CancelTaskBehavior : Behavior<Button>
    {
        public static event Action OnCancel;
        protected override void OnAttached()
        {
            AssociatedObject.Click += CloseWindow;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (OnCancel != null)
                OnCancel();
            Application.Current.Windows.OfType<View.CreateTask>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CloseWindow;
        }
    }
}
