using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class PersonTreeViewBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {
            Events.OnPersonChange += OnPersonChangeEventHandler;
            Events.OnExecutorSaveCahnge += Events_OnExecutorSaveCahnge;
            Events.OnExecutorCancelChange += Events_OnExecutorCancelChange;
        }

        private void Events_OnExecutorCancelChange()
        {
            AssociatedObject.IsEnabled = true;

            ExecutorTab.SelectedExecutor.Executor = DB.Context.Executors.Where(e => e.Id == ExecutorTab.SelectedExecutor.Executor.Id).Single();
        }

        private void Events_OnExecutorSaveCahnge(Model.Executor obj)
        {
            AssociatedObject.IsEnabled = true;

            var executor = DB.Context.Executors.Where(e => e.Id == obj.Id).Single();
            executor.FullName = obj.FullName;
            executor.Email = obj.Email;
            executor.PhoneNumber = obj.PhoneNumber;
            if (obj.Photo != null)
            {
                //executor.Photo = new byte[obj.Photo.Length];
                obj.Photo.CopyTo(executor.Photo, 0);
            }
            executor.Skype = obj.Skype;
            executor.Tasks = new List<Model.Task>(obj.Tasks);

            DB.Context.SaveChanges();
        }

        private void OnPersonChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        protected override void OnDetaching()
        {
            Events.OnPersonChange -= OnPersonChangeEventHandler;
            Events.OnExecutorSaveCahnge -= Events_OnExecutorSaveCahnge;
            Events.OnExecutorCancelChange -= Events_OnExecutorCancelChange;
        }
    }
}
