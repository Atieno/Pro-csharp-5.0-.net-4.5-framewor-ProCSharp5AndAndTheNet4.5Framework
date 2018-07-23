using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Program
    {
        class Radio 
        {
            public void TurnOn(bool on)
            {
                if(on)
                    Console.WriteLine("Jamming....");
                else
                {
                    Console.WriteLine("Quiet time...");
                }
            }
            
        }

        class  Car
        {
            //constant for max speed
            public const int MaxSpeed = 100;

            //Car Properties
            public int CurrentSpeed { get; set; }
            public string PetName { get; set; }

            //Is the car Still operational?
            private bool CarIsDead;

            //Containment Car has-a-radio
            private Radio theMusicBox=new Radio();

            //Constructors
            public Car() { }

            public Car(string name, int speed)
            {
                PetName = name;
                CurrentSpeed = speed;
            }

            public void CrankTunes(bool state)
            {
                //Delegate request to inner object
                theMusicBox.TurnOn(state);
            }
            //is the care overheated?
            public void Accelerate(int delta)
            {
                if(CarIsDead)
                    Console.WriteLine("{0} is out of order", PetName);
                else
                {
                    CurrentSpeed += delta;
                    if (CurrentSpeed > MaxSpeed)
                    {
                        Console.WriteLine("{0} has overheated! " , PetName);
                        CurrentSpeed = 0;
                        CarIsDead = true;
                    }
                    else
                        Console.WriteLine("=> CurrentSpeed={0}", CurrentSpeed);
                    
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=> Creating a Car and stepping on it!");
            Car myCar=new Car("Daniella",20);
            myCar.CrankTunes(true);

            for (int i = 0; i < 10; i++)           
                myCar.Accelerate(10);

                Console.ReadLine();
            
        }
    }
}
