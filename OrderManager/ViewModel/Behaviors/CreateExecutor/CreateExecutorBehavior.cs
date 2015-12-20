using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CreateExecutor
{
    class CreateExecutorBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += Create;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var executor = b.DataContext as Model.Executor;

            /* var project = (ProjectControl.DataSource.Buffer != null) ? ProjectControl.DataSource.Buffer : ProjectControl.DataSource.SelectedProject;

             foreach(var task in project.Tasks)
             {
                 executor.Id = task.Executor.Id;
                 task.Executor = executor;*/
            //ExecutorTab.SelectedExecutor.Executor = executor;
                Events.CreateExecutor(ExecutorTab.SelectedExecutor.Executor);
           // }            
            Application.Current.Windows.OfType<View.CreateExecutor>().Single().Close();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= Create;
        }
    }
}
