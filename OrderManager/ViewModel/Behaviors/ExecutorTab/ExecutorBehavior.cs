using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ExecutorTab
{
    class ExecutorBehavior : Behavior<TreeViewItem>
    {
        protected override void OnAttached()
        {            
            AssociatedObject.Selected += SelectExecutor;
            AssociatedObject.Loaded += AssociatedObject_Loaded;

            Events.OnExecutorSaveCahnge += OnExecutorSaveChangeEventHandler;
            Events.OnExecutorCancelChange += OnExecutorCancelChangeEventHandler;
            Events.OnCreateExecutor += OnCreateExecutorEventHandler;
            Events.OnDeleteExecutor += OnDeleteExecutorEventHandler;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new DataContext())
            {
                AssociatedObject.DataContext = context.Executors.ToList();
            }
        }

        private void OnDeleteExecutorEventHandler(Executor obj)
        {
            using (var context = new DataContext())
            {
                var executor = context.Executors.Where(e => e.Id == obj.Id).Single();

                context.Executors.Remove(executor);
                context.SaveChanges();

                AssociatedObject.DataContext = context.Executors.ToList();
            }
        }

        private void OnExecutorCancelChangeEventHandler()
        {
            var p = AssociatedObject.Parent as TreeView;
            var current = p.SelectedItem as Executor;

            using (var context = new DataContext())
            {
                var data = context.Executors.Where((e) => e.Id == current.Id).Single();
                current = data;
            }

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
             using (var context = new DataContext())
             {
                 context.Executors.Add(obj);
                 context.SaveChanges();

                 AssociatedObject.DataContext = context.Executors.ToList();
                 Events.ExecutorSaveChange(obj);
             }            
        }

        private void OnExecutorSaveChangeEventHandler(Executor current)
        {
            var context = new DataContext();
            try
            {
                var data = context.Executors.Where(e => e.Id == current.Id).Single();
                data = current;
                             
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
            }
            finally
            {
                context.Dispose();
                AssociatedObject.IsEnabled = true;
            }
        }

        protected override void OnDetaching()
        {
            Events.OnExecutorSaveCahnge -= OnExecutorSaveChangeEventHandler;
            Events.OnExecutorCancelChange -= OnExecutorCancelChangeEventHandler;
            Events.OnCreateExecutor -= OnCreateExecutorEventHandler;
            Events.OnDeleteExecutor -= OnDeleteExecutorEventHandler;
        }
    }
}
