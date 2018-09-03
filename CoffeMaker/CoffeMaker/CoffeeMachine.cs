using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CoffeMaker
{
    public class CoffeeMachine
    {
        public double Water;
        public double Sugar;
        public double Coffee;

        public CoffeeMachine(double Water,double Sugar,double Coffee)
        {
            this.Water = Water;
            this.Sugar = Sugar;
            this.Coffee = Coffee;
        }
    }
}