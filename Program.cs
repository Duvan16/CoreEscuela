using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia");

            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada=TiposJornada.Mañana},
                new Curso() { Nombre = "201", Jornada=TiposJornada.Mañana},
                new Curso() { Nombre = "301", Jornada=TiposJornada.Mañana}
            };

            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>(){
                new Curso() { Nombre = "401", Jornada=TiposJornada.Mañana},
                new Curso() { Nombre = "501", Jornada=TiposJornada.Mañana},
                new Curso() { Nombre = "501", Jornada=TiposJornada.Tarde}
            };

            //otraColeccion.Clear();
            // Curso tmp = new Curso() { Nombre = "101 Vacacional", Jornada = TiposJornada.Noche };

            escuela.Cursos.AddRange(otraColeccion);
            // escuela.Cursos.Add(tmp);
            ImprimirCursosEscuela(escuela);
            // WriteLine("Curso.Hash" + tmp.GetHashCode());


            //A partir de c# ya no es necesario hacer esta inferencia de tipos
            //Predicate<Curso> miAlgoritmo = Predicado;

            ///Delegados
            //Forma 1 : hay que construir la funciòn aparte
            // escuela.Cursos.RemoveAll(Predicado);

            //Forma 2: se especifica el delegate
            escuela.Cursos.RemoveAll(delegate (Curso cur)
            {
                return cur.Nombre == "301";
            });

            //Forma 3: con expresiones lambda
            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada == TiposJornada.Mañana);
            //////////////////////////////////////////////////////////


            // escuela.Cursos.Remove(tmp);
            WriteLine("=====================");
            ImprimirCursosEscuela(escuela);
        }
        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
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
