using System;
using EspacioTareas;

// funcion par mostrar una lista de tareas 
static void MostrarTareas(List<Tarea> lista, string titulo)
{
    Console.WriteLine($"\n\t\t--- {titulo.ToUpper()} ---"); /* mensaje con el titulo en mayusculas */
    if (lista.Count != 0)   /* la condicion es que la lista contenga algun elemento */
    {
        Console.WriteLine($"\t{"ID",-5} {"DESCRIPCION",-50} {"DURACION",10}");  /* columnas con los datos de las tareas */
        Console.WriteLine("\t" + new string('-', 70));  /* linea separadora */
        foreach (Tarea tarea in lista)  /* recorrido de la lista */
        {
            Console.WriteLine($"\t{tarea.TareaId,-5} {tarea.Descripcion,-50} {tarea.Duracion,10} min"); /* impresion de los datos de la tarea */
        }
    }else{
        Console.WriteLine("\t\tNO HAY TAREAS"); /* mensaje para lista vacia */
    }
}

// listas para las tareas pendientes y completadas
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasCompletadas = new List<Tarea>();

                                    /* TAREAS PRECARGADAS PARA TESTEAR EL MENU DE OPCIONES DESCOMENTAR PARA SU USO Y COMENTAR LAS 
                                    LINEAS CON LAS LISTAS ANTERIORES Y LAS SIGUIENTES CON EL MODULO DE CARGA */
// List<Tarea> tareasPendientes = new List<Tarea>
// {
//     new Tarea("Revisar apuntes de programación", 1001),
//     new Tarea("Armar resumen de circuitos", 1002),
//     new Tarea("Leer capítulo de estructuras", 1003)
// };

// List<Tarea> tareasCompletadas = new List<Tarea>
// {
//     new Tarea("Entregar TP de lógica", 2001),
//     new Tarea("Asistir a clase de arquitectura", 2002),
//     new Tarea("Corregir errores del código en C", 2003)
// };
// variables para el manejo del menu y entradas de caracteres
int opcion, indice = 1;
string? entrada;

// mensajes
Console.WriteLine("\n\t\t---TALLER DE LENGUAJES I---");
Console.WriteLine("\n\t\tAgregando tareas pendientes...");

            /* MODULO DE CARGA DE TAREAS PENDIENTES */
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

/* MENU DE OPCIONES PARA EL MANEJO DE LAS LISTAS */
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
    /* verificacion de la entrada para el menu */
    if (!int.TryParse(entrada,out opcion) || opcion < 1 || opcion > 5)  /* para ser incorrecta debe no ser un entero o estar fuera del rando de opciones */
    {
        Console.WriteLine("\n\t\t---OPCION IVALIDA REINGRESE---");
        continue;
    }
    /* si se selecciona 5 sale del bucle */
    if (opcion == 5)
    {
        break;
    }
    /* switch de opciones con las funciones */
    switch (opcion)
    {
        case 1:
            /* bucle para marcar varias tareas como completadas */
            do
            {
                MostrarTareas(tareasPendientes,"tareas pendientes");
                Console.Write("\n\t\tIngrese el ID de la tarea: ");
                string? input = Console.ReadLine(); /* nueva variable para leer la entrada de teclado */
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int idSelecionado)) /* verifico que no sea una entrada vacia y que sea un entero */
                {
                    Tarea? seleccionada = tareasPendientes.Find(buscado => buscado.TareaId == idSelecionado);   /* tarea buscada por el id ingresado */
                    if (seleccionada != null)   
                    {
                        tareasPendientes.Remove(seleccionada);  /* la remuevo de la lista de pendientes */
                        tareasCompletadas.Add(seleccionada);    /* la agrego a la lista de completadas */
                        Console.WriteLine($"\n\t\tTAREA {seleccionada.TareaId} MARCADA CON EXITO");   /* mensaje de exito */
                    }else{
                        Console.WriteLine("\n\t\tID NO ENCONTRADO");    /* mensaje en caso de no tener coincidencia */
                    }
                }else{
                    Console.WriteLine("\n\t\t---ENTRADA NO VALIDA---"); /* mensaje para entradas invalidas */
                }
                /* mensaje para continuar */
                Console.WriteLine("\n\t\tDesea marcar otra tarea?\n\t Cualquier tecla para salir | ENTER para continuar");
                if (Console.ReadKey(true).Key != ConsoleKey.Enter)  /* si se aprieta una tecla distinta de enter sale del bucle */
                {
                    break;
                }
            } while (true);
            break;

        case 2:
            /* impresion de la lista de pendientes */
            MostrarTareas(tareasPendientes,"tareas pendientes");
            break;

        case 3:
            /* mensaje para pedir una descripcion a buscar */
            Console.Write("\n\t\tIngrese la descripcion a buscar : ");
            
            string? buscada = Console.ReadLine();   /* nueva variable para la descripcion buscada */
            if (!string.IsNullOrEmpty(buscada)) /* si la entrada no esta vacia */
            {   
                /* nuevas listas con las tareas encontradas, minimo que la descripcion ingresada coincida completa o parcialmente con la descripcion de la tarea */
                List<Tarea> pendientes = tareasPendientes.FindAll(tarea => tarea.Descripcion.ToLower().Contains(buscada.ToLower()));
                List<Tarea> completadas = tareasCompletadas.FindAll(tarea => tarea.Descripcion.ToLower().Contains(buscada.ToLower()));
                /* si se encontraron coincidencias se ingresa muestran las coincidencias */
                if (pendientes.Count > 0 || completadas.Count > 0)
                {
                    if (pendientes.Count > 0)
                    {   
                        MostrarTareas(tareasPendientes,"tareas pendientes encontradas"); /* impresion de la lista con pendientes encontradas */
                    }
                    if (completadas.Count > 0)
                    {   
                        MostrarTareas(tareasCompletadas,"tareas completadas encontradas"); /* impresion de la lista con completadas pendientes */
                    }
                }else{
                    Console.WriteLine("\n\t\t---SIN COINCIDENCIAS---"); /* mensaje en caso de no encontrar coincidencias */
                }
            }else{
                Console.WriteLine("\n\t\t---ENTRADA INVALIDA---");  /* mensaje en caso de que la entrada sea vacia */
            }

            break;
        case 4:
            /* impresion de la lista de pendientes */
            MostrarTareas(tareasPendientes,"tareas pendientes");
            /* impresion de la lista de completadas */
            MostrarTareas(tareasCompletadas,"tareas completadas");
            break;
    }
} while (true);
