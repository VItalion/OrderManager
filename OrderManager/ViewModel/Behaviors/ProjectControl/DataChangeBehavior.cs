using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class DataChangeBehavior : Behavior<Calendar>
    {
        protected override void OnAttached()
        {           
            AssociatedObject.SelectedDatesChanged += DateChange;
        }

        private void DateChange(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            var data = calendar.DataContext as Model.Project;

            try
            {                
                data.DateOfCompletion = (DateTime)calendar.SelectedDate;
                calendar.DisplayDate = data.DateOfCompletion;
            }
            catch { }

            try
            {
                var project = DB.Context.Projects.Where(p => p.Id == data.Id).Single();

                if (project.DateOfCompletion != data.DateOfCompletion)
                    Events.ProjectChange();

                project.DateOfCompletion = data.DateOfCompletion;
            }
            catch { }            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectedDatesChanged -= DateChange;
        }
    }
}
