using System;
using EspacioTareas;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasCompletadas = new List<Tarea>();

int opcion, indice = 1;
string entrada, entradaMenu;

Console.WriteLine("\n\t\t---TALLER DE LENGUAJES I---");
Console.WriteLine("\n\t\tAgregando tareas pendientes...");
do
{
    Console.Write($"Ingrese la descripcion para la tarea {indice}: ");
    entrada = Console.ReadLine();
    try
    {
        Tarea nuevaTarea = new Tarea(entrada!, indice+999);
        tareasPendientes.Add(nuevaTarea);
        indice++;
    }
    catch (ArgumentException error)
    {
        Console.WriteLine($"ERROR: {error.Message}, TAREA CANCELADA");
    }
    Console.WriteLine("\n\t\tDesea terminar la carga?\n\t Cualquier tecla para salir | ENTER para continuar");
    
    if (Console.ReadKey(true).Key != ConsoleKey.Enter)
    {
        break;
    }

} while (true);