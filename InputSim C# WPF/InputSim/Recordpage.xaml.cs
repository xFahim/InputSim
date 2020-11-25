using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Recordpage.xaml
    /// </summary>
    public partial class Recordpage : Page
    {
        List<InputSetData> _INPSETLIST;
        public Recordpage()
        {
            InitializeComponent();

            //load data
            _INPSETLIST = BinaryserializerHelper.GetAllSerializedData();

            RecordList.ItemsSource = _INPSETLIST;

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            InputSetData data = _INPSETLIST.Find(x => x.Tag.ToUpper() == TagSearchBox.Text.ToUpper());

            if (data != null)
            {
                this.NavigationService.Navigate(new InputSetViewEdit(data));
            }
            else
            {
                MessageBox.Show("Nothing Found.\nCheck your Tag/ spelling of it.");
            }
        }

        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RecordList.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new InputSetViewEdit(_INPSETLIST[RecordList.SelectedIndex]));
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RecordList.SelectedIndex >= 0)
            {
                File.Delete("Records//" + _INPSETLIST[RecordList.SelectedIndex].Tag + ".dat");
                _INPSETLIST.RemoveAt(RecordList.SelectedIndex);

                RecordList.ItemsSource = null;
                RecordList.ItemsSource = _INPSETLIST;

                MessageBox.Show("InputSet Removed Successfully");
            }
        }
    }
}
