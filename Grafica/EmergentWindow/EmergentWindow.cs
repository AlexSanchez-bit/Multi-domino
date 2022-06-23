using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using System.Collections;
using System.Collections.Generic;
namespace Grafica
{
    public partial class EmergentWindow : Window
    {   
        private string message;
        public EmergentWindow(string message)
        {
            InitializeComponent();           
            this.Find<TextBlock>("text").Text=message;
        }

        public EmergentWindow():this("mensage random")
        {}   
        
        public void CloseWindow(object obj,RoutedEventArgs args)
        {          
            this.Close();
        }                           
    }
    
}
