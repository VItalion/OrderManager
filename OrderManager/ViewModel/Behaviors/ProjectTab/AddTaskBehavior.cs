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
    class AddTaskBehavior : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            AssociatedObject.Click += AddTask;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            View.CreateTask ct = new View.CreateTask();
            ct.DataContext = new Model.Task() { Project = AssociatedObject.DataContext as Model.Project, DateOfCompletion = DateTime.Now };
            ct.ShowDialog();
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AddTask;
        }
    }
}
