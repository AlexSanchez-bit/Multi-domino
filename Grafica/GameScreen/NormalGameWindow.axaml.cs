using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
namespace Grafica
{
    public partial class NormalGameWindow : Window,ITemporalWindow
    {      
        public NormalGameWindow()
        {
            InitializeComponent();           
            PrintKey();
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
             

        public void PrintKey()
        {
            
            var maincanvas = this.Get<Canvas>("tablero");
            Rectangle rect = new Rectangle(){
                Width=200,
                Height=100,            
            };
             
             maincanvas.Children.Add(rect);
        }


        #region funcionamiento domino

            

         #endregion 

    }
    
}
