using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
namespace Grafica
{
    public partial class NormalGameWindow : Window,ITemporalWindow
    {      
        public NormalGameWindow()
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
    }
    
}
