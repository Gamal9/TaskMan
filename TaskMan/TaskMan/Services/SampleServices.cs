
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Models;

namespace MVVM_Task.Services
{
    public class SampleServices
    {
        //sample Api Json Text
        private const string conn = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();
        ObservableCollection<Sample> _sample;
        public async Task<ObservableCollection<Sample>> GetAll()
        {
            var content = await _client.GetStringAsync(conn);
            var json = JsonConvert.DeserializeObject<List<Sample>>(content);
            _sample = new ObservableCollection<Sample>(json);
            return _sample;
        }


    }
}
