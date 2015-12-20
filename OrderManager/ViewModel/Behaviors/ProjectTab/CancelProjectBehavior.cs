using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    public class CancelProjectBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += CloseWindow;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProjectControl.DataSource.Buffer.Tasks != null)
                    ProjectControl.DataSource.Buffer.Tasks.Clear();

                if (ProjectControl.DataSource.Buffer.Customers != null)
                    ProjectControl.DataSource.Buffer.Customers.Clear();

                ProjectControl.DataSource.Buffer = null;

                Events.ProjectCancelChange();
                Application.Current.Windows.OfType<View.CreateProject>().Single().Close();
            }
            catch
            {
                //Application.Current.Shutdown();
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CloseWindow;
        }
    }
}
