using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.ExecutorControl
{
    class ImageBehavior : Behavior<Image>
    {
        protected override void OnAttached()
        {
            Events.OnPhotoCahnge += PhotoChangeEventHandler;

            AssociatedObject.DataContextChanged += AssociatedObject_DataContextChanged;
        }

        private void AssociatedObject_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (ExecutorTab.SelectedExecutor.Current != null)
                if (ExecutorTab.SelectedExecutor.Current.Photo != null)
                {
                    MemoryStream ms = new MemoryStream(ExecutorTab.SelectedExecutor.Current.Photo);
                    try
                    {
                        System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = ms;
                        bi.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                        bi.EndInit();

                        AssociatedObject.Source = bi;
                    }
                    catch { }
                    finally { ms.Dispose(); }
                }      
        }

        private void PhotoChangeEventHandler(string obj)
        {
            if((obj != null) && (obj != ""))
            {
                byte[] buffer = File.ReadAllBytes(obj);
                AssociatedObject.DataContext = buffer;                
                ExecutorTab.SelectedExecutor.Current.Photo = new byte[buffer.Length];
                buffer.CopyTo(ExecutorTab.SelectedExecutor.Current.Photo, 0);
                Events.PersonChange();
            }                        
        }

        protected override void OnDetaching()
        {
            Events.OnPhotoCahnge -= PhotoChangeEventHandler;

            AssociatedObject.DataContextChanged -= AssociatedObject_DataContextChanged;
        }
    }
}
