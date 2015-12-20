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
            using(MemoryStream ms = new MemoryStream((byte[])AssociatedObject.DataContext))
            {
                System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage();
                bi.BeginInit();                
                bi.StreamSource = ms;
                bi.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                bi.EndInit();

                AssociatedObject.Source = bi;
            }
        }

        private void PhotoChangeEventHandler(string obj)
        {
            byte[] buffer = File.ReadAllBytes(obj);

            MemoryStream ms = new MemoryStream(File.ReadAllBytes(obj));
            try
            {
                System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage();
                bi.BeginInit();                
                bi.StreamSource = ms;
                bi.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                bi.EndInit();
                                
                AssociatedObject.DataContext = buffer;                         

                Events.PersonChange();
            }
            catch { }
            finally
            {
                ms.Dispose();
            }
        }

        protected override void OnDetaching()
        {
            Events.OnPhotoCahnge -= PhotoChangeEventHandler;

            AssociatedObject.DataContextChanged -= AssociatedObject_DataContextChanged;
        }
    }
}
