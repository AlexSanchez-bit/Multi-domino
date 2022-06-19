using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
namespace Grafica
{
    public partial class PrefabsWindow : Window,ITemporalWindow
    {      
        public PrefabsWindow()
        {
            InitializeComponent();           
        }

        Window original;
        public void GoToNextWindow(Window original)
        {
            this.original=original;
            original.Hide();
            this.Show();
        }

   public void GoBack(object obj,RoutedEventArgs args)
        {
           ReturnToOriginal();
        }
        public void ReturnToOriginal()
        {
            original.Show();
            this.Close();
        }
    }
    
}
