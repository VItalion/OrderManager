using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class CreateTaskBehavior : Behavior<ListBox>
    {        
        protected override void OnAttached()
        {
            Events.OnCreateTask += OnCreateTaskEventHandler;
        }

        private void OnCreateTaskEventHandler(Model.Task obj)
        {
            if (DataSource.Buffer == null)
            {
                if (obj.Project.Id == DataSource.SelectedProject.Id)
                {
                    ListBoxItem block = new ListBoxItem();
                    block.Content = obj.Name;                    
                    AssociatedObject.ItemsSource = DataSource.SelectedProject.Tasks.ToList();
                    Events.ProjectChange();
                }
            }
            else
            {
                if (obj.Project.Id == (AssociatedObject.DataContext as Project).Id)
                {
                    ListBoxItem block = new ListBoxItem();
                    block.Content = obj.Name;                    
                    AssociatedObject.ItemsSource = DataSource.Buffer.Tasks.ToList();
                    Events.ProjectChange();
                }
            }
        }

        protected override void OnDetaching()
        {
            Events.OnCreateTask -= OnCreateTaskEventHandler;
        }
    }
}
