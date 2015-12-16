using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TypeTab
{
    class TabBehavior : Behavior<TabItem>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += CreateNewTab;
        }

        private void CreateNewTab(object sender, MouseButtonEventArgs e)
        {
            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= CreateNewTab;
        }
    }
}
