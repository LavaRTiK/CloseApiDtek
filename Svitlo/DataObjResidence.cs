using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Svitlo
{
    internal class DataObjResidence
    {
        List<SaveObjResidence> saveObjResidences = new List<SaveObjResidence>();

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
                saveObjResidences = JsonSerializer.Deserialize<List<SaveObjResidence>>(data);
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
                string data = JsonSerializer.Serialize(saveObjResidences);
                await sw.WriteAsync(data);
            }
        }
    }
}
