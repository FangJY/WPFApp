using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using GdutApp.IWebApi;
using GdutApp.Model;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

namespace GdutApp.ViewModel
{

    [INotifyPropertyChanged]
    public partial class MainWindowVM
    {
        [ObservableProperty]
        private string? firstName;

        [ObservableProperty]
        private ObservableCollection<FactoryBase> factorys = new ObservableCollection<FactoryBase>();

        [ObservableProperty]
        ObservableCollection<Server> servers = new ObservableCollection<Server>();

        private ILocalJson localJson;
        public MainWindowVM(IServiceProvider serviceProvider)
        {
            localJson = (ILocalJson)serviceProvider.GetService(typeof(ILocalJson));

            var sd = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/Files/Servers.json");
            List<FactoryJson> FactoryJsons = JsonConvert.DeserializeObject<List<FactoryJson>>(sd);

            FactoryJsons.ForEach(p =>
            {
                Factorys.Add(new FactoryBase()
                {
                    Name = p.BaseName,
                    Server = new ObservableCollection<Server>(p.Hosts.Select(p => new Server()
                    {
                        Ip = p
                    }).ToList())
                }) ;
            });

        }
    }
}
