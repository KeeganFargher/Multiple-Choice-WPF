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
using MaterialDesignThemes.Wpf;

namespace MultipleChoiceUI.User_Controls
{
    /// <summary>
    /// Interaction logic for MenuCardUserControl.xaml
    /// </summary>
    public partial class MenuCardUserControl
    {
        public MenuCardUserControl()
        {
            InitializeComponent();
        }

        public string ButtonDescriptionText
        {
            set => ButtonDescription.Content = value;
        }

        public PackIconKind IconName
        {
            set => Icon.Kind = value;
        }

        public RoutedEventHandler ButtonDescriptionClick
        {
            set => ButtonDescription.Click += value;
        }
    }
}
