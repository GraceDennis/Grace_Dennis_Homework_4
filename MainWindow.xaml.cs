using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; //
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; //
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection; //

namespace Task_1__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void getBreedButton_Click(object sender, RoutedEventArgs e)
        {       
                string uri = "https://dog.ceo/api/breeds/list/all";
             
            using (HttpClient client = new HttpClient())
            {
                    Task<HttpResponseMessage> rm = client.GetAsync(uri);

                    HttpResponseMessage response = rm.Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent hc = response.Content;
                    Task<string> ts = hc.ReadAsStringAsync();
                    string content = ts.Result;

                    ImageResult r = JsonConvert.DeserializeObject<ImageResult>(content);

                    DogBreedList dl = r.Message;

                    Type t = dl.GetType();

                    PropertyInfo[] properties = t.GetProperties();

                    foreach(PropertyInfo pi in properties)
                    {
                        if (pi.Name != null)
                        {
                            breedListBox.Items.Add(pi.Name);
                        }
                    }



                   /* BitmapImage pic1 = new BitmapImage();
                    pic1.BeginInit();
                    pic1.UriSource = new Uri(r.Message[1]);
                    pic1.EndInit();
                    dogImage1.Source = pic1;

                    BitmapImage pic2 = new BitmapImage();
                    pic2.BeginInit();
                    pic2.UriSource = new Uri(r.Message[2]);
                    pic2.EndInit();
                    dogImage1.Source = pic2;*/


                }

            }
            
        }










    }
}
