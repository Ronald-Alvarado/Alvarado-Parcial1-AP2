using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Alvarado_Parcial1_AP2.DAL;
using Microsoft.EntityFrameworkCore;

namespace Alvarado_Parcial1_AP2.Models{

    public class ProductosBLL{

        Productos producto = new Productos();

        private static bool Guardar(Productos producto)
        {
            if(!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool existe = false;

            try
            {
                existe = contexto.Productos.Any(p => p.ProductoId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return existe;
        }

        private static bool Insertar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool insertar = false;

            try
            {
                contexto.Productos.Add(productos);
                insertar = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return insertar;
        }

        private static bool Modificar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool modificar = false;

            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                modificar = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificar;
        }

        private static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminar = false;

            try
            {
                var buscar = contexto.Productos.Find(id);
                contexto.Entry(buscar).State = EntityState.Deleted;
                eliminar = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminar;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos productos = new Productos();

            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            Contexto contexto = new Contexto();
            List<Productos> listar = new List<Productos>();

            try
            {
                listar = contexto.Productos.Where(producto).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listar;
        }

    }
}