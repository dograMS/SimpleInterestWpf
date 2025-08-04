
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows.Media.Effects;


namespace WpfApp1.View.UserControls
{
    /// <summary>
    /// Interaction logic for ModernTextBox.xaml
    /// </summary>
    public partial class ModernTextBox : UserControl, INotifyPropertyChanged
    {
        
        public ModernTextBox()
        {
            
            InitializeComponent();
            textboxControl.GotFocus += (s, e) =>
            {
                AddFocus();   
            };

            textboxControl.LostFocus += (s, e) =>
            {
                RemoveFocus();
            };
        }


        public static readonly DependencyProperty TextDataProperty =
            DependencyProperty.Register(
                nameof(TextData),
                typeof(string),
                typeof(ModernTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        private string text;
        private string labelTxt;

        public event PropertyChangedEventHandler PropertyChanged;

        public string LabelData
        {
            get { return labelTxt; }
            set
            {
                labelTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LabelData"));
            }
        }
        public string TextData
        {
            get => (string)GetValue(TextDataProperty);
            set => SetValue(TextDataProperty, value);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void AddFocus()
        {
            labelControl.Foreground = (Brush)new BrushConverter().ConvertFrom("#4A90E2");
            bottomBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#009688");

            StackContainer.Effect = new DropShadowEffect
            {
                BlurRadius = 4,
                ShadowDepth = 2,
                Direction = 270,
                Color = Colors.Black,
                Opacity = 0.2
            };

        }
        private void RemoveFocus()
        {
            labelControl.Foreground = Brushes.DarkGray;
            bottomBorder.BorderBrush = Brushes.Black;
            StackContainer.Effect = null;
        }

    }
}
