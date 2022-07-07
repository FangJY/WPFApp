using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using GdutApp.IWebApi;
using Microsoft.Extensions.DependencyInjection;

namespace GdutApp.Model
{
    [INotifyPropertyChanged]
    public partial class FactoryBase
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private ObservableCollection<Server> server = new ObservableCollection<Server>();
    }

}
