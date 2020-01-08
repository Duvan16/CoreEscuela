using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
                throw new ArgumentNullException(nameof(dicObsEsc));
            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluación, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }
            else
            {
                return new List<Evaluación>();
                //Escribir en el log de auditoria
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetDicEvaluacionesXAsig()
        {
            var dictRta = new Dictionary<string, IEnumerable<Evaluación>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalAsign = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;

                dictRta.Add(asig, evalAsign);
            }
            return dictRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromeAlumnPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluacionesXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promAlumn = from eval in asigConEval.Value
                                group eval by new
                                {
                                    eval.Alumno.UniqueId,
                                    eval.Alumno.Nombre
                                }
                            into grupoEvalAlumno
                                select new AlumnoPromedio
                                {
                                    alumnoid = grupoEvalAlumno.Key.UniqueId,
                                    alumnoNombre = grupoEvalAlumno.Key.Nombre,
                                    promedio = grupoEvalAlumno.Average(
                                     evaluacion => evaluacion.Nota)
                                };
                rta.Add(asigConEval.Key, promAlumn);
            }
            return rta;
        }


    }
}