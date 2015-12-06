using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class SaveChangeBehavior : Behavior<Button>
    {
        public static event Action SaveChange;
        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            var context = new DataContext();
            try
            {
                var b = e.OriginalSource as Button;
                var current = b.DataContext as Model.Project;

                var project = context.Projects.Include("Tasks").Where(p=>p.Id == current.Id).Single();
                project.Name = current.Name;
                project.Executor = current.Executor;
                project.PlannedBudget = current.PlannedBudget;
                project.RealBudget = current.RealBudget;
                project.DateOfCompletion = current.DateOfCompletion;
                project.Status = current.Status;
                project.Tasks = current.Tasks;
                //project.Customers = current.Customers;

                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Source} say: {ex.Message}");
            }
            finally { context.Dispose(); }            

            if (SaveChange != null)
                SaveChange();        
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
    }
}
