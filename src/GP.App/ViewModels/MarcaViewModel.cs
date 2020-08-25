using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GP.App.ViewModels
{
    public class MarcaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigátorio" )]
        [StringLength( 300, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} ", MinimumLength = 2 )]
        public string Nome { get; set; }
        public IEnumerable<PatrimonioViewModel> Patrimonios { get; set; }
    }
}
