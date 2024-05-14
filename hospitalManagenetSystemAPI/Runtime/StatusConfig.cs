using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hospitalManagenetSystemAPI.Runtime
{
    public class StatusConfig
    {
        public StatusConfig readData()
        {
            string file = File.ReadAllText("D:\\Tugas\\Tugas Kuliah\\Semester 4\\KPL\\KPL-CoffeJava\\hospitalManagenetSystemAPI\\Runtime\\Error.json");
            StatusConfig data = JsonConvert.DeserializeObject<StatusConfig>(file);
            return data;
        }
        
        public class Error
        {
            public string overload_patient { get; set; }
            public string wrong_password { get; set; }
            public string wrong_username { get; set; }
            public string bad_request { get; set; }
            public string access_denied { get; set; }
            public string resource_not_found { get; set; }
        }

        public Error error { get; set; }

        public class Success
        {
            public string login_successful { get; set; }
            public string logout_successful { get; set; }
            public string record_created { get; set; }
            public string record_updated { get; set; }
            public string record_deleted { get; set; }
        }

        public Success success { get; set; }

    }
}