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
            
            using (var context = new DataContext())
            {
                var project = (from p in context.Projects
                                where p.Id == ProjectControl.SelectedDataContext.Project.Id
                                select p).Single();
                                
                task.Project = project;
                context.Tasks.Add(task);
                            
                context.SaveChanges();  
                ProjectControl.SelectedDataContext.Project = project;   
            }
            Events.CreateTask(task);

            Application.Current.Windows.OfType<View.CreateTask>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AddTask;
        }
    }
}
