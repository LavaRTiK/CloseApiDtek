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

        public async Task ReadDataAsync()
        {
            //Выгрузка с save.txt
            if (!File.Exists("save.json"))
            {
                File.Create("save.json").Close();
            }
            using (StreamReader sr = new StreamReader("save.json"))
            {
                string data = await sr.ReadToEndAsync();
                if(!string.IsNullOrWhiteSpace(data))
                {
                    try
                    {
                        saveObjResidences =JsonSerializer.Deserialize<List<ObjResidence>>(data);
                    }
                    catch (JsonException ex) {
#if DEBUG
                        MessageBox.Show("Ошибка JSON" + ex.Message);
#endif
                        saveObjResidences = new List<ObjResidence>();
                    }
                }
                else
                {
                    saveObjResidences = new List<ObjResidence>();
                }
            }
        }
        public async Task LoadDataAsync()
        {
            //Запись в save.txt
            if (!File.Exists("save.json"))
            {
                File.Create("save.json").Close();
            }
            using (StreamWriter sw = new StreamWriter("save.json"))
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                };
                string data = JsonSerializer.Serialize(saveObjResidences,options);
                await sw.WriteAsync(data);
            }
        }
        public void Remove(ObjResidence obj)
        {
            saveObjResidences.Remove(obj);
        }
        public void Add(ObjResidence obj)
        {
            saveObjResidences.Add(obj);
        }
        public List<ObjResidence> GetAll()
        {
            return saveObjResidences;
        }
        public void EditIsFollowing(string name,bool isFollowing)
        {
            saveObjResidences[saveObjResidences.FindIndex(x => x.Name == name)].IsFollowing = isFollowing;
        }
    }
}
