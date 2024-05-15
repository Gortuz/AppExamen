using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppExamen.Entidades
{
    public class Naturaleza
    {
        [Key]
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Pokemon>? Pokemones { get; set; }
    }
}
