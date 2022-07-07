using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GdutApp.Model;
using Refit;

namespace GdutApp.IWebApi
{
    internal interface ILocalJson
    {
        [Post("/Files/Servers.json")]
        Task<List<FactoryJson>> GetFactoryJsons();
    }
}
