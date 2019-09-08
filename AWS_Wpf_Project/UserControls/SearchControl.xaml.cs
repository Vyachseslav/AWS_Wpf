using AWS_Wpf_Project.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AWS_Wpf_Project.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl, INotifyPropertyChanged
    {
        public readonly static DependencyProperty TextProperty =
            DependencyProperty.Register("ControlText", typeof(string), typeof(SearchControl), new PropertyMetadata(OnTextChanged));

        //private string _controlText;
        private RelayCommand _clearCommand;

        static void OnTextChanged(DependencyObject obj,
   DependencyPropertyChangedEventArgs args)
        {
            if (TextChanged != null)
                TextChanged(obj);
        }

        public delegate void TextChangeHandler(object sender);
        public static TextChangeHandler TextChanged;

        public string ControlText
        {
            get { return (String)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); OnPropertyChanged(); }
        }

        //public string ControlText
        //{
        //    get { return _controlText; }
        //    set { _controlText = value; OnPropertyChanged(); }
        //}

        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand ??
                  (_clearCommand = new RelayCommand(obj =>
                  {
                      ControlText = String.Empty;
                  }));
            }
        }

        public SearchControl()
        {
            InitializeComponent();
            //this.DataContext = this;

            TextChanged += new TextChangeHandler((object sender) =>
            {
                //Prevent forcing changes to other instances of the user control
                if (this == ((SearchControl)sender))
                    this.txtSearch.Text = this.ControlText;
            });

            this.txtSearch.TextChanged += new TextChangedEventHandler((object sender, TextChangedEventArgs e) =>
            {
                this.ControlText = txtSearch.Text;
            });
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void ClearTextButton_Click(object sender, RoutedEventArgs e)
        {
            ControlText = String.Empty;
        }
    }
}
