using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += ActionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);
            AppDomain.CurrentDomain.ProcessExit -= ActionDelEvento;

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            //ImprimirCursosEscuela(engine.Escuela);

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listAsg = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluacionesXAsig();
            var listaPromXAsig = reporteador.GetPromeAlumnPorAsignatura();

            Printer.WriteTitle("Captura de una Evaluación por Consola");
            var newEval = new Evaluación();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la Evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la Evaluación ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la Evaluación");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(notaString))
            {
                Printer.WriteTitle("El valor de la nota no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la Evaluación ha sido ingresada correctamente");
                    return;
                }
                catch (ArgumentOutOfRangeException arge)
                {
                    Printer.WriteTitle(arge.Message);
                    WriteLine("Saliendo del programa");
                }
                catch (Exception)
                {
                    Printer.WriteTitle("El valor de la nota no es número válido");
                    WriteLine("Saliendo del programa");
                }
                finally
                {
                    Printer.WriteTitle("FINALLY");
                    Printer.Beep(2500, 500, 3);
                }
            }

            // Dictionary<int, string> diccionario = new Dictionary<int, string>();

            // diccionario.Add(10, "Duvan");
            // diccionario.Add(23, "Lorem Ipsum");

            // foreach (var keyValPair in diccionario)
            // {
            //     WriteLine($"key: {keyValPair.Key} Valor: {keyValPair.Value}");
            // }

            // var dictmp = engine.GetDiccionarioObjetos();
            // engine.ImprimirDiccionario(dictmp, true);

            //////////////////EJECICIOS DICCIONARIO//////////////////
            // Printer.WriteTitle("Acceso a Diccionario");
            // //WriteLine(diccionario[23]);
            // diccionario[0] = "Pekerman";
            // WriteLine(diccionario[0]);
            // Printer.WriteTitle("Otro diccionario");
            // var dic = new Dictionary<string, string>();
            // dic["Luna"] = "Cuerpo celeste que gira alrededor de la tierra";
            // WriteLine(dic["Luna"]);
            // dic["Luna"] = "Protagonista de soy Luna";
            // dic.Add("Luna", "Protagonista de Soy Luna");//Saca error
            // WriteLine(dic["Luna"]);
            ///////////////////////////////////////////////////////////


            //////////////PRUEBAS DE POLIMORFISMO/////////////////
            //var obj = new ObjetoEscuelaBase();
            // Printer.DrawLine(20);
            // Printer.DrawLine(20);
            // Printer.DrawLine(20);
            // Printer.WriteTitle("Pruebas de Polimorfismo");
            // var alumnoTest = new Alumno { Nombre = "Claire UnderWood" };

            // Printer.WriteTitle("Alumno");
            // WriteLine($"Alumno: {alumnoTest.Nombre}");
            // WriteLine($"Alumno: {alumnoTest.UniqueId}");
            // WriteLine($"Alumno: {alumnoTest.GetType()}");


            // ObjetoEscuelaBase ob = alumnoTest;
            // Printer.WriteTitle("ObjetoEscuela");
            // WriteLine($"Alumno: {ob.Nombre}");
            // WriteLine($"Alumno: {ob.UniqueId}");
            // WriteLine($"Alumno: {ob.GetType()}");

            // var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank Underwood" };
            // Printer.WriteTitle("ObjetoEscuelaBase");
            // WriteLine($"Alumno: {objDummy.Nombre}");
            // WriteLine($"Alumno: {objDummy.UniqueId}");
            // WriteLine($"Alumno: {objDummy.GetType()}");

            // var evaluación = new Evaluación() { Nombre = "Evaluación de math", Nota = 4.5f };
            // Printer.WriteTitle("Evaluación");
            // WriteLine($"Evaluación: {evaluación.Nombre}");
            // WriteLine($"Evaluación: {evaluación.UniqueId}");
            // WriteLine($"Evaluación: {evaluación.Nota}");
            // WriteLine($"Evaluación: {evaluación.GetType()}");

            // ob = evaluación;
            // Printer.WriteTitle("ObjetoEscuela");
            // WriteLine($"Alumno: {ob.Nombre}");
            // WriteLine($"Alumno: {ob.UniqueId}");
            // WriteLine($"Alumno: {ob.GetType()}");

            // alumnoTest = (Alumno)evaluación;

            // if (ob is Alumno)
            // {
            //     Alumno alumnoRecuperado = (Alumno)ob;
            // }

            // Alumno alumnoRecuperado2 = ob as Alumno;
            // if (alumnoRecuperado2 != null)
            // {

            // }
            /////////////////////////////////////////////////////

            //engine.Escuela.LimpiarLugar();

            //////Obtener objetos a través de linq//////////////
            // var listaILugar = from obj in listaObjetos
            //                     where obj is ILugar
            //                     select (ILugar) obj;

            //  var listaILugar = from obj in listaObjetos
            //                     where obj is Alumno
            //                     select (Alumno) obj;
            ///////////////////////////////////////////////////

            ////////////////PARAMETROS DE SALIDAD/////////////
            ///Forma 1
            // int dummy = 0;
            // var listaObjetos = engine.GetObjetoEscuelas(
            //     out int conteoEvaluaciones,
            //     out dummy,
            //     out dummy,
            //     out dummy);

            //Forma 2 *Utilizar variable dummy
            // int dummy = 0;
            // var listaObjetos = engine.GetObjetoEscuelas(
            //     out int conteoEvaluaciones,
            //     out int conteoCursos,
            //     out int conteoAsignaturas,
            //     out int conteoAlumnos
            // );

            //Forma 3 *Utilizando sobrecargas de metodos
            // int dummy = 0;
            // var listaObjetos = engine.GetObjetoEscuelas();
            // listaObjetos.Add(new Evaluación { Nombre = "Curso Loco" });
            /////////////////////////////////////////////////////////////////////
        }

        private static void ActionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIÓ");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");

            //if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre} , Id {curso.UniqueId}");
                }
            }
        }
    }
}
