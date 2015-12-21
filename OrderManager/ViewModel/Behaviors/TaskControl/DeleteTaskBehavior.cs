using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TaskControl
{
    class DeleteTaskBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += DeleteTask;
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            if (CurrentTask.Task == null)
            {
                MessageBox.Show("Перед удалинем нужно выбрать задачу.");
            }
            else
            {
                DB.Context.Tasks.Remove(CurrentTask.Task);
                DB.Context.SaveChanges();

                Events.UpdateProject(ProjectControl.DataSource.SelectedProject);
                Events.ProjectSaveChage();
            }            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= DeleteTask;
        }
    }
}
