using EspacioCalculadoraHistorial;

// variables para el programa
double numero = 0,resultado = 0;
bool continuar;
int opcion = 0;
string operacionMenu;
// instancia de la clase CalculadoraHistorial
List<Operacion> historial = new List<Operacion>();

// estructura logica para el programa
do{
    // menu de opciones
    Console.WriteLine("\n\t\t----Taller de lenguajes 1----");
    Console.WriteLine("\t\tMenu de opciones");
    Console.WriteLine("\t1. Sumar");
    Console.WriteLine("\t2. Restar");
    Console.WriteLine("\t3. Multiplicar");
    Console.WriteLine("\t4. Dividir");
    Console.WriteLine("\t5. Limpiar");
    Console.WriteLine("\t6. Mostrar Historial");
    Console.Write("\n\tElija una opcion (ENTER PARA CANCELAR): ");
    operacionMenu = Console.ReadLine();     /* lectura de la opcion elegida del menu */

    if(string.IsNullOrEmpty(operacionMenu))break; /* verificacion de la cancelacion */

    // verificacion que no se ingrese un string u opcion invalida
    if(!int.TryParse(operacionMenu, out opcion) || (opcion < 1 || opcion > 6)){
        Console.WriteLine("\t\t---ERROR OPCION NO VALIDA, REINGRESE---");
        continue; /* salto al proximo ciclo en caso de que la entrada sea invalida */
    }

    Console.Write("\n\tIngrese el número a operar: ");
    string entrada = Console.ReadLine(); /* lectura de la entrada del usuario */
    if (double.TryParse(entrada, out numero))
    {    
        switch(opcion){
            case 1:
                Operacion nueva = new Operacion(TipoOperacion.Sumar, numero, resultado);
                break;
            case 2:
                Operacion nueva = new Operacion(TipoOperacion.Restar, numero, resultado);
                break;
            case 3:
                Operacion nueva = new Operacion(TipoOperacion.Multiplicar, numero, resultado);
                break;
            case 4:
                Operacion nueva = new Operacion(TipoOperacion.Dividir, numero, resultado);
                break;
            case 5:
                Operacion nueva = new Operacion(TipoOperacion.Limpiar, numero, resultado);
                break;
            resultado = nueva.Resultado;
            historial.Add(nueva);
            if (!double.IsNaN(resultado))
            {
                Console.WriteLine($"\n\tResultado de la operacion: {resultado}");   
            }else{
                Console.WriteLine("\n\t\t---OPERACION INVALIDA---");   
            }
        }
    }else{
        Console.WriteLine("\n\t\tENTRADA INVALIDA");
    }
    
    do{
        Console.Write("\n\tDesea continuar? (ESC = NO | ENTER = SI): ");
        ConsoleKey tecla = Console.ReadKey().Key;
        if(tecla == ConsoleKey.Escape || tecla == ConsoleKey.Enter){
            continuar = (tecla == ConsoleKey.Enter) ? true : false;
            break;
        }
        Console.WriteLine("\n\t---OPCION NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumplae el if se rompe el bucle */

    Console.WriteLine(new string('-', 50)); // separador visual
}while(continuar);