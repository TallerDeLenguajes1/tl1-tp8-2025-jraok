namespace EspacioCalculadoraHistorial
{
    // enum con las operaciones posibles para esta calculadora
    enum TipoOperacion{
        Sumar,
        Restar,
        Multiplicar,
        Dividir,
        Limpiar,
    }
    // clase para las operaciones de la calculadora
    public class Operacion{ 
        // campos de la clase con lso datos a guardar
        private TipoOperacion operacion;
        private double resultadoAnterior;
        private double nuevoValor;

        // propiedades publicas para leer los campos
        public TipoOperacion Operacion => operacion;
        public double ResultadoAnterior => resultadoAnterior;        
        public double nuevoValor => nuevoValor;
        
        // constructor para la creacion de una instancia nueva
        public Operacion(TipoOperacion operacion, double nuevoValor, double resultadoAnterior){
            this.operacion = operacion;
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
        }
        // propiedad publica para mostrar las operaciones de la calculadora
        public double Resultado{
            get{
                return operacion switch{
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