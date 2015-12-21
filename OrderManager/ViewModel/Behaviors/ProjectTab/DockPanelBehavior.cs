using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class DockPanelBehavior : Behavior<DockPanel>
    {
        protected override void OnAttached()
        {
            Events.OnSelectProject += Events_OnSelectProject;
            Events.OnSelectTask += Events_OnSelectTask;
            Events.OnProjectCancelChange += OnCancelChangeEventHandler;
            Events.OnSelectExecutor += SelectExecutorEventHandler;
            Events.OnShowProjectInformation += OnShowInformationEventHandler;
            Events.OnUpdateProject += UpdateProject;
            Events.OnUpdateTask += UpdateTask;
        }

        private void UpdateTask(Model.Task obj)
        {
            AssociatedObject.Children.Clear();
            AssociatedObject.DataContext = null;
            View.TaskPanel control = new View.TaskPanel();
            control.DataContext = obj;
            AssociatedObject.Children.Add(control);  
        }

        private async void Events_OnSelectTask(Model.Task obj)
        {
            AssociatedObject.Children.Clear();
            AssociatedObject.DataContext = null;
            View.TaskPanel control = new View.TaskPanel();

            AssociatedObject.Children.Add(control);
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(() => { control.DataContext = obj; });
            });
        }

        private void UpdateProject(Model.Project obj)
        {
            AssociatedObject.Children.Clear();
            AssociatedObject.DataContext = null;
            View.ProjectPanel control = new View.ProjectPanel();
            control.DataContext = obj;
            AssociatedObject.Children.Add(control);            
        }

        //Вывод общих сведений
        private void OnShowInformationEventHandler()
        {
            List<Project> list = new List<Project>();            
            foreach(var project in DB.Context.Projects)
            {
                list.Add(new Project() { Name = project.Name, DateOfComplection = project.DateOfCompletion, Executor = project.Executor, Status = project.Status });
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
                tb.Text = "Проекты отсутствуют";
                AssociatedObject.Children.Clear();
                AssociatedObject.Children.Add(tb);
            }
        }

        //Загрузка данных исполнителя на форму с задержкой
        private async void SelectExecutorEventHandler(Model.Executor obj)
        {
            AssociatedObject.Children.Clear();
            AssociatedObject.DataContext = null;
            View.ExecutorPanel control = new View.ExecutorPanel();

            AssociatedObject.Children.Add(control);
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(() => { control.DataContext = obj; });                
            });
        }

        private void OnCancelChangeEventHandler()
        {
            AssociatedObject.Children.Clear();            
            View.ProjectPanel control = new View.ProjectPanel();
            control.DataContext = DB.Context.Projects.Where(p => p.Id == ProjectControl.DataSource.SelectedProject.Id).Single();
            AssociatedObject.Children.Add(control);
        }

        //Загрузка данных проекта на форму с задержкой
        private async void Events_OnSelectProject(Model.Project obj)
        {
            AssociatedObject.Children.Clear();
            AssociatedObject.DataContext = null;
            View.ProjectPanel control = new View.ProjectPanel();
            
            AssociatedObject.Children.Add(control);
            await Task.Run(() => 
            {
                System.Threading.Thread.Sleep(3000);
                Dispatcher.Invoke(()=> { control.DataContext = obj; });
            });
        }

        protected override void OnDetaching()
        {
            Events.OnSelectProject -= Events_OnSelectProject;
            Events.OnProjectCancelChange -= OnCancelChangeEventHandler;
            Events.OnSelectExecutor -= SelectExecutorEventHandler;
            Events.OnShowProjectInformation -= OnShowInformationEventHandler;
            Events.OnUpdateProject -= UpdateProject;
            Events.OnUpdateTask -= UpdateTask;
        }
    }

    public struct Project
    {
        public string Name { get; set; }
        public string Executor { get; set; }
        public DateTime DateOfComplection { get; set; }
        public string Status { get; set; }
    }
}
