using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Svitlo.Component
{
    public class DataObjResidence
    {
        private static List<ObjResidence> saveObjResidences = new List<ObjResidence>();

        public async Task ReadData()
        {
            //Выгрузка с save.txt
            if (!File.Exists("save.txt"))
            {
                File.Create("save.txt").Close();
            }
            using (StreamReader sr = new StreamReader("save.txt"))
            {
                string data = await sr.ReadToEndAsync();
                saveObjResidences = JsonSerializer.Deserialize<List<ObjResidence>>(data);
            }
        }
        public async Task LoadData()
        {
            //Запись в save.txt
            if (!File.Exists("save.txt"))
            {
                File.Create("save.txt").Close();
            }
            using (StreamWriter sw = new StreamWriter("save.txt"))
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                };
                string data = JsonSerializer.Serialize(saveObjResidences,options);
                await sw.WriteAsync(data);
            }
        }
        public void Add(ObjResidence obj)
        {
            saveObjResidences.Add(obj);
        }
        public List<ObjResidence> GetAll()
        {
            return saveObjResidences;
        }
    }
}
