using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.TaskControl
{
    class ExecutorNameBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.KeyDown += ChangeExecutorName;
        }

        private void ChangeExecutorName(object sender, KeyEventArgs e)
        {
            var t = sender as TextBox;
            var data = t.DataContext as Model.Task;

            if (data.Executor == null)
                data.Executor = new Model.Executor();

            data.Executor.FullName = t.Text;
            //System.Windows.MessageBox.Show(data.Executor.FullName);
        }
    }
}
