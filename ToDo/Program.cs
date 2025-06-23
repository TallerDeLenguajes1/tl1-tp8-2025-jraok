using System;
using EspacioTareas;

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

