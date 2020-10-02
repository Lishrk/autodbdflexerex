using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoDbdFlexerEx.View
{
    public partial class ColorPicker : UserControl
    {
        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPicker));

        public Color SelectedColor
        {
            get
            {
                return (Color)GetValue(SelectedColorProperty);
            }
            set
            {
                SetValue(SelectedColorProperty, value);
            }
        }
        public ColorPicker()
        {
            InitializeComponent();
        }
        private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            using (var colorDialog = new System.Windows.Forms.ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true;
                colorDialog.Color = System.Drawing.Color.FromArgb(byte.MaxValue, SelectedColor.R, SelectedColor.G, SelectedColor.B);
                colorDialog.ShowDialog();
                SelectedColor = Color.FromArgb(byte.MaxValue, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }
    }
}
