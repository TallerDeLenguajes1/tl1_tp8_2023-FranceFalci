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



        listaTareasPendientes = crearTareas(listaTareasPendientes,cantidadTareas);

        interfaz(listaTareasPendientes,listaTareasRealizadas);

        Console.WriteLine("---TAREAS REALIZADAS---");
        mostrarListaTareas(listaTareasRealizadas);
        Console.WriteLine("---TAREAS PENDIENTES---");
        mostrarListaTareas(listaTareasPendientes);

        escribirHorasTrabajadas(listaTareasRealizadas);


        Console.WriteLine("---TAREAS BUSCADA---");
        buscarPorDescripcion("descripcion de la tarea1",listaTareasRealizadas);
        
    }
        static void  mostrarListaTareas(List<Tarea> lista){
            foreach( var tareaIndividual in lista ){
                Console.WriteLine($"ID:{tareaIndividual.TareaID} \n desc: {tareaIndividual.Descripcion} \n duracion: {tareaIndividual.Duracion}" );
            }
        }

        static List<Tarea> crearTareas(List<Tarea> lista,int cantidadTareas){
        Random random = new Random();

        for (int i = 0; i < cantidadTareas; i++)
        {
            Tarea nuevaTarea = new Tarea(i + 1, $"descripcion de la tarea{i+1}", random.Next(10, 101));
            lista.Add(nuevaTarea);
        }
        return lista;
        }

        static void escribirHorasTrabajadas (List<Tarea> lista){
            int suma = 0;
            foreach (var tarea in lista)
            {
                suma += tarea.Duracion;
            }

        FileStream archivo = new FileStream("nuevo.txt", FileMode.Create);
        StreamWriter sr = new StreamWriter(archivo);
        sr.WriteLine(suma);
        sr.Close();
        archivo.Close();
        }


        static void interfaz(List<Tarea> listaPendientes ,List<Tarea> listaRealizadas){
            int respuesta;
            foreach( var tareaIndividual in listaPendientes ){
                // Console.WriteLine(tareaIndividual.TareaID);
                Console.WriteLine($"Desea mover la tarea {tareaIndividual.TareaID} a realizada");
                Console.WriteLine("1.Si - 0.NO");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out  respuesta))
                {
                    if(respuesta == 1){
                        listaRealizadas.Add(tareaIndividual);
                        Console.WriteLine("TareaAgregada");

                } 
  
                }else
                {
                    Console.WriteLine("El valor ingresado no es válido.");
                }
            }

            foreach( var tarea in listaRealizadas){
            listaPendientes.Remove(tarea);
            }




    }

        static void buscarPorDescripcion(string desc , List<Tarea> lista){
      
        foreach (var tarea in lista)
        {
            if (string.Compare(tarea.Descripcion, desc) == 0)
            {
                Console.WriteLine(tarea.mostrarTarea());
            }
        }
    }
}

