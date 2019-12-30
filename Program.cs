using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class ProgramArreglos
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia");

            // escuela.Pais = "Colombia";
            // escuela.Ciudad = "Bogota";
            // escuela.TipoEscuela = TiposEscuela.Primaria;

            /////Forma 1 de llenar arreglo cursos//////
            // var arreglosCursos = new Curso[3];

            // arreglosCursos[0] = new Curso()
            // {
            //     Nombre = "101"
            // };

            // var curso2 = new Curso()
            // {
            //     Nombre = "201"
            // };

            // arreglosCursos[1] = curso2;

            // arreglosCursos[2] = new Curso
            // {
            //     Nombre = "301"
            // };
            ////////////////////////////////////////////

            ////////Forma 2 llenar arreglo cursos///////
            // Curso[] arreglosCursos = {
            //     new Curso() { Nombre = "101"},
            //     new Curso() { Nombre = "201"},
            //     new Curso() { Nombre = "301"}
            // };
            /////////////////////////////////////////////

            ////Imprimir arreglo cursos///////////////////
            // System.Console.WriteLine("===================");
            // ImprimirCursosWhile(arreglosCursos);
            // System.Console.WriteLine("===================");
            // ImprimirCursosDoWhile(arreglosCursos);
            // System.Console.WriteLine("===================");
            // ImprimirCursosFor(arreglosCursos);
            // System.Console.WriteLine("===================");
            // ImprimirCursosForEach(arreglosCursos);
            //////////////////////////////////////////////


            ////////Forma 3 llenar arreglo cursos///////
            //En esta opción se asigno al atributo cursos del Objeto escuela
            escuela.Cursos = new Curso[]{
                new Curso() { Nombre = "101"},
                new Curso() { Nombre = "201"},
                new Curso() { Nombre = "301"}
            };
            /////////////////////////////////////////////

            ImprimirCursosEscuela(escuela);

            bool rta = 10 == 10;
            if (rta)
            {
                WriteLine("Se cumplio la condición");
            }else if (true)
            {
                //hago otra cosa
            }else
            {
                //hacer otra cosa sino cumple
            }
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("=====================");
            WriteLine("Cursos de la Escuela");
            WriteLine("====================");

            //if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre} , Id {curso.UniqueId}");
                }
            }



        }

        private static void ImprimirCursosWhile(Curso[] arreglosCursos)
        {
            int contador = 0;
            while (contador < arreglosCursos.Length)
            {
                Console.WriteLine($"Nombre {arreglosCursos[contador].Nombre} , Id {arreglosCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arreglosCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arreglosCursos[contador].Nombre} , Id {arreglosCursos[contador].UniqueId}");
                contador++;
            } while (contador < arreglosCursos.Length);

        }

        private static void ImprimirCursosFor(Curso[] arreglosCursos)
        {
            for (int i = 0; i < arreglosCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arreglosCursos[i].Nombre} , Id {arreglosCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arreglosCursos)
        {
            foreach (var curso in arreglosCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre} , Id {curso.UniqueId}");
            }
        }
    }
}
