using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCombBoxUserControl.MyControl;

namespace TextCombBoxUserControl
{
    public class ViewModel : BindableBase
    {
        private Data _data = new Data() { de = "1", m = "2", di = "×" };
        //private Data _data;
        public Data Data { get => _data; set => SetProperty(ref _data, value, nameof(Data)); }

        private Data _data2 = new Data() { de = "3", m = "4", di = "△" };
        //private Data _data2;
        public Data Data2 { get => _data2; set => SetProperty(ref _data2, value, nameof(Data)); }
    }
}
