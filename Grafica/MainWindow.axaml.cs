using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
namespace Grafica
{
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();           
        }

        public void button_Click(object obj,RoutedEventArgs args)
        {
            var button =(Button)obj;            
            Rectangle rect = this.FindControl<Rectangle>("rectangle");
            rect.Width=112;
            rect.Height=112;           
            button.Content="Hello Avalonia";
        }
    }
    
}