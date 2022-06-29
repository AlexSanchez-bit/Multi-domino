using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Grafica
{
    public partial class NormalGameWindow : Window,ITemporalWindow
    {      
        int ways;
        (int,int) rightPos;
        (int,int) leftPos;
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
