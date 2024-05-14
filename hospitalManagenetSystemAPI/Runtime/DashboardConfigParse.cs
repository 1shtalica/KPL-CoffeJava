using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hospitalManagenetSystemAPI.Runtime
{
    public class DashboardConfigParse
    {
        public DashboardConfigParse readData()
        {
            string file = File.ReadAllText("E:\\Kuliah\\Tugas\\MATKUL\\Semester 4\\Konstruksi Perangkat Lunak\\TUBES\\Proggress#6\\KPL-CoffeJava\\hospitalManagenetSystemAPI\\Runtime\\DashboardConfig.json");
            DashboardConfigParse data = JsonConvert.DeserializeObject<DashboardConfigParse>(file);
            return data;
        }

        public class Id
        {
            public string dashboard {  get; set; }
            public string patients {  get; set; }
            public string appointments { get; set; }
            public string medicalRecords { get; set; }
            public string settings { get; set; }
            public string logout { get; set; }
        }

        public Id id { get; set; }
        public class En
        {
            public string dashboard { get; set; }
            public string patients { get; set; }
            public string appointments { get; set; }
            public string medicalRecords { get; set; }
            public string settings { get; set; }
            public string logout { get; set; }
        }

        public En en { get; set; }

    }

        
}