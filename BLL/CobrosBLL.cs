using Alvin_P2_AP2.DAL;
using Alvin_P2_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Alvin_P2_AP2.BLL
{
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            if (!Existe(cobro.CobroId))
                return Insertar(cobro);
            else
                return Modificar(cobro);

        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Cobros
                    .Any(e => e.CobroId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Cobros cobro)
        {
            bool Insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in cobro.Detalle)
                {
                    item.Venta = contexto.Ventas.Find(item.VentaId);
                    item.Venta.Balance = item.Venta.Monto - item.Cobrado;
                    contexto.Entry(item.Venta).State = EntityState.Modified;
                }
                contexto.Cobros.Add(cobro);
                Insertado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Insertado;
        }
        public static bool Modificar(Cobros cobro)
        {
            bool Modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in cobro.Detalle)
                {
                    item.Venta = contexto.Ventas.Find(item.VentaId);
                    item.Venta.Balance = item.Venta.Monto - item.Cobrado;
                    contexto.Entry(item.Venta).State = EntityState.Modified;
                }
                contexto.Cobros.Add(cobro);
                Modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Modificado;
        }
        public static bool Eliminar(int id)
        {
            bool Eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var cobro = Buscar(id);
                foreach (var item in cobro.Detalle)
                {
                    item.Venta = contexto.Ventas.Find(item.VentaId);
                    item.Venta.Balance = item.Venta.Monto;
                    contexto.Entry(item.Venta).State = EntityState.Modified;
                }
                contexto.Entry(cobro).State = EntityState.Deleted;
                Eliminado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Cobros Buscar(int id)
        {
            Cobros cobro = new Cobros();
            Contexto contexto = new Contexto();

            try
            {
                cobro = contexto.Cobros
                    .Include(e => e.Detalle)
                    .Include(x => x.Cliente)
                    .Where(e => e.CobroId == id)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cobro;
        }

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> cobro)
        {
            List<Cobros> Lista = new List<Cobros>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Cobros
                    .Include(x => x.Detalle)
                    .Include(x => x.Cliente)
                    .Where(cobro).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static List<CobrosDetalle> GetVentasPendientes(int id)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ventas
                    .Include(x => x.Cliente)
                    .Where(v => v.ClienteId == id && v.Balance > 0)
                    .ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return CrearCobros(lista);
        }
       public static List<CobrosDetalle> CrearCobros(List<Ventas> ventas)
        {
            List<CobrosDetalle> pendientes = new List<CobrosDetalle>();
            foreach (var item in ventas)
            {
                pendientes.Add(new CobrosDetalle
                {
                    VentaId = item.VentaId,
                    Venta = item,
                    Cobrado = 0
                });
            }
            return pendientes;
        }

    }
}