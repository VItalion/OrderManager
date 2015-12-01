using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors
{
    class ChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ProjectControl.TextBoxBehavior.Change += ObserverBehavior_Change;
        }

        private void ObserverBehavior_Change()
        {            
            AssociatedObject.IsEnabled = true;
        }
        
        protected override void OnDetaching()
        {
            ProjectControl.TextBoxBehavior.Change -= ObserverBehavior_Change;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
