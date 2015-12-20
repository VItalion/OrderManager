using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.ViewModel
{
    class DB
    {
        private static DataContext context;
        protected DB() { }
        public static DataContext Context
        {
            get
            {
                if (context == null)
                    context = new DataContext();
                return context;
            }
        }
    }
}
