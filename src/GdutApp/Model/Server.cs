using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GdutApp.Model
{
    [INotifyPropertyChanged]
    public partial class Server
    {
        [ObservableProperty]
        private string ip;
        [ObservableProperty]
        private string camstarSecurityLMServerStatus;
        [ObservableProperty]
        private string camstarSecurityServerStatus;
        [ObservableProperty]
        private string camstarServerStatus;
        [ObservableProperty]
        private int cpuRate;
        [ObservableProperty]
        private int sdic;
    }
}
