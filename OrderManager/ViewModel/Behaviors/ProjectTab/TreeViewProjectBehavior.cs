using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class TreeViewProjectBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {            
            AssociatedObject.Loaded += AssociatedObject_Loaded;

            Events.OnAddProject += AddProjectEventHandler;
            Events.OnDeleteProject += OnDeleteProjectEventHandler;
            Events.OnProjectChange += ChangeEventHandler;
            Events.OnCreateTask += OnCreateTaskEventHandler;
            Events.OnProjectSaveChange += SaveChangeEventHandler;
            Events.OnProjectCancelChange += CancelCahngeEventHandler;            
        }

        private void OnCreateTaskEventHandler(Model.Task obj)
        {            
            Update();
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
            Events.ShowProjectInformation();
        }

        private void SelectProject(object sender, MouseButtonEventArgs e)
        {
            var data = (sender as TreeViewItem).DataContext as Model.Project;
            Events.SelectProject(data);
        }

        private void OnDeleteProjectEventHandler(Model.Project obj)
        {
            Update();
        }

        private void AddProjectEventHandler()
        {            
            Update();
        }
        
        private void SaveChangeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
            
            Update();
        }

        private void ChangeEventHandler()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void CancelCahngeEventHandler()
        {
            AssociatedObject.IsEnabled = true;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;

            Events.OnAddProject -= AddProjectEventHandler;
            Events.OnDeleteProject -= OnDeleteProjectEventHandler;
            Events.OnProjectChange -= ChangeEventHandler;
            Events.OnCreateTask -= OnCreateTaskEventHandler;
            Events.OnProjectSaveChange -= SaveChangeEventHandler;
            Events.OnProjectCancelChange -= CancelCahngeEventHandler;            
        }

        //Обновление содержимого дерева проектов
        private void Update()
        {
            AssociatedObject.Items.Clear();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Проекты";
            textBlock.MouseLeftButtonDown += GeneralInformation;
            AssociatedObject.Items.Add(textBlock);
            foreach (var project in DB.Context.Projects)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = project.Name;
                TextBlock tb = new TextBlock();
                tb.Text = project.Executor;
                tb.MouseLeftButtonDown += ExecutorSelect;
                tb.MouseRightButtonDown += SelectData;
                item.Items.Add(tb);
                if (project.Tasks != null)
                    foreach (var task in project.Tasks)
                    {
                        TreeViewItem taskItem = new TreeViewItem();
                        taskItem.Header = task.Name;
                        item.Items.Add(taskItem);
                    }
                item.DataContext = project;
                item.PreviewMouseLeftButtonDown += SelectProject;
                item.PreviewMouseRightButtonDown += SelectData;
                AssociatedObject.Items.Add(item);
            }
        }

        private void SelectData(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var tb = sender as TextBlock;
                var data = tb.DataContext as Model.Project;
                ProjectControl.DataSource.SelectedProject = data;
            }
            catch
            {
                var tb = sender as TreeViewItem;
                var data = tb.DataContext as Model.Project;
                ProjectControl.DataSource.SelectedProject = data;
            }            
        }

        private void GeneralInformation(object sender, MouseButtonEventArgs e)
        {
            Events.ShowProjectInformation();
        }

        private void ExecutorSelect(object sender, MouseButtonEventArgs e)
        {
            var tb = sender as TextBlock;
            var executor = DB.Context.Executors.Where(ex => ex.FullName == tb.Text).SingleOrDefault();
            if (executor == null)
            {
                MessageBox.Show("Такого исполнителя не существует!");

                Events.ShowProjectInformation();
                return;
            }
            Events.SelectExecutor(executor);            
        }
    }
}
