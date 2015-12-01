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
    class TreeViewProjectBehavior : Behavior<TreeViewItem>
    {
        public delegate System.Threading.Tasks.Task SelectedProjectEventDelegate(Project project);
        public static event SelectedProjectEventDelegate ProjectSelect;
        

        protected override void OnAttached()
        {
            AssociatedObject.Selected += SelectProject;

            ProjectControl.TextBoxBehavior.Change += ChangeEventHandler;
            ProjectControl.StatusChangeBehavior.Change += ChangeEventHandler;
            ProjectControl.DataChangeBehavior.Change += ChangeEventHandler;
            ProjectControl.SaveChangeBehavior.SaveChange += SaveChangeEventHandler;
            ProjectControl.CreateTaskBehavior.Change += ChangeEventHandler;

            CancelChangeProjectBehavior.CancelChange += CancelCahngeEventHandler;
            CreateTask.CancelTaskBehavior.OnCancel += CancelCahngeEventHandler;
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

        private void SaveChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        private void ChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void CancelCahngeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Selected -= SelectProject;

            ProjectControl.TextBoxBehavior.Change -= ChangeEventHandler;
            ProjectControl.StatusChangeBehavior.Change -= ChangeEventHandler;
            ProjectControl.DataChangeBehavior.Change -= ChangeEventHandler;
            ProjectControl.SaveChangeBehavior.SaveChange -= SaveChangeEventHandler;
            CancelChangeProjectBehavior.CancelChange -= CancelCahngeEventHandler;
        }
    }
}
