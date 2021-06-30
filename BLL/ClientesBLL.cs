using Alvin_P2_AP2.DAL;
using Alvin_P2_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alvin_P2_AP2.BLL
{
    public class ClientesBLL
    {
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
