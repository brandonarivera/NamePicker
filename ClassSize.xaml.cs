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
    /// Interaction logic for ClassSize.xaml
    /// </summary>
    public partial class ClassSize : Window
    {   public static int numberOfStudents;
        public ClassSize()
        {
            InitializeComponent();
        }
        
        private int setClassSize()
        {
            try
            {
                int.TryParse(tbxSize.Text, out numberOfStudents);
            var x = new AddNames();
            x.Show();
            Hide();
            }
            catch (FormatException)
            {
                
                MessageBox.Show("You must use numbers.", "Format Exception", MessageBoxButton.OK);
                Close();
                var tryAgain = new ClassSize();
                tryAgain.Show();
            }            
            

            return numberOfStudents;
        }
        private void bConfirmSize_Click(object sender, RoutedEventArgs e)
        {
            setClassSize();
            
        }
    }
}
