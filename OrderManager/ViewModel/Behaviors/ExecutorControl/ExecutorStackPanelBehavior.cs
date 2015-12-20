using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class ExecutorStackPanelBehavior : Behavior<StackPanel>
    {
        protected override void OnAttached()
        {
            Events.OnSelectExecutor += OnSelectExecutorEventHandler;
            Events.OnExecutorCancelChange += OnCancelChange;

            Events.OnShowExecutorInformation += ShowExecotorGlobalInformation;
        }

        private void ShowExecotorGlobalInformation()
        {
            List<Executor> list = new List<Executor>();
            foreach (var executor in DB.Context.Executors)
            {
                list.Add(new Executor() { FullName = executor.FullName, Email = executor.Email, Skype = executor.Skype });
            }

            if (list.Count != 0)
            {
                DataGrid grid = new DataGrid();
                grid.IsReadOnly = true;
                grid.ItemsSource = list;
                AssociatedObject.Children.Clear();
                AssociatedObject.Children.Add(grid);
            }
            else
            {
                TextBlock tb = new TextBlock();
                tb.Text = "Исполнители отсутствуют";
                AssociatedObject.Children.Clear();
                AssociatedObject.Children.Add(tb);
            }
        }

        private void OnCancelChange()
        {
            AssociatedObject.Children.Clear();

            var control = new View.ExecutorPanel();
            control.DataContext = ExecutorTab.SelectedExecutor.Executor;

            var data = DB.Context.Executors.Where((e) => e.Id == ExecutorTab.SelectedExecutor.Executor.Id).Single();
            control.DataContext = data;
            
            AssociatedObject.Children.Add(control);
        }

        private async void OnSelectExecutorEventHandler(Model.Executor obj)
        {
            AssociatedObject.Children.Clear();

            var control = new View.ExecutorPanel();
            AssociatedObject.Children.Add(control);

            await System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(()=> 
                {
                    var data = new Model.Executor();
                    data.Id = obj.Id;
                    data.FullName = obj.FullName;
                    data.Email = obj.Email;
                    data.PhoneNumber = obj.PhoneNumber;
                    data.Skype = obj.Skype;
                    data.Tasks = new List<Model.Task>(obj.Tasks);
                    if (obj.Photo != null)
                    {
                        data.Photo = new byte[obj.Photo.Length];
                        obj.Photo.CopyTo(data.Photo, 0);
                    }

                    control.DataContext = data;
                });                      
            });            
        }

        protected override void OnDetaching()
        {
            Events.OnSelectExecutor -= OnSelectExecutorEventHandler;
            Events.OnExecutorCancelChange -= OnCancelChange;

            Events.OnShowExecutorInformation -= ShowExecotorGlobalInformation;
        }
    }

    class Executor
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
    }
}
