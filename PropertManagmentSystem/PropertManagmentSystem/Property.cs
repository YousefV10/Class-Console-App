using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    public record Property
    {
       

       public  int Id { get; init;  }
      public   String Adress{ get; init;  }
       public Decimal Area{ get; init;  }
        public int FloorCount { get; init;  }
        public bool HasGarage1 { get; init;  }


        public Property(int id, string adress, decimal area , int floorC , bool garage )
        {

            Id = id;
            Adress = adress;
            Area = area;
            FloorCount = floorC;
            HasGarage1 = garage;
        }
    }
}
