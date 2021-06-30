using Alvin_P2_AP2.DAL;
using Alvin_P2_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alvin_P2_AP2.BLL
{
    public class ClientesBLL
    {
        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes cliente;
            try
            {
                cliente = contexto.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return cliente;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Clientes
                    .Any(e => e.ClienteId == id);
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
        public static List<Clientes> GetList()
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Clientes
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
            return lista;
        }
    }
}
