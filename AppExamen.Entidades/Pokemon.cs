namespace AppExamen.Entidades
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Peso { get; set; }

        public int Nivel { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_1 { get; set; }
        public string Tipo_2 { get; set; }

        public int NaturalezaId { get; set; }
        public Naturaleza? Naturaleza { get; set; }
    }
}
