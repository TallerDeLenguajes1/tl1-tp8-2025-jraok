namespace EspacioCalculadoraHistorial
{
    public class Calculadora
    {
        private double dato;
        public double Resultado { get { return dato; } }
        public void Sumar(double numero)
        {
            dato += numero;
        }

        public void Restar(double numero)
        {
            dato -= numero;
        }

        public void Multiplicar(double numero)
        {
            dato *= numero;
        }

        public void Dividir(double numero)
        {
            if (numero != 0)
            {
                dato /= numero;
            }
            else
            {
                Console.WriteLine("\n\tValor invalido, no se puede dividir por 0");
            }
        }
        public void Limpiar()
        {
            dato = 0;
        }
    }
}