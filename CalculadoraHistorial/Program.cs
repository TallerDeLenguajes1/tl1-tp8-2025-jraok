using EspacioCalculadoraHistorial;

// variables para el programa
double numero = 0;
bool continuar;
int opcion = 0;
string operacionMenu;
// instancia de la clase CalculadoraHistorial
List<Operacion> historial = new List<Operacion>();

// estructura logica para el programa
do{
    // menu de opciones
    Console.WriteLine("\n\t\t----Taller de lenguajes 1----");
    Console.WriteLine("\tMenu de opciones");
    Console.WriteLine("\t1. Sumar");
    Console.WriteLine("\t2. Restar");
    Console.WriteLine("\t3. Multiplicar");
    Console.WriteLine("\t4. Dividir");
    Console.WriteLine("\t5. Limpiar");
    Console.WriteLine("\t6. Historial");
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

    switch(opcion){
        
    }
    
    
    do{
        Console.Write("\n\tDesea continuar? (ESC = NO | ENTER = SI): ");
        ConsoleKey tecla = Console.ReadKey().Key;
        if(tecla == ConsolrKey.Escape || tecla == ConsoleKey.Enter){
            tecla == ConsolrKey.Escape ? continuar = false : continuar = true;
            break;
        }
        Console.WriteLine("\n\t---OPCION NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumpla se rompe el bucle */

    Console.WriteLine(new string('-', 50)); // separador visual
}while(continuar);