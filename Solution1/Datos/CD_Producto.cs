using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar el paquete IO para el manejo de archivos
using System.IO;

namespace Datos
{
    public class CD_Producto
    {
        public string codigo {  get; set; }
        public string nombre { get; set; }
        public string precio { get; set; }
        public string stock { get; set; }

        //Variables para acceso y manipulación de datos (Stream)

        private FileStream archivo = null; //indicar la ruta y modos
        private StreamReader lector = null; //Stream para leer datos
        private StreamWriter escritor = null; //Stream para escribir datos

        //Establecer la ruta del archivo
        private string ruta = @"..\..\Recursos\productos.txt";

        public string mensaje = "";

        //crear coleccion para almacenar todos los procutos

        List<string> lista = new System.Collections.Generic.List<string>();

        //Metodo (servicio) para guardar o escribir en el archivo
        public void insertar(string codigo, string nombre, string precio, string stock){
            //manejo de excepciones
            try
            {
                //indicar cual archivo se abrira y del modo y acceso
                archivo = new FileStream(ruta, FileMode.Append, FileAccess.Write);
                //crear el escritor sobre el archivo
                escritor = new StreamWriter(archivo);
                //Almacenar los datos en el archivo
                escritor.WriteLine(codigo + "," + nombre + "," + precio + "," + stock);
                //Cerrar el archivo
                escritor.Close();
            }
            catch (IOException ex) {
                mensaje = "ERROR: " + ex.Message;
            }
        }//Cierre del método

        //Metodo´para listar todos los produtos
        public List<string> listado() {
            //manejo de excepciones
            try
            {
                //indicar cual archivo se abrira y del modo y acceso
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                //crear el lector
                lector = new StreamReader(archivo);
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    lista.Add(linea);
                }
                //cerrar el lector
                lector.Close();
            }
            catch (IOException ex)
            {
                mensaje = "ERROR: " + ex.Message;
            }
        }//Cierre del método
    }
    }
}//Cierre de la clase
