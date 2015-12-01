using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors
{
    class ProjcetControlBehavior : Behavior<View.ProjectControl>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += ProjectControlLoaded;
        }

        private void ProjectControlLoaded(object sender, RoutedEventArgs e)
        {
            var projectControl = sender as View.ProjectControl;

            SelectProjectBehavior.ProjectSelect += ProjectSelectedEventHandler;
            CreateCustomer.CreateCustomerBehavior.Created += CreateCustomerEventHandler;
        }

        private void CreateCustomerEventHandler(string obj)
        {
            MessageBox.Show("Customer created");
        }

        private async System.Threading.Tasks.Task ProjectSelectedEventHandler(Project obj)
        {
            new System.Threading.Tasks.Task(() => 
            {
                System.Threading.Thread.Sleep(1000);
                Dispatcher.Invoke(() => AssociatedObject.DataContext = obj);
                //AssociatedObject.Dispatcher.Invoke(() => AssociatedObject.DataContext = obj, System.Windows.Threading.DispatcherPriority.Normal);
            }).Start();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= ProjectControlLoaded;
            SelectProjectBehavior.ProjectSelect -= ProjectSelectedEventHandler;
        }
    }
}
