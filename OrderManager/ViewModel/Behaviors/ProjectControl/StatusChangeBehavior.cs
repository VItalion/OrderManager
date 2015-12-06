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
    class StatusChangeBehavior : Behavior<ComboBox>
    {        
        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += StatusChange;
            AssociatedObject.DataContextChanged += AssociatedObject_DataContextChanged;
        }

        private void AssociatedObject_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var cb = sender as ComboBox;
                var data = SelectedDataContext.Project;
                cb.SelectedItem = data.Status;
            }
            catch { }
        }

        private void StatusChange(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            var data = cb.DataContext as Model.Project;

            if (data.Status != cb.SelectedValue.ToString())
                Events.Change();

            data.Status = cb.SelectedValue.ToString();

            var context = new DataContext();
            try
            {
                var project = (from p in context.Projects
                               where p.Id == data.Id
                               select p).Single();

                project.Status = data.Status;
            }
            catch { }
            finally
            {
                context.Dispose();
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= StatusChange;
        }
    }
}
