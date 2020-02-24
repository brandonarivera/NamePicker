using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace NamePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (!File.Exists(link + @"Names.txt") == true)
            {
                File.Create(link + @"Names.txt");
                MessageBox.Show("Add Students to get Started.", "Need students", MessageBoxButton.OK);

            }
            else
            {
                File.Copy(link + @"Names.txt", link + @"NamesCopy.txt", true);
            }
            InitializeComponent();
            
            

        }
        
        string link = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);        
        static int y = 1;
        public List<string> listNames = new List<string>();
        string[] NamePicker = new string[y];
        List<string> prepareCopy()
        {
            listNames.AddRange(File.ReadAllLines(link + @"Names.txt"));
            //NamePicker = File.ReadAllLines(link + "Names.txt");
            //foreach (var item in NamePicker)
            //{
            //    listNames.Add(item);
            //}
           

            return listNames;
        }   

        private void bPicker_Click(object sender, RoutedEventArgs e)
        {
            var namestoDisplay = prepareCopy();
            var listLength = listNames.Count();
            var namePicker = new DisplayName(namestoDisplay, listLength);
            namePicker.Show();
            
        }

        private void bAddNamesHere_Click(object sender, RoutedEventArgs e)
        {
            File.Create(link + @"Names.txt");
            var setClassSize = new ClassSize();
            setClassSize.Show();
            Hide();

        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(link + @"NameCopy.txt");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
