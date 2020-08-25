using System.Collections.Generic;

namespace GP.Business.Models
{
    public class Marca : Entity
    {
        public string Nome { get; set; }

        //public string MarcaId { get; set; } Adotadei como Id

        /* EF Relations */
        public IEnumerable<Patrimonio> Patrimonios { get; set; }
    }
}
