using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        //private object q;


        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void ADD(object sender, RoutedEventArgs e)
        {
            try {
                string path = "C:\\Users\\Mainsh\\source\\repos\\WpfApp3\\myfile.txt";
                List<question> oa = new List<question>();
                //string exit = File.ReadAllLines(path);
                string ex = File.ReadAllText(path);

                if (!string.IsNullOrEmpty(ex))
                {
                    oa = JsonConvert.DeserializeObject<List<question>>(ex);
                }
                question q = new question()
                {
                    Ques = quesTxt.Text,
                    opt1 = option1.Text,
                    opt2 = option2.Text,
                    opt3 = option3.Text,
                    opt4 = option4.Text,
                    sol = Solution.Text
                };
                oa.Add(q);
                string Update = JsonConvert.SerializeObject(oa);
                File.WriteAllText(path, Update);

                string str = File.ReadAllText(path);
                MessageBox.Show(str);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

              

            
           
            
            
            }
        

        }


    

}
