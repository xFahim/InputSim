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

namespace InputSim
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void HookStartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (KeyInpCheckBox.IsChecked == false && MouseInpCheckBox.IsChecked == false)
            {
                MessageBox.Show("Choose either mouse or keyboard to proceed", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {


                this.NavigationService.Navigate(new HookOnPage(
                    (bool)MouseInpCheckBox.IsChecked,
                    (bool)KeyInpCheckBox.IsChecked,
                    new MouseHookSettings {
                        LeftDown = (bool)LeftDownCheck.IsChecked,
                        LeftUp = (bool)LeftUpCheck.IsChecked,
                    //    LeftDouble = (bool)LeftDoubleCheck.IsChecked,
                        RightDown = (bool)RightDownCheck.IsChecked,
                        RightUp = (bool)RightUpCheck.IsChecked,
                      //  RightDouble = (bool)RightDoubleCheck.IsChecked,
                        Wheel = (bool)WheelCheck.IsChecked,
                        Movement = (bool)MovementCheck.IsChecked,
                        //  MidDouble = (bool)MidDoubleCheck.IsChecked,
                        MidDown = (bool)MidDownCheck.IsChecked,
                        MidUp = (bool)MidUpCheck.IsChecked,
                        LeftClick = (bool)LeftClickCheck.IsChecked,
                        RightClick = (bool)RightClickCheck.IsChecked
                    }));
            }
        }

        private void SimulateStartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SimUsingKey.IsChecked == true)
            {
                this.NavigationService.Navigate(new SimulateOnPage());
            }
            else
            {
                this.NavigationService.Navigate(new CustomSimulate());
            }
        }

        private void OpenRecBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Recordpage());
        }

        private void LeftClickCheck_Checked(object sender, RoutedEventArgs e)
        {
            LeftDownCheck.IsChecked = true;
            LeftUpCheck.IsChecked = true;

            LeftDownCheck.IsEnabled = false;
            LeftUpCheck.IsEnabled = false;
        }

        private void LeftClickCheck_Unchecked(object sender, RoutedEventArgs e)
        {

            LeftDownCheck.IsEnabled = true;
            LeftUpCheck.IsEnabled = true;
        }

        private void RightClickCheck_Checked(object sender, RoutedEventArgs e)
        {
            RightDownCheck.IsChecked = true;
            RightUpCheck.IsChecked = true;

            RightDownCheck.IsEnabled = false;
            RightUpCheck.IsEnabled = false;
        }

        private void RightClickCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            RightDownCheck.IsEnabled = true;
            RightUpCheck.IsEnabled = true;
        }

        private void MovementCheck_Checked(object sender, RoutedEventArgs e)
        {
            LeftDownCheck.IsChecked = true;
            LeftUpCheck.IsChecked = true;
            RightDownCheck.IsChecked = true;
            RightUpCheck.IsChecked = true;

            RightDownCheck.IsEnabled = false;
            RightUpCheck.IsEnabled = false;
            LeftDownCheck.IsEnabled = false;
            LeftUpCheck.IsEnabled = false;
        }

        private void MovementCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            RightDownCheck.IsEnabled = true;
            RightUpCheck.IsEnabled = true;
            LeftDownCheck.IsEnabled = true;
            LeftUpCheck.IsEnabled = true;
        }

        private void MouseConfigAboutBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    
}
