using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.ViewModel.Behaviors.TaskControl
{
    class CurrentTask
    {
        public static Model.Task Task { get; set; }
        public static Model.Task Buffer { get; set; }
    }
}
