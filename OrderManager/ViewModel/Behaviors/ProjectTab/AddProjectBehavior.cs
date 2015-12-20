﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ProjectTab
{
    public class AddProjectBehavior : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            var b = e.OriginalSource as Button;
            var newProject = b.DataContext as Model.Project;

            DB.Context.Projects.Add(newProject);
            DB.Context.SaveChanges();
            
            Events.AddProject();
            Events.ProjectSaveChage();

            try
            {
                Application.Current.Windows.OfType<View.CreateProject>().Single().Close();
            }
            catch { }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }        
    }
}
