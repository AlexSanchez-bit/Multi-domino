using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
namespace Grafica
{
    public partial class CustomizationWindow : Window,ITemporalWindow
    {      
        public CustomizationWindow()
        {
            InitializeComponent();           
        }
       
       Window parentWindow;
        public void GoToNextWindow(Window original)
        {
            parentWindow=original;
            original.Hide();
            this.Show();
        }

        
        public void ReturnToOriginal()
        {
            this.parentWindow.Show();
            this.Close();
        }
        public void GoBack(object obj,RoutedEventArgs args)
        {
           ReturnToOriginal();
        }
    }
    
}
