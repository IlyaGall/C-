using System;

namespace Otus.Generics.Demo
{
    interface ICoVar<T> { }

    class CoVar<T> : ICoVar<T> { }


    class Vehicle { }

    class Automobile : Vehicle
    {
    }


    public class CoContrVarShower 
    {


        private void DemonstrateContrVar(IMyComparator<Vehicle> vs)
        {
            Console.WriteLine($"{vs}");
        }


        interface IDemo<out T> { }

        class ClassDemo<T> : IDemo<T> { }

        public void Show()
        {
            Automobile auto = new Automobile();
            Vehicle vehicle = new Vehicle();

            // Так можно
            vehicle = auto;



            IDemo<Automobile> demoAuto = new ClassDemo<Automobile>();
            IDemo<Vehicle> demoVehicle = new ClassDemo<Vehicle>();

            // а так - нельзя
            demoVehicle = demoAuto;



            //ICoVar<Automobile> auto1 = new CoVar<Automobile>();
            //ICoVar<Vehicle> vec = new CoVar<Vehicle>();

            //// Теперь можно приводить Automobile к Vehicle
            //vec = auto1;


            IMyComparator<Automobile> autocontr = new MyComparator<Vehicle>();

            autocontr.Build(new Automobile());

        }
    }







    interface IMyComparator<in T>
    {
        void Build(T v);
    }

    class MyComparator<T> : IMyComparator<T>
    {
        public void Build(T v) { }
    }



}