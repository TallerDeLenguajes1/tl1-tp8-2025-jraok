using EspacioCalculadoraHistorial;

// variables para el programa
double numero = 0, opcion = 0;
int continuar = 1;
string operacionMenu;
Calculadora calculador = new Calculadora();

// estructura loggica para el programa
do{
    // menu de opciones
    Console.WriteLine("\n\t\t----Taller de lenguajes 1----");
    Console.WriteLine("\tMenu de opciones");
    Console.WriteLine("\t1. Sumar");
    Console.WriteLine("\t2. Restar");
    Console.WriteLine("\t3. Multiplicar");
    Console.WriteLine("\t4. Dividir");
    Console.WriteLine("\t5. Limpiar");
    Console.Write("\n\tElija una opcion (ENTER PARA CANCELAR):\t");
    operacionMenu = Console.ReadLine();     /* lectura de la opcion elegida del menu */

    if(string.IsNullOrEmpty(operacionMenu))break; /* verificacion de qque si se cancelo la operacion */

    // verificacion que no se ingrese un string u opcion invalida
    if(!double.TryParse(operacionMenu, out opcion) || (opcion < 1 || opcion > 5)){
        Console.WriteLine("\t\t---ERROR OPCION NO VALIDA, REINGRESE---");
        continue; /* salto al proximo ciclo en caso de que la entrada sea invalida */
    }

    if(opcion == 5){ /* en caso de que la opcion sea 5 se limpia unicamente */
        calculador.Limpiar();
        Console.WriteLine($"\n\tResultado de la operacion: {calculador.Resultado}");
    }else{ /* sino se pide el numero a operar y se evalua el valor de la opcion */
        Console.Write("\tIngrese el numero a operar (ENTER PARA CANCELAR):\t");
        string Entrada = Console.ReadLine();    /* variable para la lectura del numero */

        if(string.IsNullOrEmpty(Entrada))   goto PreguntarContinuar;   /* salto a la pregunta sobre continuar */
        //conversion de string a double para la operacion
        if(double.TryParse(Entrada, out numero)){
            switch(opcion){
                case 1:calculador.Sumar(numero);        break;
                case 2:calculador.Restar(numero);       break;
                case 3:calculador.Multiplicar(numero);  break;
                case 4:calculador.Dividir(numero);      break;
            }
            Console.WriteLine($"\n\tResultado de la operacion: {calculador.Resultado}"); /* muestra del resultado */
        }else{
            Console.WriteLine("\n\t\tVALOR NO ADMITIDO"); /* mensaje de error */
        }
    }
    
    PreguntarContinuar: /* ciclo para preguntar si se quiere continuar */
    do{
        Console.Write("\n\tDesea continuar? (Si = 1 | No = 2):\t");
        if(int.TryParse(Console.ReadLine(), out continuar) && (continuar == 1 || continuar == 2)){
           break;
        }
        Console.WriteLine("\t\t---OPCION NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumpla se rompe el bucle */

    Console.WriteLine(new string('-', 50)); // separador visual
}while(continuar == 1);