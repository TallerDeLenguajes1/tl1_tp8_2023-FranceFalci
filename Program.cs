using EspacioTarea;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        int cantidadTareas = random.Next(1, 10);
        List<Tarea> listaTareasPendientes = new List<Tarea>();
        List<Tarea> listaTareasRealizadas = new List<Tarea>();


        for (int i = 0; i < cantidadTareas ; i++)
        {
            Tarea nuevaTarea = new Tarea(i+1, $"descripcion de la tarea{i}",random.Next(10,101));
            listaTareasPendientes.Add(nuevaTarea);
        }

        mostrarListaTareas(listaTareasPendientes);

        // int respuesta;


    //     foreach( var tareaIndividual in listaTareasPendientes ){
    //         Console.WriteLine(tareaIndividual.mostrarTarea());
    //         Console.WriteLine("Desea mover la tarea a pendiente");
    //         Console.WriteLine("Ingrese un número:");
    //         string? input = Console.ReadLine();

    //     if (int.TryParse(input, out  respuesta))
    //     {
    //         if(respuesta == 1){
    //             listaTareasRealizadas.Add(tareaIndividual);
    //             listaTareasPendientes.Remove(tareaIndividual);
    //         }else{
    //             continue;
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("El valor ingresado no es válido.");
    //     }
    // }

    //     foreach( var tarea in listaTareasRealizadas){
    //         listaTareasPendientes.Remove(tarea);
    //     }

    // interfaz buscar por descripcion 
    // Console.Write("tareaaaaa buscadaa");
    // string? desc = "descripcion de la tarea0";
    // foreach (var tarea in listaTareasPendientes)
    // {
    //     if(string.Compare(tarea.Descripcion,desc) == 0){
    //         Console.WriteLine(tarea.mostrarTarea());
    //     }
    // }

    int suma = 0 ; 
        foreach (var tarea in listaTareasPendientes)
    {
        suma += tarea.Duracion;    
    }

    FileStream archivo = new FileStream("nuevo.txt", FileMode.Create);
    StreamWriter sr = new StreamWriter(archivo);
    sr.WriteLine(suma);
    sr.Close();
    archivo.Close();



    }
        static void  mostrarListaTareas(List<Tarea> lista){
            foreach( var tareaIndividual in lista ){
                Console.WriteLine($"ID:{tareaIndividual.TareaID} \n desc: {tareaIndividual.Descripcion} \n duracion: {tareaIndividual.Duracion}" );
            }
        }



}

