using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors
{
    class SelectProjectBehavior : Behavior<TreeViewItem>
    {
        public delegate System.Threading.Tasks.Task SelectedProjectEventDelegate(Project project);
        public static event SelectedProjectEventDelegate ProjectSelect;
        

        protected override void OnAttached()
        {
            AssociatedObject.Selected += SelectProject;
        }

        private void SelectProject(object sender, RoutedEventArgs e)
        {
            if (ProjectSelect != null)
            {
                var projectTreeViewItem = sender as TreeViewItem;
                var context = projectTreeViewItem.Parent as TreeView;
                var data = context.SelectedItem as Model.Project;

                ProjectControl.SelectedDataContext.Project = data;

                ProjectSelect(data);
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Selected -= SelectProject;
        }
    }
}
