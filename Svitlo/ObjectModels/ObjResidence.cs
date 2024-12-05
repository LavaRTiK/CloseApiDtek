using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.ObjectModels
{
    public class ObjResidence
    {
        public string Name { get;set; }
        public int IdCity { get;set; }
        public string City {  get; set; }
        public int IdStreet {  get; set; }
        public string Street {  get; set; }
        public int IdHouse { get; set; }
        public string House { get; set; }
        public bool IsFollowing { get; set; }

        public ObjResidence(string name,int idCity,string city,int idStreet,string street,int idHouse,string house)
        {
            this.Name = name;
            this.IdCity = idCity;
            this.City = city;
            this.IdStreet = idStreet;
            this.Street = street;
            this.IdHouse = idHouse;
            this.House = house;
            this.IsFollowing = false;
            
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
