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
using System.Windows.Shapes;

namespace NamePicker
{
    /// <summary>
    /// Interaction logic for DisplayName.xaml
    /// </summary>
    public partial class DisplayName : Window
    {
     
        List<string> displayName = new List<string>();
        Random randomizer = new Random();
        public DisplayName(List<string> names, int arrayLength)
        {

            displayName = names;
            InitializeComponent();
            
        }

        public void bDisplay_Click(object sender, RoutedEventArgs e)
        { 
            try
            { 
                int random = randomizer.Next(displayName.Count());
                if (!string.IsNullOrEmpty(displayName[random]))
                {
                    lDisplayName.Content = displayName[random];
                    displayName.RemoveAt(random);

                    var numberOfStudentsLeft = displayName.Count();
                    if(numberOfStudentsLeft == 0 )
                    {
                        MessageBox.Show("All students have participated, click ok to close.", "Completed", MessageBoxButton.OK);
                        System.Windows.Application.Current.Shutdown();
                    }                    
                }               
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("No students found. They need to be added.", "No students found", MessageBoxButton.OK);
                var setClassSize = new ClassSize();
                setClassSize.Show();

            }
            catch(Exception)
            {
                MessageBox.Show("Please contact support at brandonarivera@outlook.com", "Unknown Error", MessageBoxButton.OK);
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
