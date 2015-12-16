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
            ListBoxItem block = new ListBoxItem();
            block.Content = obj.Name;
            using (var context = new DataContext())
            {
                AssociatedObject.ItemsSource = context.Projects.Where(p => p.Id == obj.Project.Id).Single().Tasks.ToList();
            }
            Events.ProjectChange();            
        }

        protected override void OnDetaching()
        {
            Events.OnCreateTask -= OnCreateTaskEventHandler;
        }
    }
}
