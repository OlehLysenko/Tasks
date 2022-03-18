using System;
using System.Collections.Generic;
using System.Text;

namespace TestParking
{
    enum ModelCar
    {
        Toyota,
        Peugeot,
        Mercedes,
        Fiat,
        Hyundai,
        Nissan,
        BMW,
        Porsche,
        Audi,
        Lamborghini,
        Bugatti,
        Skoda,
        Woklswagen,
    }
    class Car
    {
        public Car()
        {
            modelCar = (ModelCar)(rnd.Next(0, Enum.GetNames(typeof(ModelCar)).Length));
            yearCar = rnd.Next(1950, 2021);
            parkingTimeIn = DateTime.Now;
        }
        Random rnd = new Random();
        private ModelCar modelCar;

        public ModelCar ModelCar
        {
            get { return modelCar; }
            set { modelCar = value; }
        }
        private int yearCar;
        public int YearCar 
        {
            get { return yearCar; }
            set { yearCar = value; }
        }
        private DateTime parkingTimeIn;
        public DateTime ParkingTimeIn
        {
            get { return parkingTimeIn; }
            set { parkingTimeIn = value; }
        }

        private DateTime parkingTimeOut;
        public DateTime ParkingTimeOut
        {
            get { return parkingTimeOut = DateTime.Now; }
            set { parkingTimeIn = DateTime.Now; }
        }
        

    }
}
