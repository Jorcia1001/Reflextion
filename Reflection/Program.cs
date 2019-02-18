using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {


            XPathDocument doc_xml = new XPathDocument("ReflectionConfiguration.xml");

            //Inicializamo el navegador el navegador Xpath para hacer consultas
            XPathNavigator navegador = doc_xml.CreateNavigator();
            //Realizamos la consulta con el nodo, para obtener el texto del nodo con id = "Alumno"
            //text:node: es el padre
            XPathNavigator text_nodes = navegador.SelectSingleNode("/Types/Type[@Id='Alumno1']");

            Assembly myAssembly = typeof(Program).Assembly;
            //get type of class Alumno from just loaded assembly
            Type alumnoType = myAssembly.GetType(text_nodes.SelectSingleNode("Class").ToString());
            string idAlumno = text_nodes.SelectSingleNode("idAlumno").ToString();
            string Nombre = text_nodes.SelectSingleNode("Nombre").ToString();
            string Apellidos = text_nodes.SelectSingleNode("Apellidos").ToString();
            string Dni = text_nodes.SelectSingleNode("Dni").ToString();


            //create intance of class alumno
            object objectoDeAlumno = 
                Activator.CreateInstance
                (alumnoType,int.Parse(idAlumno),Nombre,Apellidos,Dni);

            Console.WriteLine(((Alumno)objectoDeAlumno).Nombre);
            
            ///--------------------
            XElement root = XElement.Load("ReflectionConfiguration.xml");

            //Linq to xml
            IEnumerable<XElement> tests =
                from element in root.Elements("Type")
                where (string)element.Attribute("Id") == "Alumno2"
                select element;
            var alumnoDatos = tests.First();

            string Class = alumnoDatos.Elements("Class").First().Value;
            string LinqIdAlumno = alumnoDatos.Elements("idAlumno").First().Value;
            string LinqNombre = alumnoDatos.Elements("Nombre").First().Value;
            string LinqAplellidos = alumnoDatos.Elements("Apellidos").First().Value;
            string LinqDni = alumnoDatos.Elements("Dni").First().Value;


            //get type of class Alumno from just loaded assebly
            Type alumno1Type = myAssembly.GetType(Class);

            //create intance of class Claculator
            object objectoDeAlumno1 = 
                Activator.CreateInstance
                (alumno1Type,int.Parse(LinqIdAlumno),LinqNombre,LinqAplellidos,LinqDni);

            Console.WriteLine((Alumno)objectoDeAlumno1);

            Console.ReadKey();


        }
    }
}
