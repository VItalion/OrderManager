using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.ViewModel.Behaviors.ExecutorTab
{
    static class SelectedExecutor
    {
        public static Model.Executor Executor { get; set; }
        public static Model.Executor Current { get; set; }
    }
}
