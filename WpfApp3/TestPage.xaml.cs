using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Window
    {

        static string PauseFile1 = "C:\\Users\\Mainsh\\source\\repos\\WpfApp3\\pauseFiles.txt";
        List<pauseFile> pf = new List<pauseFile>();
        string pr = File.ReadAllText(PauseFile1);
        private DispatcherTimer timer;
         private TimeSpan duration = TimeSpan.FromHours(2);
        List<question> oa = new List<question>();

        static string P2 = "C:\\Users\\Mainsh\\source\\repos\\WpfApp3\\result.txt";
        List<result> SR = new List<result>();

        string Isreadresult = File.ReadAllText(P2);

        string xr = File.ReadAllText(P2);

        //result rs = new result();
        
        int countVisited = 0;
        int candidatePause = 0;

        public TestPage()
        {
            InitializeComponent();
            string Path = "C:\\Users\\Mainsh\\source\\repos\\WpfApp3\\myfile.txt";

            string ex = File.ReadAllText(Path);
            //string Isreadresult = File.ReadAllText(P2);
            if (!string.IsNullOrEmpty(pr)) {
                pf = JsonConvert.DeserializeObject<List<pauseFile>>(pr);
                duration = pf[0].pauseTime;
                //Answered.Content = pf[0].isasd.ToString();
            }
            if (!string.IsNullOrEmpty(ex))
            {
                oa = JsonConvert.DeserializeObject<List<question>>(ex);
            }
            if (!string.IsNullOrEmpty(Isreadresult))
            {
                SR = JsonConvert.DeserializeObject<List<result>>(Isreadresult);
            }
            
            
            // MessageBox.Show(oa[1].opt2);
            
            int count = oa.Count;
            //int c = 0;
            IsVisted.Content = "0";
            if (!string.IsNullOrEmpty(pr)) 
            {
                Answered.Content = pf[0].isasd.ToString();
            }
            else
            {
                Answered.Content = "0";
            }
            if (!string.IsNullOrEmpty(pr))
            {
                NotAnswered.Content = pf[0].Isnotasd.ToString();
            }
            else
            {
                NotAnswered.Content = oa.Count;
        
            }
            
            //MessageBox.Show(count.ToString());
            for (int i = 1; i <= count; i++)
            {

                Button23 m = new Button23();
                //c = c + 1;
                //vq.Content = c;
                //m.content = oa[i].ToString();
                //m.Content = oa[i];

                m.q1.Content = i.ToString();
                //df.Ques  = oa[i].ToString();
                // MessageBox.Show(df.Ques.ToString());

                Buttonpanel.Children.Add(m);

                m.buttonclick += m_Click;

            }
            if (!string.IsNullOrEmpty(pr))
            {
                questionId.Content = pf[0].isQueid;
                int qu = pf[0].isQueid;
                P1.Content = oa[qu-1].Ques.ToString();
                //MessageBox.Show(P1.Content.ToString());
                otp1.Content = oa[qu-1].opt1;
                otp2.Content = oa[qu-1].opt2;
                otp3.Content = oa[qu-1].opt3;
                otp4.Content = oa[qu-1].opt4;
            }
            else
            {
                if (oa.Count > 0)
                {
                    questionId.Content = 1;
                    P1.Content = oa[0].Ques.ToString();
                    //MessageBox.Show(P1.Content.ToString());
                    otp1.Content = oa[0].opt1;
                    otp2.Content = oa[0].opt2;
                    otp3.Content = oa[0].opt3;
                    otp4.Content = oa[0].opt4;
                }
                else
                {
                    MessageBox.Show("paper does not exist");
                }
            }
            if (!string.IsNullOrEmpty(Isreadresult))
            {
                   
                
                for (int i = 0; i<SR.Count(); i++)
                    {
                        for (int j = 1; j <= pf[0].isQueid; j++)
                        {
                            if (SR[i].id == j)
                            {
                                if (SR[i].condidateChoice == oa[j - 1].opt1)
                                {

                                    UIElement child = Buttonpanel.Children[j - 1];
                                    if (child is Button23)
                                    {
                                        Button23 button = (Button23)child;
                                        // Access properties of the button
                                        button.q1.Background = Brushes.Green;
                                        // Do something with buttonText
                                    }
                                break;

                                }
                                else if (SR[i].condidateChoice == oa[j - 1].opt2)
                                {
                                   
                                    UIElement child = Buttonpanel.Children[j - 1];
                                    if (child is Button23)
                                    {
                                        Button23 button = (Button23)child;
                                        // Access properties of the button
                                        button.q1.Background = Brushes.Green;
                                        // Do something with buttonText
                                    }
                                break;

                                }
                                else if (SR[i].condidateChoice == oa[j - 1].opt3)
                                {

                                    UIElement child = Buttonpanel.Children[j - 1];
                                    if (child is Button23)
                                    {
                                        Button23 button = (Button23)child;
                                        // Access properties of the button
                                        button.q1.Background = Brushes.Green;
                                        // Do something with buttonText
                                    }
                                break;

                                }
                                else if (SR[i].condidateChoice == oa[j - 1].opt4)
                                {

                                    UIElement child = Buttonpanel.Children[j - 1];
                                    if (child is Button23)
                                    {
                                        Button23 button = (Button23)child;
                                        // Access properties of the button
                                        button.q1.Background = Brushes.Green;
                                        // Do something with buttonText
                                    }
                                break;

                                }
                                break;


                            }



                        
                              

                    }


                }
            }
            



        }
        protected void m_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("manish");
            if (oa.Count > countVisited)
            {
                countVisited = countVisited + 1;
                IsVisted.Content = countVisited.ToString();
            }
            if (Convert.ToInt32(questionId.Content.ToString()) == oa.Count())
            {
                isNext.IsEnabled = false;
            }
            else
            {
                isNext.IsEnabled = true;
            }
            if (Convert.ToInt32(questionId.Content.ToString()) == 1)
            {
                isPrevious.IsEnabled = false;
            }
            else
            {
                isPrevious.IsEnabled = true;
            }
            
            if (otp1.IsChecked == true || otp2.IsChecked == true || otp3.IsChecked == true || otp4.IsChecked == true)
            {
                
                otp1.IsChecked = false;
                otp2.IsChecked = false;
                otp3.IsChecked = false;
                otp4.IsChecked = false;
            }
            Button23 btn = (Button23)sender;
            int s = int.Parse((string)btn.q1.Content) - 1;
            //if(questionId.Content == btn.q1.Content)
            //{
             //   MessageBox.Show("same");
            //}
            questionId.Content = btn.q1.Content;


            P1.Content = oa[s].Ques.ToString();
            otp1.Content = oa[s].opt1;
            otp2.Content = oa[s].opt2;
            otp3.Content = oa[s].opt3;
            otp4.Content = oa[s].opt4;

            int h = Convert.ToInt32(questionId.Content.ToString());

            
            if (!string.IsNullOrEmpty(Isreadresult) && !string.IsNullOrEmpty(pr))
            {
                var questionExistInResultOtp1 = SR.Find(obj => obj.id == h);
                if (questionExistInResultOtp1 != null && questionExistInResultOtp1.id == h)
                {
                    if (questionExistInResultOtp1.condidateChoice == otp1.Content.ToString())
                    {
                        otp1.IsChecked = true;
                    }
                    else if (questionExistInResultOtp1.condidateChoice == otp2.Content.ToString())
                    {
                        otp2.IsChecked = true;
                    }
                    else if (questionExistInResultOtp1.condidateChoice == otp3.Content.ToString())
                    {
                        otp3.IsChecked = true;
                    }
                    else if (questionExistInResultOtp1.condidateChoice == otp4.Content.ToString())
                    {
                        otp4.IsChecked = true;
                    }

                }
                else
                {

                    otp1.IsChecked = false;
                    otp2.IsChecked = false;
                    otp3.IsChecked = false;
                    otp4.IsChecked = false;
                }


            }
            else
            {
                var questionExistInResultOtp = SR.Find(obj => obj.id == h);
                if (questionExistInResultOtp != null)
                {

                    if (questionExistInResultOtp.condidateChoice == otp1.Content.ToString())
                    {
                        otp1.IsChecked = true;
                    }
                    else if (questionExistInResultOtp.condidateChoice == otp2.Content.ToString())
                    {
                        otp2.IsChecked = true;
                    }
                    else if (questionExistInResultOtp.condidateChoice == otp3.Content.ToString())
                    {
                        otp3.IsChecked = true;
                    }
                    else if (questionExistInResultOtp.condidateChoice == otp4.Content.ToString())
                    {
                        otp4.IsChecked = true;
                    }

                }
                else
                {

                    otp1.IsChecked = false;
                    otp2.IsChecked = false;
                    otp3.IsChecked = false;
                    otp4.IsChecked = false;
                }

            }
            var questionNotExistInResultOtpCurr = SR.Find(obj => obj.id == h);
            if (questionNotExistInResultOtpCurr == null)
            {

                
                UIElement child = Buttonpanel.Children[h - 1];
                if (child is Button23)
                {
                    Button23 button = (Button23)child;
                    // Access properties of the button
                    button.q1.Background = Brushes.Yellow;
                    // Do something with buttonText
                }
            }         

        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            
            //Button23 sd = (Button23)sender;
            if(Convert.ToInt32(questionId.Content.ToString()) == 1)
            {
                isPrevious.IsEnabled = false;
            }
            isNext.IsEnabled = true;
            if (Convert.ToInt32(questionId.Content.ToString()) > 1)
            {
                var qa = Convert.ToInt32(questionId.Content.ToString());
                questionId.Content = qa - 1;
                int d = qa - 2;
                P1.Content = oa[d].Ques.ToString();
                //MessageBox.Show((string)oa[d-1].Ques.ToString());
                otp1.Content = oa[d].opt1;
                otp2.Content = oa[d].opt2;
                otp3.Content = oa[d].opt3;
                otp4.Content = oa[d].opt4;


                if (!string.IsNullOrEmpty(Isreadresult) && !string.IsNullOrEmpty(pr))
                {
                    var questionExistInResultOtp1 = SR.Find(obj => obj.id == qa-1);
                    if (questionExistInResultOtp1 != null && questionExistInResultOtp1.id == qa-1)
                    {
                        if (questionExistInResultOtp1.condidateChoice == otp1.Content.ToString())
                        {
                            otp1.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp2.Content.ToString())
                        {
                            otp2.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp3.Content.ToString())
                        {
                            otp3.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp4.Content.ToString())
                        {
                            otp4.IsChecked = true;
                        }

                    }
                    else
                    {

                        otp1.IsChecked = false;
                        otp2.IsChecked = false;
                        otp3.IsChecked = false;
                        otp4.IsChecked = false;
                    }


                }
                else
                {
                    var questionExistInResultOtp = SR.Find(obj => obj.id == qa - 1);
                    if (questionExistInResultOtp != null)
                    {
                        if (questionExistInResultOtp.condidateChoice == otp1.Content.ToString())
                        {
                            otp1.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp2.Content.ToString())
                        {
                            otp2.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp3.Content.ToString())
                        {
                            otp3.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp4.Content.ToString())
                        {
                            otp4.IsChecked = true;
                        }

                    }
                    else
                    {
                        otp1.IsChecked = false;
                        otp2.IsChecked = false;
                        otp3.IsChecked = false;
                        otp4.IsChecked = false;
                    }
                }
                var questionNotExistInResultOtpCurr = SR.Find(obj => obj.id == qa);
                if (questionNotExistInResultOtpCurr == null)
                {

                    UIElement child = Buttonpanel.Children[qa - 1];
                    if (child is Button23)
                    {
                        Button23 button = (Button23)child;
                        // Access properties of the button
                        button.q1.Background = Brushes.Yellow;
                        // Do something with buttonText
                    }
                }
            }

        }
        private void Next(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(questionId.Content.ToString()) == oa.Count())
            {
                isNext.IsEnabled = false;
            }
            
            isPrevious.IsEnabled = true;
            
            if (oa.Count > countVisited)
            {
                countVisited = countVisited + 1;
                IsVisted.Content = countVisited.ToString();
            }
            if (Convert.ToInt32(questionId.Content.ToString()) != oa.Count())
            {
                int a = Convert.ToInt32(questionId.Content.ToString());
                // int a = (int)questionId.Content;
                questionId.Content = a + 1;
                int f = a;
                P1.Content = oa[f].Ques.ToString();
                //MessageBox.Show((string)oa[d-1].Ques.ToString());
                otp1.Content = oa[f].opt1;
                otp2.Content = oa[f].opt2;
                otp3.Content = oa[f].opt3;
                otp4.Content = oa[f].opt4;
                if (!string.IsNullOrEmpty(Isreadresult) && !string.IsNullOrEmpty(pr))
                {
                    var questionExistInResultOtp1 = SR.Find(obj => obj.id == a+1);
                    if (questionExistInResultOtp1 != null && questionExistInResultOtp1.id == a+1)
                    {
                        if (questionExistInResultOtp1.condidateChoice == otp1.Content.ToString())
                        {
                            otp1.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp2.Content.ToString())
                        {
                            otp2.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp3.Content.ToString())
                        {
                            otp3.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp4.Content.ToString())
                        {
                            otp4.IsChecked = true;
                        }

                    }
                    else
                    {

                        otp1.IsChecked = false;
                        otp2.IsChecked = false;
                        otp3.IsChecked = false;
                        otp4.IsChecked = false;
                    }


                }
                else
                {
                    var questionExistInResultOtp = SR.Find(obj => obj.id == a + 1);
                    if (questionExistInResultOtp != null && questionExistInResultOtp.id == a + 1)
                    {
                        if (questionExistInResultOtp.condidateChoice == otp1.Content.ToString())
                        {
                            otp1.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp2.Content.ToString())
                        {
                            otp2.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp3.Content.ToString())
                        {
                            otp3.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp4.Content.ToString()    )
                        {
                            otp4.IsChecked = true;
                        }
                        // Check the type of the child control

                    }
                    else
                    {
                        otp1.IsChecked = false;
                        otp2.IsChecked = false;
                        otp3.IsChecked = false;
                        otp4.IsChecked = false;

                        // Check the type of the child control
                    }
                }
                var questionNotExistInResultOtpCurr = SR.Find(obj => obj.id == a);
                if (questionNotExistInResultOtpCurr ==null)
                {
                    
                    UIElement child = Buttonpanel.Children[a - 1];
                    if (child is Button23)
                    {
                        Button23 button = (Button23)child;
                        // Access properties of the button
                        button.q1.Background = Brushes.Yellow;
                        // Do something with buttonText
                    }
                }


            }


        }
        private void SaveandExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void SaveandNext(object sender, RoutedEventArgs e)
        {
            //Button23 sd =  (Button23)sender;
           
            
            if (oa.Count > countVisited)
            {
                countVisited = countVisited + 1;
                IsVisted.Content = countVisited.ToString();
            }
            int h = Convert.ToInt32(questionId.Content.ToString());
            if (otp1.IsChecked == true || otp2.IsChecked == true || otp3.IsChecked == true || otp4.IsChecked == true)
            {
                var questionExistInResult = SR.Find(obj => obj.id == h);
                if (questionExistInResult != null && (questionExistInResult.id == h))
                {
                    if (otp1.IsChecked == true)
                    {

                        questionExistInResult.condidateChoice = (string)otp1.Content;

                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        string str = File.ReadAllText(P2);
                        UIElement child = Buttonpanel.Children[h - 1];

                    }
                    else if (otp2.IsChecked == true)
                    {

                        questionExistInResult.condidateChoice = (string)otp2.Content;

                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        string str = File.ReadAllText(P2);
                        UIElement child = Buttonpanel.Children[h - 1];

                    }
                    else if (otp3.IsChecked == true)
                    {

                        questionExistInResult.condidateChoice = (string)otp3.Content;

                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        string str = File.ReadAllText(P2);
                        UIElement child = Buttonpanel.Children[h - 1];

                    }
                    else if (otp4.IsChecked == true)
                    {

                        questionExistInResult.condidateChoice = (string)otp4.Content;

                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        string str = File.ReadAllText(P2);
                        UIElement child = Buttonpanel.Children[h - 1];

                    }
                }
                else
                {
                    if (otp1.IsChecked == true)
                    {
                        result rs = new result()
                        {
                            id = h,
                            Q = (string)P1.Content,
                            sl = oa[h - 1].sol,
                            condidateChoice = (string)otp1.Content

                        };
                        SR.Add(rs);
                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        UIElement child = Buttonpanel.Children[h - 1];

                        // Check the type of the child control
                        if (child is Button23)
                        {
                            Button23 button = (Button23)child;
                            // Access properties of the button
                            button.q1.Background = Brushes.Green;
                            // Do something with buttonText
                        }
                        //MessageBox.Show(str);
                    }
                    else if (otp2.IsChecked == true)
                    {
                        result rs = new result()
                        {
                            id = h,
                            Q = (string)P1.Content,

                            sl = oa[h - 1].sol,
                            condidateChoice = (string)otp2.Content

                        };

                        SR.Add(rs);
                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        UIElement child = Buttonpanel.Children[h - 1];

                        // Check the type of the child control
                        if (child is Button23)
                        {
                            Button23 button = (Button23)child;
                            // Access properties of the button
                            button.q1.Background = Brushes.Green;
                            // Do something with buttonText
                        }
                        //MessageBox.Show(str);

                    }
                    else if (otp3.IsChecked == true)
                    {
                        result rs = new result()
                        {
                            id = h,
                            Q = (string)P1.Content,

                            sl = oa[h - 1].sol,
                            condidateChoice = (string)otp3.Content

                        };

                        SR.Add(rs);
                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        UIElement child = Buttonpanel.Children[h - 1];

                        // Check the type of the child control
                        if (child is Button23)
                        {
                            Button23 button = (Button23)child;
                            // Access properties of the button
                            button.q1.Background = Brushes.Green;
                            // Do something with buttonText
                        }
                        //MessageBox.Show(str);
                    }
                    else if (otp4.IsChecked == true)
                    {
                        result rs = new result()
                        {
                            id = h,
                            Q = (string)P1.Content,

                            sl = oa[h - 1].sol,
                            condidateChoice = (string)otp4.Content

                        };

                        SR.Add(rs);
                        string Up = JsonConvert.SerializeObject(SR);
                        File.WriteAllText(P2, Up);

                        UIElement child = Buttonpanel.Children[h - 1];

                        // Check the type of the child control
                        if (child is Button23)
                        {
                            Button23 button = (Button23)child;

                            // Access properties of the button
                            button.q1.Background = Brushes.Green;

                            // Do something with buttonText
                        }
                        // MessageBox.Show(str);
                    }
                    
                }
            }
            else
            {
                
                UIElement child = Buttonpanel.Children[h - 1];

                // Check the type of the child control

                if (child is Button23)
                {
                    Button23 button = (Button23)child;
                    // Access properties of the button
                    button.q1.Background = Brushes.Yellow;
                    // Do something with buttonText
                }

                // Add more conditions for other types of controls as needed

            }

            if (Convert.ToInt32(questionId.Content.ToString()) != oa.Count())
            {
                int a = Convert.ToInt32(questionId.Content.ToString());
                // int a = (int)questionId.Content;
                questionId.Content = a + 1;
                int f = a;

                P1.Content = oa[f].Ques.ToString();
                //MessageBox.Show((string)oa[d-1].Ques.ToString());
                otp1.Content = oa[f].opt1;
                otp2.Content = oa[f].opt2;
                otp3.Content = oa[f].opt3;
                otp4.Content = oa[f].opt4;

                if (otp1.IsChecked == true || otp2.IsChecked == true || otp3.IsChecked == true || otp4.IsChecked == true)
                {
                    otp1.IsChecked = false;
                    otp2.IsChecked = false;
                    otp3.IsChecked = false;
                    otp4.IsChecked = false;

                }
                if (!string.IsNullOrEmpty(Isreadresult) && !string.IsNullOrEmpty(pr))
                {
                    var questionExistInResultOtp1 = SR.Find(obj => obj.id == a + 1);
                    if (questionExistInResultOtp1 != null && questionExistInResultOtp1.id == a + 1)
                    {
                        if (questionExistInResultOtp1.condidateChoice == otp1.Content.ToString())
                        {
                            otp1.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp2.Content.ToString())
                        {
                            otp2.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp3.Content.ToString())
                        {
                            otp3.IsChecked = true;
                        }
                        else if (questionExistInResultOtp1.condidateChoice == otp4.Content.ToString())
                        {
                            otp4.IsChecked = true;
                        }

                    }
                    else
                    {

                        otp1.IsChecked = false;
                        otp2.IsChecked = false;
                        otp3.IsChecked = false;
                        otp4.IsChecked = false;
                    }


                }
                else
                {
                    var questionExistInResultOtp = SR.Find(obj => obj.id == a + 1);
                    if (questionExistInResultOtp != null && questionExistInResultOtp.id == a + 1)
                    {
                        if (questionExistInResultOtp.condidateChoice == otp1.Content.ToString())
                        {
                            otp1.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp2.Content.ToString())
                        {
                            otp2.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp3.Content.ToString())
                        {
                            otp3.IsChecked = true;
                        }
                        else if (questionExistInResultOtp.condidateChoice == otp4.Content.ToString())
                        {
                            otp4.IsChecked = true;
                        }
                        // Check the type of the child control

                    }
                    else
                    {
                        otp1.IsChecked = false;
                        otp2.IsChecked = false;
                        otp3.IsChecked = false;
                        otp4.IsChecked = false;

                        // Check the type of the child control
                    }
                }


            }
            NotAnswered.Content = (oa.Count - SR.Count).ToString();
            Answered.Content = (SR.Count).ToString();
        }

        private void clear(object sender, RoutedEventArgs e)
        {            
                if (otp1.IsChecked == true || otp2.IsChecked == true || otp3.IsChecked == true || otp4.IsChecked == true)
                {
                    otp1.IsChecked = false;
                    otp2.IsChecked = false;
                    otp3.IsChecked = false;
                    otp4.IsChecked = false;

                }
                int h = Convert.ToInt32(questionId.Content.ToString());
                SR.RemoveAll(obj => obj.id == h);
                string Up = JsonConvert.SerializeObject(SR);
                File.WriteAllText(P2, Up);
                UIElement child = Buttonpanel.Children[h-1];

                // Check the type of the child control

                if (child is Button23)
                {
                    Button23 button = (Button23)child;
                    // Access properties of the button
                    button.q1.Background = Brushes.Yellow;
                    // Do something with buttonText
                }
                NotAnswered.Content = (oa.Count - SR.Count).ToString();
                Answered.Content = (SR.Count).ToString();
                 
                
            }
        int increement = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
              timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();


        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // code goes here
            if (duration.TotalSeconds > 0)
            {
                duration = duration.Subtract(TimeSpan.FromSeconds(1));
                currTime.Content  = duration.ToString(@"hh\:mm\:ss"); // Display minutes and seconds
            }
            else
            {
                this.Close();
                // Timer expired, you can handle this as needed
                timer.Stop();
                currTime.Content= "Time's up!";
            }


            
        }
        private void pause(object sender, RoutedEventArgs e)
        {
            pauseFile isPauseFile = new pauseFile()
            {
                pauseTime = TimeSpan.Parse((string)currTime.Content),
                Isnotasd = int.Parse((string)NotAnswered.Content),
                isasd = int.Parse((string)Answered.Content),
                isQueid = Convert.ToInt32(questionId.Content.ToString()),
               // isvisitedanum = int.Parse((string)IsVisted.Content)
        };
            pf.Insert(0,isPauseFile);
            string isPf = JsonConvert.SerializeObject(pf);
            File.WriteAllText(PauseFile1, isPf);

            string str = File.ReadAllText(PauseFile1);

            this.Close();
        }
    }

}

