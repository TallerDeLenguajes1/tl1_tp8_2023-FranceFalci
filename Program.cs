
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {

        string? path = @"C:\Users\WINDOWS 10\Desktop\RollinCode-Grupo5\html";
        
        var listaArchivos = new List<string>();

        try{
            listaArchivos= obtenerDirectorio(path,listaArchivos);
            escribirArchivo(path,listaArchivos);
            
        }catch(DirectoryNotFoundException){
            Console.WriteLine("ERROR: no se encontro directorio con ese nombre");
        }



    }

    static List<string> obtenerDirectorio(string path, List<string> listaArchivos){
        string? nombre = "";

        foreach (var archivo in Directory.GetFiles(path))
        {
            nombre = archivo.ToString().Split(@"\").Last();
            listaArchivos.Add(nombre);
            Console.WriteLine(nombre);
        }
        return listaArchivos;
    }

    static void escribirArchivo(string path, List<string> listaArchivos) {
        int i = 1;
        string? nombreArchivo = "";
        string? extencion = "";
        string? linea = "";
        // StreamWriter sr = new StreamWriter(path + @"/index.csv", true);
        StreamWriter sr = new StreamWriter(@"./index.csv", true);

        foreach (var archivo in listaArchivos)
            {
                nombreArchivo = archivo.Split(".")[0];
                extencion = archivo.Split(".")[1];
                linea=$"{i};{nombreArchivo};{extencion}";
                sr.WriteLine(linea);
                i++;

            }

        sr.Close();
    }

}

// Por consola ingrese el path de una carpeta en particular y liste los archivos de la misma por
// consola. A continuación guarde en un archivo csv (archivos separados por comas) llamado
// “index.csv” el listado de archivos encontrados, con el formato correspondiente: primer campo
// índice, 2do campo nombre del archivo, 3ro extensión del mismo.
