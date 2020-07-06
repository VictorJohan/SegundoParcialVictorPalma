using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoParcialVictorPalma.Entidades
{
    public class ProyectoDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TipoId { get; set; }
        public string TipoTarea { get; set; }
    }
}
