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
    class AddCustomerBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += AddCustomer;
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            View.CreateCustomer cc = new View.CreateCustomer();
            var customer = new Model.Customer() { Projects = new List<Model.Project>() };
            customer.Projects.Add(ProjectControl.DataSource.SelectedProject);
            cc.DataContext = customer;
            cc.ShowDialog();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AddCustomer;
        }
    }
}
