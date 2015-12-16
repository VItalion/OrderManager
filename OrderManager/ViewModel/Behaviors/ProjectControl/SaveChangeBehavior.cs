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
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            var context = new DataContext();
            try
            {
                var b = e.OriginalSource as Button;
                var current = b.DataContext as Model.Project;
                var project = context.Projects.Where(p=>p.Id == current.Id).Single();
                
                context.Entry(project).State = System.Data.Entity.EntityState.Modified;             //Попытка сделать изминения вручную (провал)
                
                project = current;
                
                context.SaveChanges();
            }
            catch(Exception ex)
            {
               Console.WriteLine($"{ex.Source} exception: {ex.Message}");
            }
            finally { context.Dispose(); }

            Events.ProjectSaveChage(); 
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
    }
}
