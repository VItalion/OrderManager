using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class ProjectCreateBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += CreateProject;
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var data = b.DataContext as Model.Project;

            DB.Context.Projects.Add(data);            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CreateProject;
        }
    }
}
