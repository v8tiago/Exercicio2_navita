using System;

namespace GP.Business.Models
{
    public class Patrimonio : Entity
    {
        public Guid MarcaId { get; set; }
        public string Nome { get; set; }      
        public string Descricao { get; set; }
        public int NTombo  { get; set; } 

        /* EF Relation */
        public Marca Marca { get; set; }
    }
}
