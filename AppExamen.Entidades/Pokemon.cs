using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppExamen.Entidades
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public double Peso { get; set; }

        public int Nivel { get; set; }
        public string Descripcion { get; set; }
        
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Ataque_Especial { get; set; }
        public int Defensa_Especial { get; set; }
        public int Velocidad { get; set; }

        public string Tipo_1 { get; set; }
        public string? Tipo_2 { get; set; }

        public int NaturalezaId { get; set; } //FK
        public Naturaleza? Naturaleza { get; set; }
    }
}
