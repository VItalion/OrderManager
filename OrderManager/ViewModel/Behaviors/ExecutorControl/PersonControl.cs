using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class PersonControl : Behavior<UserControl>
    {
        protected override void OnAttached()
        {
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.DataContext == null)
                AssociatedObject.DataContext = new object();

            if (AssociatedObject.DataContext.GetType() == typeof(Model.Executor))
                ExecutorTab.SelectedExecutor.Executor = AssociatedObject.DataContext as Model.Executor;
            else if (AssociatedObject.DataContext.GetType() == typeof(Model.Customer))
                CustomerTab.SelectedCustomer.Customer = AssociatedObject.DataContext as Model.Customer;
        }

        private void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Events.PersonChange();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
