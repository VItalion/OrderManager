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
            CreateTask.CreateTaskBehavior.OnCreateTask += OnCreateTaskEventHandler;
        }

        private void OnCreateTaskEventHandler(Model.Task obj)
        {
            ListBoxItem block = new ListBoxItem();
            block.Content = obj.Name;
            AssociatedObject.Items.Add(block);

            Events.Change();
        }

        protected override void OnDetaching()
        {
            CreateTask.CreateTaskBehavior.OnCreateTask -= OnCreateTaskEventHandler;
        }
    }
}
