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
            var b = e.OriginalSource as Button;
            var collection = b.DataContext as TreeView;
           // var item = collection.CurrentItem as 
            var currents = collection.DataContext as List<Model.Project>;
            var current = currents[0];

            using (var context = new DataContext())
            {
                //context.Projects.Remove(context.Projects.Find(newProject.Id));
                //context.Projects.Add(newProject);
                var project = context.Projects.Find(current.Id);
                project.Name = current.Name;
                project.Executor = current.Executor;
                project.PlannedBudget = current.PlannedBudget;
                project.RealBudget = current.PlannedBudget;
                project.DateOfCompletion = current.DateOfCompletion;
                project.Status = current.Status;
                //project.Tasks = current.Tasks;
                //project.Customers = current.Customers;

                context.SaveChanges();
            }
            if (SaveChange != null)
                SaveChange();        
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
    }
}
