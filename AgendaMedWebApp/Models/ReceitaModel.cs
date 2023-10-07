namespace AgendaMed.Models
{
    public class ReceitaModel
    {
        public long Id { get; set; }
        public DateTime DataPrescricao { get; set; }
        public int Medicamento { get; set; }
        public decimal Dosagem { get; set; }
        public int PosologiaHora { get; set; }
        public int PosologiaDias { get; set; }
    }
}
