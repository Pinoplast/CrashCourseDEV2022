using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Team1_WpfApp.Fairytale
{
    public class Building : IBuilding
    {
        public string Name { get; set; }

        public string GetMesssage()
        {
            return $"Я називаю свій будиночок '{this.Name}'!\n" +
                  $"Він має міцність {this.buildingSolidity()} \n";
        }

        // ----------

        public bool buildingStatus = true; // whether it is intact or destroyed

        private IMaterial _base;
        private IMaterial wall;
        private IMaterial roof;

        public Building(string buildingName, IMaterial _base, IMaterial wall, IMaterial roof)
        {
            this.Name = buildingName;
            this._base = _base;
            this.wall = wall;
            this.roof = roof;
        }       

        public int buildingSolidity()
        {
            return _base.Strength + wall.Strength + roof.Strength;
        }

       
    }
}
