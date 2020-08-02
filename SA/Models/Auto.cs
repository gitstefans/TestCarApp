using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SA.Models
{
    public class Auto
    {
        
        //dodavanje novog auta
        public static void AddCar(Car car)
        {
            if(car != null)
            {
                TESTCARContext dataContext = new TESTCARContext();
                dataContext.Car.Add(car);
                dataContext.SaveChanges();  
                
            }
        }
        //vraca listu auta
        public static List<Car> GetCar()
        {

            TESTCARContext dataContext = new TESTCARContext();
            return dataContext.Car.ToList();
            
            
            //return cars;
        }
        public static Car GetCar(int id)
        {

            TESTCARContext dataContext = new TESTCARContext();
            return dataContext.Car.FirstOrDefault(e => e.Id == id);


            //return cars;
        }

    }
}
