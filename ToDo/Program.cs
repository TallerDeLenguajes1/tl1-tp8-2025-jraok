using System;
using EspacioTareas;
using Internal;

// listas para las tareas pendientes y completadas
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasCompletadas = new List<Tarea>();

// variables para el manejo del menu y entradas de caracteres
int opcion, indice = 1;
string entrada, entradaMenu;

// mensajes
Console.WriteLine("\n\t\t---TALLER DE LENGUAJES I---");
Console.WriteLine("\n\t\tAgregando tareas pendientes...");

// bucle para ingresar tareas pendientes
do
{
    Console.Write($"Ingrese la descripcion para la tarea {indice}: "); /* mensaje para indicar la tarea por inciar */
    entrada = Console.ReadLine();   /* entrada para la descripcino */
    /* try catch en caso de  un descripcion vacía */
    try
    {
        // nueva tarea creada con el constructor, para evitar el warning fuerzo entrada con !
        Tarea nuevaTarea = new Tarea(entrada!, indice+999); /* nuevo objeto para la lista de tareas pendientes */
        tareasPendientes.Add(nuevaTarea);   /* agreagado de la nueva tarea a la lista */
        indice++;   /* incremento del indice */
    }
    catch (ArgumentException error) /* captura del error en caso de descripcion vacia */
    {
        Console.WriteLine($"ERROR: {error.Message}, TAREA CANCELADA");  /* mensaje de error */
    }
    /* mensaje para continuar la carga */
    Console.WriteLine("\n\t\tDesea terminar la carga?\n\t Cualquier tecla para salir | ENTER para continuar");
    if (Console.ReadKey(true).Key != ConsoleKey.Enter)  /* la condicion pide que sea distinto de enter para salir */
    {
        break;
    }
} while (true);

do
{
    Console.WriteLine("\n\t\t---Menu de opciones---");
    Console.WriteLine("\t1-Marcar como completada");
    Console.WriteLine("\t2-Listar tareas pendientes");
    Console.WriteLine("\t3-Buscar por descripcion");
    Console.WriteLine("\t4-Listar todas las tareas");
    Console.WriteLine("\t5-Salir");
    Console.Write("\n\tIngrese una opcion: ");
    entradaMenu = Console.ReadLine();
    if (!int.TryParse(entradaMenu,out opcion) || opcion < 1 || opcion > 5)
    {
        Console.WriteLine("\n\t\t---OPCION IVALIDA REINGRESE---");
        continue;
    }
    if (opcion == 5)
    {
        break;
    }
    switch (opcion)
    {
        case 1:
            Console.WriteLine("\n\t\t---TAREAS PENDIENTES---");
            if (tareasPendientes.Count == 0)
            {
                Console.WriteLine("\n\t\tNO HAY TAREAS PENDIENTES");
                break;
            }
           
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
    }
} while (true);