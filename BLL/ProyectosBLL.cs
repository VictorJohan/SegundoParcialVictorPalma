using Microsoft.EntityFrameworkCore;
using SegundoParcialVictorPalma.DAL;
using SegundoParcialVictorPalma.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcialVictorPalma.BLL
{
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Proyectos.Any(p => p.ProyectoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Proyectos proyecto)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Proyectos.Add(proyecto);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        private static bool Modificar(Proyectos proyecto)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectoDetalle Where ProyectoId={proyecto.ProyectoId}");
                foreach (var anterior in proyecto.ProyectoDetalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(proyecto).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static Proyectos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proyectos proyectos;

            try
            {
                proyectos = contexto.Proyectos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyectos;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var proyecto = contexto.Proyectos.Find(id);
                contexto.Entry(proyecto).State = EntityState.Deleted;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static List<Proyectos> GetProyectos(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
      
    }
}
