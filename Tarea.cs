namespace EspacioTarea; 

public class Tarea {
    private int tareaID; 
    private string? descripcion;
    private int duracion;
    // private estado estadoTarea;
    
    public Tarea(int tareaID, string descripcion, int duracion ){
        this.TareaID = tareaID;
        this.descripcion = descripcion;
        this.duracion = duracion;
     

    }

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    // public estado EstadoTarea { get => estadoTarea; set => estadoTarea = value; }


    public string mostrarTarea(){
        string texto = $"ID:{TareaID} \n desc: {Descripcion} \n duracion: {Duracion}";
        return texto;
    }
}

