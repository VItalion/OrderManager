using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class TreeViewProjectBehavior : Behavior<TreeViewItem>
    {
        //public delegate System.Threading.Tasks.Task SelectedProjectEventDelegate(Project project);
        //public static event Func<Project, System.Threading.Tasks.Task> ProjectSelect;
        

        protected override void OnAttached()
        {
            AssociatedObject.Selected += SelectProject;

            Events.OnAddProject += AddProjectEventHandler;
            Events.OnDeleteProject += OnDeleteProjectEventHandler;
            Events.OnChange += ChangeEventHandler;

            ProjectControl.SaveChangeBehavior.SaveChange += SaveChangeEventHandler;
            CancelChangeProjectBehavior.CancelChange += CancelCahngeEventHandler;
            CreateTask.CancelTaskBehavior.OnCancel += CancelCahngeEventHandler;
        }

        private void OnDeleteProjectEventHandler(List<Project> obj)
        {
            AssociatedObject.DataContext = obj;
        }

        private void AddProjectEventHandler()
        {
            using (var context = new DataContext())
            {
                AssociatedObject.DataContext = context.Projects.ToList();
            }
            AssociatedObject.IsEnabled = true;
        }

        private void SelectProject(object sender, RoutedEventArgs e)
        {
            var projectTreeViewItem = sender as TreeViewItem;
            var context = projectTreeViewItem.Parent as TreeView;
            var data = context.SelectedItem as Model.Project;
            
            Events.SelectProject(data);
            //Events.ProjectSelect(data);
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

            Events.OnAddProject -= AddProjectEventHandler;
            Events.OnDeleteProject -= OnDeleteProjectEventHandler;
            Events.OnChange -= ChangeEventHandler;

            ProjectControl.SaveChangeBehavior.SaveChange -= SaveChangeEventHandler;
            CancelChangeProjectBehavior.CancelChange -= CancelCahngeEventHandler;                        
            CreateTask.CancelTaskBehavior.OnCancel -= CancelCahngeEventHandler;
        }
    }
}
