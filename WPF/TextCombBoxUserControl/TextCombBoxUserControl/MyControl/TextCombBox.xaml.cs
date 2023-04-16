using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TextCombBoxUserControl.MyControl
{
    /// <summary>
    /// TextCombBox.xaml の相互作用ロジック
    /// </summary>
    public partial class TextCombBox : UserControl
    {
        public TextCombBox()
        {
            InitializeComponent();

            Loaded += TextCombBox_Loaded;
            txtBox1.PreviewTextInput += De_PreviewTextInput;
            txtBox2.PreviewTextInput += De_PreviewTextInput;

            txtBox1.TextChanged += (s, e) =>
            {
                Data org = Item;
                Data neo = new Data();
                neo.de = txtBox1.Text;
                neo.m = org.m;
                neo.di = org.di;
                Item = neo;
            };


            txtBox2.TextChanged += (s, e) =>
            {
                Data org = Item;
                Data neo = new Data();
                neo.de = org.de;
                neo.m = txtBox2.Text;
                neo.di = org.di;
                Item = neo;
            };

            cmbBox.SelectionChanged += (s, e) =>
            {
                Data org = Item;
                Data neo = new Data();
                neo.de = org.de;
                neo.m = org.m;
                neo.di = (string)(e.AddedItems[0]);
                Item = neo;
            };
        }

        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register(
                "Item",
                typeof(Data),
                typeof(TextCombBox),
                new FrameworkPropertyMetadata(
                    new Data() { de = "0", m = "0", di = "-" },
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback((o, e) =>
                    {
                        var uc = o as TextCombBox;
                        if (uc != null)
                        {
                            if (e.NewValue != null)
                            {
                                var pa = e.NewValue as Data;
                                if (pa != null)
                                {
                                    uc._data = pa;
                                    uc.txtBox1.Text = pa.de;
                                    uc.txtBox2.Text = pa.m;
                                    uc.cmbBox.SelectedItem = pa.di;
                                }
                            }
                        }
                    })));

        public static readonly DependencyProperty IsFlgProperty =
            DependencyProperty.Register(
                "IsFlg",
                typeof(bool),
                typeof(TextCombBox),
                new PropertyMetadata(false));

        private Data _data = new Data();
        public Data Item
        {
            get => _data;
            set => SetValue(ItemProperty, value);
        }

        public bool IsFlg
        {
            get { return (bool)GetValue(IsFlgProperty); }
            set { SetValue(IsFlgProperty, value); }
        }

        private void TextCombBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsFlg)
            {
                cmbBox.Items.Add("〇");
                cmbBox.Items.Add("×");

                if (cmbBox.Text == "×")
                {
                    cmbBox.SelectedIndex = 1;
                }
                else
                {
                    cmbBox.SelectedIndex = 0;
                }

                return;
            }

                cmbBox.Items.Add("□");
                cmbBox.Items.Add("△");

                if (cmbBox.Text == "△")
                {
                    cmbBox.SelectedIndex = 1;
                }
                else
                {
                    cmbBox.SelectedIndex = 0;
                }
        }

        private void De_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
        }

    }
}
