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
    class DeleteProjectBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += DeleteProject;
        }

        private void DeleteProject(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ProjectControl.SelectedDataContext.Project.Name);
            var context = new DataContext();
            try
            {
                var project = (from p in context.Projects
                               where p.Id == ProjectControl.DataSource.SelectedProject.Id
                               select p).Single();
                context.Projects.Remove(project);
                context.SaveChanges();

                //AssociatedObject.DataContext = context.Projects.ToList();
                Events.DeleteProject(project);
            }
            catch
            {
                Events.ProjectSaveChage();
            }      
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= DeleteProject;
        }
    }
}
