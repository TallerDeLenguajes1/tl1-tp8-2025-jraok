using System;
using EspacioTareas;

// listas para las tareas pendientes y completadas
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasCompletadas = new List<Tarea>();

// variables para el manejo del menu y entradas de caracteres
int opcion, indice = 1;
string? entrada;

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
    entrada = Console.ReadLine();
    if (!int.TryParse(entrada,out opcion) || opcion < 1 || opcion > 5)
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
            do
            {
                if (tareasPendientes.Count == 0)
                {
                    Console.WriteLine("\n\t\tNO HAY TAREAS PENDIENTES");
                    break;
                }
                Console.WriteLine($"\t{"ID",-5} {"DESCRIPCION",-30} {"DURACION",9}");
                int idSelecionado;
                foreach (Tarea variable in tareasPendientes)
                {
                    Console.WriteLine($"\t{variable.TareaId,-5} {variable.Descripcion,-30} {variable.Duracion,9} min");
                }
                Console.Write("\n\tIngrese el ID de la tarea: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out idSelecionado))
                {
                    Tarea? seleccionada = tareasPendientes.Find(buscado => buscado.TareaId == idSelecionado);
                    if (seleccionada != null)
                    {
                        tareasPendientes.Remove(seleccionada);
                        tareasCompletadas.Add(seleccionada);
                        Console.WriteLine($"\t\tTAREA {seleccionada.TareaId} MARCADA CON EXITO");
                    }else{
                        Console.WriteLine("\t\tID NO ENCONTRADO");
                    }
                }else{
                    Console.WriteLine("\n\t\t---ENTRADA NO VALIDA---");
                }
                Console.WriteLine("\n\t\tDesea marcar otra tarea?\n\t Cualquier tecla para salir | ENTER para continuar");
                if (Console.ReadKey(true).Key!= ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
            break;
        case 2:
            Console.WriteLine("\n\t\t---TAREAS PENDIENTES---");
            if (tareasPendientes.Count != 0)
            {
                Console.WriteLine($"\t{"ID",-5} {"DESCRIPCION",-30} {"DURACION",9}");
                foreach (Tarea variable in tareasPendientes)
                {
                    Console.WriteLine($"\t{variable.TareaId,-5} {variable.Descripcion,-30} {variable.Duracion,9} min");
                }
            }else{
                Console.WriteLine("\n\t\tNO HAY TAREAS PENDIENTES");    
            }
            break;
        case 3:
            
            break;
        case 4:
            Console.WriteLine("\n\t\t---TAREAS PENDIENTES---");
            if (tareasPendientes.Count != 0)
            {
                Console.WriteLine($"\t{"ID",-5} {"DESCRIPCION",-30} {"DURACION",9}");
                foreach (Tarea variable in tareasPendientes)
                {
                    Console.WriteLine($"\t{variable.TareaId,-5} {variable.Descripcion,-30} {variable.Duracion,9} min");
                }
            }else{
                Console.WriteLine("\n\t\tNO HAY TAREAS PENDIENTES");    
            }

            Console.WriteLine("\n\t\t---TAREAS COMPLETADAS---");
            if (tareasCompletadas.Count != 0)
            {
                Console.WriteLine($"\t{"ID",-5} {"DESCRIPCION",-30} {"DURACION",9}");
                foreach (Tarea variable in tareasCompletadas)
                {
                    Console.WriteLine($"\t{variable.TareaId,-5} {variable.Descripcion,-30} {variable.Duracion,9} min");
                }
            }else{
                Console.WriteLine("\n\t\tNO HAY TAREAS COMPLETADAS");    
            }
            break;
    }
} while (true);