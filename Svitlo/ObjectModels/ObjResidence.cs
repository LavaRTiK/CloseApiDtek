using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.ObjectModels
{
    public class ObjResidence
    {
        public string name { get;set; }
        public int idCity { get;set; }
        public string city {  get; set; }
        public int idStreet {  get; set; }
        public string street {  get; set; }
        public int idHouse { get; set; }
        public string house { get; set; }

        public ObjResidence(string name,int idCity,string city,int idStreet,string street,int idHouse,string house)
        {
            this.name = name;
            this.idCity = idCity;
            this.city = city;
            this.idStreet = idStreet;
            this.street = street;
            this.idHouse = idHouse;
            this.house = house;
        }
    }
}
