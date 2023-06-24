using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Commands;
using WpfApp2.ViewModels;

namespace WpfApp2
{
    public class TestWindowViewModel: ViewModelBase
    {
        private ViewModelBase activeView = new Sub2ViewModel();

        //画面に表示するUserControlのViewModelを設定するプロパティ
        public ViewModelBase ActiveView
        {
            get { return activeView; }
            set
            {
                if (activeView != value)
                {
                    activeView = value;
                    OnPropertyChanged("ActiveView");
                }
            }
        }

        public DelegateCommand ScreenChangeCommand { get; }

        public TestWindowViewModel()
        {
            ScreenChangeCommand = new DelegateCommand(_screenTransitionExcute);
        }

        private void _screenTransitionExcute(string param)
        {
            switch (param)
            {
                case "MainView":
                    ActiveView = new MainViewModel();
                    break;
                case "Sub1View":
                    ActiveView = new Sub1ViewModel();
                    break;
                case "Sub2View":
                    ActiveView = new Sub2ViewModel();
                    break;
            }
        }

    }
}
