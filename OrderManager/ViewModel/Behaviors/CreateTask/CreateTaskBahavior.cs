﻿using System;
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
        public static event Action<Model.Task> OnCreateTask;
        protected override void OnAttached()
        {
            AssociatedObject.Click += AddTask;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            var b = e.OriginalSource as Button;
            var task = b.DataContext as Model.Task;
            task.Id++;
                        
            using (var context = new DataContext())
            {
                var project = (from p in context.Projects
                               where p.Id == ProjectControl.SelectedDataContext.Project.Id
                               select p).Single();

                if (project.Tasks == null)
                    project.Tasks = new List<Model.Task>();
                project.Tasks.Add(task);
                context.SaveChanges();
            }
                if (OnCreateTask != null)
                    OnCreateTask(task);

            Application.Current.Windows.OfType<View.CreateTask>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AddTask;
        }
    }
}
