using AutoDbdFlexerEx.Model;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace AutoDbdFlexerEx.View
{
    public partial class FlexActionConfigEditor : UserControl
    {
        public static readonly DependencyProperty ActionConfigProperty = DependencyProperty.Register("ActionConfig", typeof(ActionConfig), typeof(FlexActionConfigEditor));

        public ActionConfig ActionConfig
        {
            get
            {
                return (ActionConfig)GetValue(ActionConfigProperty);
            }
            set
            {
                SetValue(ActionConfigProperty, value);
            }
        }

        public FlexActionConfigEditor()
        {
            InitializeComponent();
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ActionConfigProperty)
            {
                DataContext = ActionConfig;
                Render();
            }
        }
        private void Render()
        {
            var describedProperties = new List<PropertyInfo>();

            foreach (var property in ActionConfig.GetType().GetProperties())
            {
                var description = property.GetCustomAttribute<DescriptionAttribute>();
                if (description != null)
                    describedProperties.Add(property);
            }

            ConfigProperties.Items.Clear();
            foreach (var describedProperty in describedProperties)
            {
                TextBlock description = new TextBlock() { Text = describedProperty.GetCustomAttribute<DescriptionAttribute>().Description };
                ConfigProperties.Items.Add(description);

                if (describedProperty.PropertyType == typeof(int))
                {
                    TextBox propertyTextBox = new TextBox();
                    ConfigProperties.Items.Add(propertyTextBox);
                    propertyTextBox.SetBinding(TextBox.TextProperty, new Binding(describedProperty.Name) { Mode = BindingMode.TwoWay });
                }
                else if (describedProperty.PropertyType == typeof(System.Windows.Forms.Keys))
                {
                    KeySelector propertyKeySelector = new KeySelector();
                    ConfigProperties.Items.Add(propertyKeySelector);
                    propertyKeySelector.SetBinding(KeySelector.SelectedKeyProperty, new Binding(describedProperty.Name) { Mode = BindingMode.TwoWay });
                }
            }
        }
    }
}
