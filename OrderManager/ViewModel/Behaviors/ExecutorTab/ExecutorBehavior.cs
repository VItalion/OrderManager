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

namespace OrderManager.ViewModel.Behaviors.ExecutorTab
{
    class ExecutorBehavior : Behavior<TreeViewItem>
    {
        protected override void OnAttached()
        {            
           // AssociatedObject.Selected += SelectExecutor;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.PreviewMouseLeftButtonDown += GeneralInformation;
            /*Events.OnExecutorSaveCahnge += OnExecutorSaveChangeEventHandler;
            Events.OnExecutorCancelChange += OnExecutorCancelChangeEventHandler;
            Events.OnCreateExecutor += OnCreateExecutorEventHandler;
            Events.OnDeleteExecutor += OnDeleteExecutorEventHandler;*/
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.DataContext = DB.Context.Executors.ToList();
            Update();
        }

        private void GeneralInformation(object sender, MouseButtonEventArgs e)
        {
            Events.ShowExecutorInformation();
        }

        /*private void OnDeleteExecutorEventHandler(Executor obj)
        {
            var executor = DB.Context.Executors.Where(e => e.Id == obj.Id).Single();

            DB.Context.Executors.Remove(executor);
            DB.Context.SaveChanges();

            AssociatedObject.DataContext = DB.Context.Executors.ToList();            
        }

        private void OnExecutorCancelChangeEventHandler()
        {
            var p = AssociatedObject.Parent as TreeView;
            var current = p.SelectedItem as Executor;

            var data = DB.Context.Executors.Where((e) => e.Id == current.Id).Single();
            current = data;

            AssociatedObject.IsEnabled = true;
        }

        private void SelectExecutor(object sender, RoutedEventArgs e)
        {
            var p = AssociatedObject.Parent as TreeView;
            var current = p.SelectedItem as Executor;

            Events.SelectExecutor(current);
        }

        private void OnCreateExecutorEventHandler(Executor obj)
        {
            DB.Context.Executors.Add(obj);
            DB.Context.SaveChanges();

            AssociatedObject.DataContext = DB.Context.Executors.ToList();
            Events.ExecutorSaveChange(obj);         
        }

        private void OnExecutorSaveChangeEventHandler(Executor current)
        {
            var data = DB.Context.Executors.Where(e => e.Id == current.Id).Single();
            data.FullName = current.FullName;
            data.Email = current.Email;
            data.PhoneNumber = current.PhoneNumber;
            data.Skype = current.Skype;
            current.Photo.CopyTo(data.Photo, 0);

            if (current.Tasks != null)
                data.Tasks = new List<Model.Task>(current.Tasks);

            DB.Context.SaveChanges();

            AssociatedObject.IsEnabled = true;            
        }*/

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;

            /*Events.OnExecutorSaveCahnge -= OnExecutorSaveChangeEventHandler;
            Events.OnExecutorCancelChange -= OnExecutorCancelChangeEventHandler;
            Events.OnCreateExecutor -= OnCreateExecutorEventHandler;
            Events.OnDeleteExecutor -= OnDeleteExecutorEventHandler;*/
        }

        private void Update()
        {
            AssociatedObject.Items.Clear();
            
            foreach (var executor in DB.Context.Executors)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = executor.FullName;
                item.PreviewMouseLeftButtonDown += SelectExecutor;
                item.PreviewMouseRightButtonDown += SelectData;
                
                if (executor.Tasks != null)
                    foreach (var task in executor.Tasks)
                    {
                        TreeViewItem taskItem = new TreeViewItem();
                        taskItem.Header = task.Name;
                        item.Items.Add(taskItem);
                    }

                item.DataContext = executor;
                
                AssociatedObject.Items.Add(item);
            }
        }

        private void SelectData(object sender, MouseButtonEventArgs e)
        {
            SelectedExecutor.Executor = AssociatedObject.DataContext as Executor;
        }

        private void SelectExecutor(object sender, MouseButtonEventArgs e)
        {
            var item = sender as TreeViewItem;
            var data = item.DataContext as Model.Executor;
            Events.SelectExecutor(data);
        }        
    }
}
