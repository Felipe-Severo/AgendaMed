using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class ReceitaMedicamentoModel
    {
        public long Id { get; set; }
        public MedicamentoModel Medication_Id { get; set; }
        public long Prescription_Id { get; set; }
        //public decimal Dosage { get; set; }
        public string Posology { get; set; }

        public ReceitaMedicamentoModel()
        {

        }

        public ReceitaMedicamentoModel (ReceitaMedicamentos medicamento)
        {
            Id = medicamento.Id;
            Medication_Id = new MedicamentoModel(medicamento.Medication_Id);
            Prescription_Id = medicamento.Prescription_Id;
         
            //Posology = medicamento.Posology;
        }

        public ReceitaMedicamentos GetReceitaMedicamento()
        {
            return new ReceitaMedicamentos() { Id = Id, Medication_Id = AgendaMed.Business.Genericos.Medicamento.ReadOne(Medication_Id.Id), Prescription_Id = Prescription_Id };
        }
    }
}

