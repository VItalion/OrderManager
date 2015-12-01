using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderManager.ViewModel
{
    class OrderViewModel
    {
        public Command CreateProject { get; set; }
        public Command DeleteProject { get; set; }

        public OrderViewModel()
        {
            CreateProject = new Command(ToCreate);
            DeleteProject = new Command((o) => System.Windows.MessageBox.Show($"param - {o.ToString()}")); 
        }
        View.CreateProject cp { get; set; }
                        
        private void ToCreate(object o)
        {
            cp = new View.CreateProject();
            cp.DataContext = new ViewModel.DataContext();
            cp.Show();
        }
    }
}
