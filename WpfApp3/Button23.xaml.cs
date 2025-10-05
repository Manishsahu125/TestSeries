using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Button23.xaml
    /// </summary>
    public partial class Button23 : UserControl
    {
        public event EventHandler buttonclick;
        
        
        public Button23()
        {
            InitializeComponent();
            q1.Click+= q1_Click;
        }
        
        private void q1_Click(object sender, RoutedEventArgs e)
        {   
            buttonclick?.Invoke(this, EventArgs.Empty);  
            
            
        }
        public Button content
        {
            get { return (Button)q1.Content; }
            set
            {
                q1.Content = value;
            }
        }
            

    }
}
