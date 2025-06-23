using System;
namespace EspacioTareas;

public class Tarea{
    // campos del objeto tarea
    private int tareaId, duracion;
    private string descripcion;

    // propiedades solo de lectura para el objeto
    public int TareaId => tareaId;
    public string Descripcion => descripcion;
    public int Duracion => duracion;

    // semilla para crear numeros aleatorios
    private static Random semilla = new Random();

    // constructor
    public Tarea(string texto, int IdIngresado){
        if (string.IsNullOrEmpty(texto))
        {
            throw new ArgumentException("\nLa descripción no puede estar vacía");
        }
        this.tareaId = IdIngresado;
        this.duracion = semilla.Next(10,101);
        this.descripcion = texto;
    }
}