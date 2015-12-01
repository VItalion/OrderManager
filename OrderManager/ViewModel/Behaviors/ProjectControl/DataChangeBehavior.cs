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
        public static event Action Change;

        protected override void OnAttached()
        {           
            AssociatedObject.SelectedDatesChanged += DateChange;
        }

        private void DateChange(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            var data = calendar.DataContext as Model.Project;           
            data.DateOfCompletion = (DateTime)calendar.SelectedDate;
            calendar.DisplayDate = data.DateOfCompletion;

            using (var context = new DataContext())
            {
                var project = (from p in context.Projects
                               where p.Id == data.Id
                               select p).Single();

                if (project.DateOfCompletion != data.DateOfCompletion)
                    if (Change != null)
                        Change();

                project.DateOfCompletion = data.DateOfCompletion;
            }            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectedDatesChanged -= DateChange;
        }
    }
}
