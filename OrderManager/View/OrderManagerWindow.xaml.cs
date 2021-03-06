﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManager.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class OrderManagerWindow : Window
    {
        public OrderManagerWindow()
        {
            InitializeComponent();

            using (var context = new ViewModel.DataContext())
            {
                projectTree.DataContext = context.Projects.ToList();
            }

            //CommandBinding bind = new CommandBinding(ApplicationCommands.New);
            //bind.Executed += Bind_Executed;
            //CommandBindings.Add(bind);
        }       
    }
}
