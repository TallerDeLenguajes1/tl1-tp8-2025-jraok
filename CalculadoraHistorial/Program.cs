using EspacioCalculadoraHistorial;

// variables para el programa
double numero = 0,memoria = 0;
bool continuar = true;
int opcion = 0;
string operacionMenu;
// instancia de la clase CalculadoraHistorial
List<Operacion> historial = new List<Operacion>();

// estructura logica para el programa
do{
    Console.Clear();
    Console.WriteLine(new string('-', 50)); // separador visual
    // menu de opciones
    Console.WriteLine("\n\t\t----TALLER DE LENGUAJES I----");
    Console.WriteLine("\t\tMenu de opciones");
    Console.WriteLine("\t1. Sumar");
    Console.WriteLine("\t2. Restar");
    Console.WriteLine("\t3. Multiplicar");
    Console.WriteLine("\t4. Dividir");
    Console.WriteLine("\t5. Borrar Historial");
    Console.WriteLine("\t6. Mostrar Historial");
    Console.Write("\n\tElija una opción (ENTER PARA CANCELAR): ");
    operacionMenu = Console.ReadLine();     /* lectura de la opcion elegida del menu */

    if(string.IsNullOrEmpty(operacionMenu))break; /* verificacion de la cancelacion */

    // verificacion que no se ingrese un string u opcion invalida
    if(!int.TryParse(operacionMenu, out opcion) || (opcion < 1 || opcion > 6)){
        Console.WriteLine("\t\t---ERROR OPCION NO VALIDA, REINGRESE---");
        continue; /* salto al proximo ciclo en caso de que la entrada sea invalida */
    }
    // si la opcion es 6 muestro el historial
    if (opcion == 6)
    {
        Console.WriteLine("\n\t\t---HISTORIAL---");
        if (historial.Count > 0)    /* verifico que hay operaciones en el historial */
        {
            Console.WriteLine($"\n\t{"| OPERACIÓN", -13} {"| NUMERO_INGRESADO", -17} {"| RESULTADO_ANTERIOR", -19} {"| RESULTADO", -10}");  /* mensaje con las columnas de datos */
            Console.WriteLine(new string('-',80));  /* separador visual */
            foreach (Operacion actual in historial) /* recorro el historial */
            {
                Console.WriteLine($"\t| {actual.OperacionGuardada, -11} | {actual.NuevoValor, -16} | {actual.ResultadoAnterior, -18} | {actual.Resultado, -10}");   /* impresion de los datos de cada operacion */
            }
        }else{
            Console.WriteLine("\n\t\t---HISTORIAL VACÍO---");   /* mensaje de historial vacio */
        }
        goto preguntaContinuar; /* despues de mostrar el historial salto al mensaje de continuar */
    }
    /* nueva instancia para la lista */
    Operacion nueva = null;
    /* si la opcion no es limpiar */
    if (opcion != 5)
    {       
        Console.Write("\n\tIngrese el número a operar: ");  /* mensaje para el numero a operar */
        string entrada = Console.ReadLine(); /* lectura de la entrada del usuario */
        if (double.TryParse(entrada, out numero))   /* verifico que se haya ingresado un numero */
        {      
            // switch de opciones con la configuracion para cada tipo de operacion
            switch(opcion){
                case 1: nueva = new Operacion(TipoOperacion.Sumar, numero, memoria); break;
                case 2: nueva = new Operacion(TipoOperacion.Restar, numero, memoria); break;
                case 3: nueva = new Operacion(TipoOperacion.Multiplicar, numero, memoria); break;
                case 4: nueva = new Operacion(TipoOperacion.Dividir, numero, memoria); break;
            }
            // logica para guardar el resultado de la operacion
            memoria = (!double.IsNaN(nueva.Resultado)) ? nueva.Resultado : memoria; /* si el resultado es invalido mantengo el ultimo valor */
            historial.Add(nueva);   /* agrego la nueva operacion al historial */
            // impresion del resultado de la operacion
            Console.WriteLine(!double.IsNaN(nueva.Resultado) ? /* solo imprimo si el resultado es valido */
                    $"\n\tResultado de la operación: {nueva.Resultado}" 
                    : "\n\t\t---OPERACIÓN INVÁLIDA---");
        }else{
            Console.WriteLine("\n\t\tENTRADA INVALIDA");    /* mensaje en caso de ingresar un string */
        }
    }else{  /* logica para limpiar el historial */
        historial.Clear();  /* metodo para limpiar el historial */
        Console.WriteLine("\n\t\t---HISTORIAL BORRADO---"); /* mensaje de exito */
        memoria = 0;    /* reestablesco la memoria en 0 */
        nueva = new Operacion(TipoOperacion.Limpiar, 0, memoria);   /* envio un 0 para el numero ingresado */
        historial.Add(nueva);   /* agrego la nueva operacion al historial */
    }
    /* salto para despues de mostar el historial */
    preguntaContinuar:
    /* bucle para continuar operando */
    do{
        Console.Write("\n\t\tDesea continuar? (ESC = NO | ENTER = SÍ): ");
        ConsoleKey tecla = Console.ReadKey(true).Key;
        if(tecla == ConsoleKey.Escape || tecla == ConsoleKey.Enter){    /* solo entra si se apreto esc o enter */
            continuar = (tecla == ConsoleKey.Enter) ? true : false; /* le asigno un valor a continuar segun la tecla que se apreto */
            break;
        }
        Console.WriteLine("\n\t\t---OPCIÓN NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumplae el if se rompe el bucle */

}while(continuar);