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
using TextBox = System.Windows.Controls.TextBox;

namespace Lesson3Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ButtonsFunctionality _buttonsFunctionality;
        public MainWindow()
        {
            _buttonsFunctionality = new ButtonsFunctionality();
            InitializeComponent();
        }

        private void button_open_Click(object sender, RoutedEventArgs e)
        {
            TextWritingbox.Text = _buttonsFunctionality.ReadTextFromFile();
            filepathtextblock.Text = _buttonsFunctionality.FileName;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_buttonsFunctionality.FileName))
            {
                _buttonsFunctionality.SaveTextToFile(TextWritingbox.Text);
                filepathtextblock.Text = _buttonsFunctionality.FileName;
            }
            else
            {
                _buttonsFunctionality.AutoSaving(TextWritingbox.Text);
            }
        }

        private void button_saveAs_Click(object sender, RoutedEventArgs e)
        {
            _buttonsFunctionality.SaveTextToFile(TextWritingbox.Text);
            filepathtextblock.Text = _buttonsFunctionality.FileName;
        }

        private void button_Cut_Click(object sender, RoutedEventArgs e)
        {
            TextWritingbox.Cut();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            TextWritingbox.Copy();
            TextWritingbox.Focus();
        }

        private void button_Paste_Click(object sender, RoutedEventArgs e)
        {

            TextWritingbox.Paste();
        }

        private void button_SelecetAll_Click(object sender, RoutedEventArgs e)
        {
            TextWritingbox.Focus();
            TextWritingbox.SelectAll();
        }



        private void TextWritingbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox txtbox))
                return;
            if (AutoSaveToggleButton.IsChecked != true)
                return;
            _buttonsFunctionality.AutoSaving(txtbox.Text);

        }
    }
}
