namespace EspacioCalculadoraHistorial
{
    // enum con las operaciones posibles para esta calculadora
    public enum TipoOperacion{
        Sumar,
        Restar,
        Multiplicar,
        Dividir,
        Limpiar,
    }
    // clase para las operaciones de la calculadora
    public class Operacion{ 
        // campos de la clase con lso datos a guardar
        private TipoOperacion operacionGuardada;
        private double resultadoAnterior;
        private double nuevoValor;

        // propiedades publicas para leer los campos
        public TipoOperacion OperacionGuardada => operacionGuardada;
        public double ResultadoAnterior => resultadoAnterior;        
        public double NuevoValor => nuevoValor;
        
        // constructor para la creacion de una instancia nueva
        public Operacion(TipoOperacion operacion, double nuevoValor, double resultadoAnterior){
            this.operacionGuardada = operacion;
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
        }
        // propiedad publica para mostrar las operaciones de la calculadora
        public double Resultado{
            get{
                return operacionGuardada switch{
                    TipoOperacion.Sumar => resultadoAnterior + nuevoValor,
                    TipoOperacion.Restar => resultadoAnterior - nuevoValor,
                    TipoOperacion.Multiplicar => resultadoAnterior * nuevoValor,
                    TipoOperacion.Dividir => nuevoValor != 0 ? resultadoAnterior/nuevoValor : double.NaN,
                    TipoOperacion.Limpiar => 0,
                    _ => resultadoAnterior
                };
            }
        }
    }
}