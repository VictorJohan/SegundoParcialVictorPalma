using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegundoParcialVictorPalma.Entidades
{
    public class ProyectoDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public Tareas Tarea { get; set; } = new Tareas();
        public string Requerimiento { get; set; }
        public int TiempoMinutos { get; set; }

        /*public ProyectoDetalle(int proyectoId, Tareas materia, string requerimiento, int tiempoMinutos)
        {
            Id = 0;
            ProyectoId = proyectoId;
            TipoId = materia.TareaId;
            Tarea.TipoTarea = materia.TipoTarea;
            Requerimiento = requerimiento;
            TiempoMinutos = tiempoMinutos;
        }*/
    }
}
