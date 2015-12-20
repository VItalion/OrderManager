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
            AssociatedObject.PreviewMouseLeftButtonDown += CreateNewTab;
            Events.OnCreateProjectTab += CreteProjectTabEventHandler;
            Events.OnCreatePersonTab += CreatePersonTabEventHandler;
        }

        private void CreatePersonTabEventHandler()
        {
            TabItem ti = new TabItem();
            ti.Content = new View.PersonTab();
            ti.Header = "Персоны";
            var tabControl = AssociatedObject.Parent as TabControl;
            tabControl.Items.Insert(tabControl.Items.Count - 1, ti);
        }

        private void CreteProjectTabEventHandler()
        {
            TabItem ti = new TabItem();
            ti.Content = new View.ProjectTab();
            ti.Header = "Проекты";
            var tabControl = AssociatedObject.Parent as TabControl;
            tabControl.Items.Insert(tabControl.Items.Count - 1, ti);
        }

        private void CreateNewTab(object sender, MouseButtonEventArgs e)
        {
            View.SelectTabType sb = new View.SelectTabType();
            sb.ShowDialog();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewMouseLeftButtonDown -= CreateNewTab;
            Events.OnCreateProjectTab -= CreteProjectTabEventHandler;
            Events.OnCreatePersonTab -= CreatePersonTabEventHandler;
        }
    }
}
