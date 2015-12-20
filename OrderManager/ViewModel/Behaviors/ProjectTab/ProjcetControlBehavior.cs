using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using OrderManager.Model;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    class ProjcetControlBehavior : Behavior<View.ProjectControl>
    {
        protected override void OnAttached()
        {            
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        //Выбор текущего проекта
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {            
            if(AssociatedObject.DataContext != null)
                if ((AssociatedObject.DataContext as Model.Project).Id == 0)
                    ProjectControl.DataSource.Buffer = AssociatedObject.DataContext as Model.Project;
                else
                    ProjectControl.DataSource.SelectedProject = AssociatedObject.DataContext as Model.Project;
        }

        private void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Events.ProjectChange();
        }
         
        protected override void OnDetaching()
        {            
            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
