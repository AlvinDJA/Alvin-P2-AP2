using Alvin_P2_AP2.DAL;
using Alvin_P2_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alvin_P2_AP2.BLL
{
    public class VentasBLL
    {
        public static List<Ventas> GetList()
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ventas
                    .Include(x => x.Cliente)
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
