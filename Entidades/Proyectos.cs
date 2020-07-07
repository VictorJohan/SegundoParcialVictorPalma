using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegundoParcialVictorPalma.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string DescripcionProyecto { get; set; }
        public int TiempoTotal { get; set; }
        [ForeignKey ("ProyectoId")]
        public virtual List<ProyectoDetalle> ProyectoDetalles { get; set; } = new List<ProyectoDetalle>();
    }
}
