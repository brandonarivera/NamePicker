using System;
using System.Collections.Generic;
using System.IO;
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


namespace NamePicker
{
    /// <summary>
    /// Interaction logic for AddNames.xaml
    /// </summary>
    public partial class AddNames : Window
    {
        static string link = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public StreamWriter writer = new StreamWriter( link + "Names.txt");
        public List<string> NamesList = new List<string>();
        int numberAdded = 0;
        public AddNames()
        {
            
            InitializeComponent();
        }

         void bDoneAdding_Click(object sender, RoutedEventArgs e)
        {
            {
                foreach (var item in NamesList)
                {
                    writer.WriteLine(item);
                }
                writer.Flush();                  
                writer.Dispose();
            }
            Hide();
            MainWindow x = new MainWindow();
            x.Show();
        }

            private void FillNameArray()
            {
                int namesLeft;                
                NamesList.Add(tBxName.Text);               
                tBxName.Clear();
                numberAdded++;
                namesLeft = ClassSize.numberOfStudents - numberAdded;
                if (namesLeft > 0)
                {
                    MessageBox.Show("Click again to add more names, you have " + namesLeft + " left to add. ", "More Names Needed", MessageBoxButton.OK);

                }
                else
                    MessageBox.Show("You have added in all the students in your class.", "Class limit", MessageBoxButton.OK);                        
            }

        private void bAddNames_Click(object sender, RoutedEventArgs e)
        {
            FillNameArray();
        }
    }  
    
}
