using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HW9
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ICommand _redCommand;
        private ICommand _greenCommand;
        private ICommand _blueCommand;

        public ICommand RedCommand
        {
            get { return _redCommand; }
            set { _redCommand = value; NotifyPropertyChanged(); }
        }

        public ICommand GreenCommand
        {
            get { return _greenCommand; }
            set { _greenCommand = value; NotifyPropertyChanged(); }
        }

        public ICommand BlueCommand
        {
            get { return _blueCommand; }
            set { _blueCommand = value; NotifyPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            RedCommand = new RelayCommand(() => ChangeControlColor(redTextBox, Colors.Red));
            GreenCommand = new RelayCommand(() => ChangeControlColor(greenTextBox, Colors.Green));
            BlueCommand = new RelayCommand(() => ChangeControlColor(blueTextBox, Colors.Blue));
        }

        private void Control_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox focusedTextBox = sender as TextBox;
            if (focusedTextBox != null)
            {
                focusedTextBox.Background = Brushes.White;
            }
        }

        private void ChangeControlColor(TextBox control, Color color)
        {
            if (control != null)
            {
                control.Background = new SolidColorBrush(color);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // RelayCommand class implementation

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}