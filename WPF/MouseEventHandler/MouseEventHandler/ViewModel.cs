using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MouseEventHandler
{
    public class ViewModel : INotifyPropertyChanged
    {
        public class OkCommandImpl : ICommand
        {
            public bool CanExecute(object parameter) { return true; }
            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                MessageBox.Show("コマンドが実行されました。");
            }

        }

        public class MouseMoveCommandImpl : ICommand
        {
            private ViewModel vm;

            public MouseMoveCommandImpl(ViewModel viewmodel)
            {
                vm = viewmodel;
            }

            public bool CanExecute(object parameter) { return true; }
            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                var element = (System.Windows.IInputElement)parameter;
                var X = Mouse.GetPosition(element).X;
                var Y = Mouse.GetPosition(element).Y;

                vm.X = X;
                vm.Y = Y;

                var x = X.ToString();
                var y = Y.ToString();
                Console.WriteLine($"X:{x}, Y:{y}");

            }
        }

        public class MouseEnterCommandImpl : ICommand
        {
            private ViewModel vm;

            public MouseEnterCommandImpl(ViewModel viewmodel)
            {
                vm = viewmodel;
            }

            public bool CanExecute(object parameter) { return true; }
            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                vm.Message = "Enter!";
                Console.WriteLine("Enter!");
            }

        }

        public class MouseLeaveCommandImpl : ICommand
        {
            private ViewModel vm;

            public MouseLeaveCommandImpl(ViewModel viewmodel)
            {
                vm = viewmodel;
            }

            public bool CanExecute(object parameter) { return true; }
            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                vm.Message = "Leave!";
                Console.WriteLine("Leave!");
            }

        }

        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    RaisePropertyChanged("X");
                }
            }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    RaisePropertyChanged("Y");
                }
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var d = PropertyChanged;
            if (d != null)
                d(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand OkCommand { get; private set; }
        public ICommand MouseMoveCommand { get; private set; }
        public ICommand MouseEnterCommand { get; private set; }
        public ICommand MouseLeaveCommand { get; private set; }

        public ViewModel()
        {
            this.OkCommand = new OkCommandImpl();
            this.MouseMoveCommand = new MouseMoveCommandImpl(this);
            this.MouseEnterCommand = new MouseEnterCommandImpl(this);
            this.MouseLeaveCommand = new MouseLeaveCommandImpl(this);
        }
    }
}