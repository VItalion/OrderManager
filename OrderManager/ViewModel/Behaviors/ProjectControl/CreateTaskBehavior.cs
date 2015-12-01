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
        public static event Action Change;
        protected override void OnAttached()
        {
            CreateTask.CreateTaskBehavior.OnCreateTask += OnCreateTaskEventHandler;
        }

        private void OnCreateTaskEventHandler(Model.Task obj)
        {
            AssociatedObject.Items.Add(obj.Name);

            if (Change != null)
                Change();
        }

        protected override void OnDetaching()
        {
            CreateTask.CreateTaskBehavior.OnCreateTask -= OnCreateTaskEventHandler;
        }
    }
}
