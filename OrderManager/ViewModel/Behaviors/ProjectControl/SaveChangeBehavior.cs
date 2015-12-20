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
        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;

            Events.OnProjectChange += ObserverBehavior_Change;
            Events.OnProjectSaveChange += Events_OnProjectSaveChange;
            Events.OnProjectCancelChange += Events_OnProjectCancelChange;
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                var b = e.OriginalSource as Button;
                var current = b.DataContext as Model.Project;
                var project = DB.Context.Projects.Where(p=>p.Id == current.Id).Single();
                
                project.Name = current.Name;
                project.Executor = current.Executor;
                project.PlannedBudget = current.PlannedBudget;
                project.RealBudget = current.RealBudget;
                project.Status = current.Status;
                project.Tasks = new List<Model.Task>(current.Tasks);
                project.DateOfCompletion = current.DateOfCompletion;
                project.Customers = new List<Model.Customer>(current.Customers);

                DB.Context.SaveChanges();
            }
            catch(Exception ex)
            {
               Console.WriteLine("{0} exception: {1}", ex.Source, ex.Message);
            }

            Events.ProjectSaveChage(); 
        }

        private void Events_OnProjectCancelChange()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void Events_OnProjectSaveChange()
        {
            AssociatedObject.IsEnabled = false;
        }

        private void ObserverBehavior_Change()
        {
            AssociatedObject.IsEnabled = true;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;

            Events.OnProjectChange -= ObserverBehavior_Change;
            Events.OnProjectSaveChange -= Events_OnProjectSaveChange;
            Events.OnProjectCancelChange -= Events_OnProjectCancelChange;
        }
    }
}
