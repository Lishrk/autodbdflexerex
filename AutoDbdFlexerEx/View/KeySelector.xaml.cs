using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace AutoDbdFlexerEx.View
{
    public partial class KeySelector : System.Windows.Controls.UserControl
    {
        public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register("SelectedKey", typeof(Keys), typeof(KeySelector));

        private bool waitForInput;

        public Keys SelectedKey
        {
            get
            {
                return (Keys)GetValue(SelectedKeyProperty);
            }
            set
            {
                SetValue(SelectedKeyProperty, value);
            }
        }

        public KeySelector()
        {
            InitializeComponent();

            KeyDown += (s, e) =>
            {
                if (waitForInput)
                {
                    SelectedKey = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
                    waitForInput = false;
                }
            };
        }

        private void SelectKey(object sender, RoutedEventArgs e)
        {
            StatusButton.Content = "...";
            waitForInput = true;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == SelectedKeyProperty)
            {
                StatusButton.Content = SelectedKey.ToString();
            }
        }
    }
}
