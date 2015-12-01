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
            var b = e.OriginalSource as Button;
            var newProject = b.DataContext as Model.Project;

            using (var context = new DataContext())
            {
                //context.Projects.Add(newProject);
                context.Projects.Remove(context.Projects.Find(newProject.Id));
                context.Projects.Add(newProject);
                context.SaveChanges();
            }            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
    }
}
