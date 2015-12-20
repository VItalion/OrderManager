using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.ViewModel.Behaviors.ProjectControl
{
    class DataSource
    {
        public static Model.Project SelectedProject { get; set; }
        public static Model.Project Buffer { get; set; }
    }
}
