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
    class NewProjectBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += NewProject;
        }

        private void NewProject(object sender, RoutedEventArgs e)
        {
            View.CreateProject cp = new View.CreateProject();
            cp.DataContext = new Model.Project();
            cp.Show();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= NewProject;
        }
    }
}
