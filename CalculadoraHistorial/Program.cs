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

    if (opcion == 6)
    {
        Console.WriteLine("\n\t\t---HISTORIAL---");
        if (historial.Count > 0)
        {
            Console.WriteLine($"\n\t{"OPERACIÓN", 10} {"NUMERO_INGRESADO", 17} {"RESULTADO_ANTERIOR", 19} {"RESULTADO", 10}");
            Console.WriteLine(new string('-',48));
            foreach (Operacion actual in historial)
            {
                Console.WriteLine($"\n\t{actual.OperacionGuardada, 10} {actual.NuevoValor, 17} {actual.ResultadoAnterior, 19} {actual.Resultado, 10}");
            }
        }else{
            Console.WriteLine("\n\t\t---HISTORIAL VACÍO---");
        }
        goto preguntaContinuar;
    }
    
    Operacion nueva = null;

    if (opcion != 5)
    {       
        Console.Write("\n\tIngrese el número a operar: ");
        string entrada = Console.ReadLine(); /* lectura de la entrada del usuario */
        if (double.TryParse(entrada, out numero))
        {    
            switch(opcion){
                case 1: nueva = new Operacion(TipoOperacion.Sumar, numero, memoria); break;
                case 2: nueva = new Operacion(TipoOperacion.Restar, numero, memoria); break;
                case 3: nueva = new Operacion(TipoOperacion.Multiplicar, numero, memoria); break;
                case 4: nueva = new Operacion(TipoOperacion.Dividir, numero, memoria); break;
            }
            memoria = (!double.IsNaN(nueva.Resultado)) ? nueva.Resultado : memoria;
            historial.Add(nueva);
            Console.WriteLine(!double.IsNaN(memoria) ? 
                    $"\n\tResultado de la operación: {memoria}" 
                    : "\n\t\t---OPERACIÓN INVÁLIDA---");
        }else{
            Console.WriteLine("\n\t\tENTRADA INVALIDA");
        }
    }else{
        historial.Clear();
        Console.WriteLine("\n\t\t---HISTORIAL BORRADO---");
        memoria = 0;
        nueva = new Operacion(TipoOperacion.Limpiar, 0, memoria);
        historial.Add(nueva);
    }

    preguntaContinuar:
    do{
        Console.Write("\n\t\tDesea continuar? (ESC = NO | ENTER = SÍ): ");
        ConsoleKey tecla = Console.ReadKey(true).Key;
        if(tecla == ConsoleKey.Escape || tecla == ConsoleKey.Enter){
            continuar = (tecla == ConsoleKey.Enter) ? true : false;
            break;
        }
        Console.WriteLine("\n\t\t---OPCIÓN NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumplae el if se rompe el bucle */

}while(continuar);