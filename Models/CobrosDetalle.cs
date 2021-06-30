
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alvin_P2_AP2.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int CobroId { get; set; }
        public Cobros Cobro { get; set; }

        public int VentaId { get; set; }
        public virtual Ventas Venta { get; set; }

        public double Cobrado { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();
    }
}
