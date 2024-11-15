using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Transportes
{


    abstract class Transporte
    {
        public double Distancia { get; set; }
        public double Tiempo { get; set; }

        public Transporte(double distancia, double tiempo)
        {
            Distancia = distancia;
            Tiempo = tiempo;
        }

        public abstract double Calcularprecio();
    }

    class Taxi : Transporte
    {
        private double TarifaBase = 150;
        private double TarifaPorKm = 25;

        public Taxi(double distancia, double tiempo) : base(distancia, tiempo) { }

        public override double Calcularprecio()
        {
            return TarifaBase + (Distancia * TarifaPorKm);
        }
    }

    class Metro : Transporte
    {
        private double TarifaFija = 20;

        public Metro(double distancia, double tiempo) : base(distancia, tiempo) { }

        public override double Calcularprecio()
        {
            return TarifaFija;
        }
    }

    class Teleferico : Transporte
    {
        private double TarifaFija = 20;

        public Teleferico(double distancia, double tiempo) : base(distancia, tiempo) { }

        public override double Calcularprecio()
        {
            return TarifaFija;
        }
    }

    class BusUrbano : Transporte
    {
        private double TarifaBase = 10;
        private double TarifaPorKm = 2;

        public BusUrbano(double distancia, double tiempo) : base(distancia, tiempo) { }

        public override double Calcularprecio()
        {
            double kmExtras = (Distancia > 5) ? (Distancia - 5) : 0;
            return TarifaBase + (kmExtras * TarifaPorKm);
        }
    }

    class BusInterurbano : Transporte
    {
        private double TarifaBase = 50;
        private double TarifaPorKm = 5;

        public BusInterurbano(double distancia, double tiempo) : base(distancia, tiempo) { }

        public override double Calcularprecio()
        {
            return TarifaBase + (Distancia * TarifaPorKm);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la distancia del viaje en kilómetros:");
            double distancia = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tiempo del viaje en horas:");
            double tiempo = double.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el tipo de transporte:");
            Console.WriteLine("1. En taxi");
            Console.WriteLine("2. En metro");
            Console.WriteLine("3. En teleférico");
            Console.WriteLine("4. En bus Urbano");
            Console.WriteLine("5. En bus Interurbano");

            int opcion = int.Parse(Console.ReadLine());
            Transporte transporte = null;

            switch (opcion)
            {
                case 1:
                    transporte = new Taxi(distancia, tiempo);
                    break;
                case 2:
                    transporte = new Metro(distancia, tiempo);
                    break;
                case 3:
                    transporte = new Teleferico(distancia, tiempo);
                    break;
                case 4:
                    transporte = new BusUrbano(distancia, tiempo);
                    break;
                case 5:
                    transporte = new BusInterurbano(distancia, tiempo);
                    break;
                default:
                    Console.WriteLine("Vuelva a intentarlo");
                    return;
            }

            double costo = transporte.Calcularprecio();
            Console.WriteLine($"El costo del boleto es: {costo} RD$");
        }
    }



}
