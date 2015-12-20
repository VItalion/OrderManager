using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrderManager.ViewModel.Behaviors.CustomerControl
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
            if (CustomerTab.SelectedCustomer.Current != null)
            {
                MemoryStream ms = new MemoryStream(CustomerTab.SelectedCustomer.Current.Photo);
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
                finally
                {
                    ms.Dispose();
                }
            }            
        }

        private void PhotoChangeEventHandler(string obj)
        {
            if ((obj != null) && (obj != ""))
            {
                byte[] buffer = File.ReadAllBytes(obj);
                CustomerTab.SelectedCustomer.Current.Photo = buffer;
                AssociatedObject.DataContext = buffer;
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
