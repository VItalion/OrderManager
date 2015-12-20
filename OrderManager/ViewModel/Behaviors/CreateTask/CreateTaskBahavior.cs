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
    public class CreateTaskBehavior : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            AssociatedObject.Click += AddTask;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            var b = e.OriginalSource as Button;
            var task = b.DataContext as Model.Task;

            var project = (ProjectControl.DataSource.Buffer != null) ? ProjectControl.DataSource.Buffer : ProjectControl.DataSource.SelectedProject;

            task.Project = project;
            if (project.Tasks == null)
                project.Tasks = new List<Model.Task>();
            project.Tasks.Add(task);
              
            Events.CreateTask(task);

            Application.Current.Windows.OfType<View.CreateTask>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AddTask;
        }
    }
}
