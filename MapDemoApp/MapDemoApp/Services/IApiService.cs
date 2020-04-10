using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapDemoApp.Services
{
    interface IApiService
    {
        Task<bool> CheckConnectionAsync(string url);
    }
}
