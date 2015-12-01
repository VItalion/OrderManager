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
        public static event Action Change;

        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += StatusChange;
            AssociatedObject.DataContextChanged += AssociatedObject_DataContextChanged;
        }

        private void AssociatedObject_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            var data = cb.DataContext as Model.Project;
            cb.SelectedItem = data.Status;
        }

        private void StatusChange(object sender, SelectionChangedEventArgs e)
        {            
            var cb = sender as ComboBox;
            var data = cb.DataContext as Model.Project;

            if(data.Status!=cb.SelectedValue.ToString())
                if(Change!=null)
                    Change();

            data.Status = cb.SelectedValue.ToString();

            using (var context = new DataContext())
            {
                var project = (from p in context.Projects
                               where p.Id == data.Id
                               select p).Single();

                project.Status = data.Status;
            }            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= StatusChange;
        }
    }
}
