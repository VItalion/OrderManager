using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TypeTab
{
    class ProjectTabBehavior : Behavior<Button> 
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += CreateProjectTab;
        }

        private void CreateProjectTab(object sender, RoutedEventArgs e)
        {
            Events.CreteProjectTab();
        }
                
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= CreateProjectTab;
        }
    }
}
