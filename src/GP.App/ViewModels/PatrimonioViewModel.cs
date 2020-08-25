using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.App.ViewModels
{
    public class PatrimonioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório" )]
        [DisplayName( "Marca" )]
        public Guid MarcaId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigátorio")]
        [StringLength(200, ErrorMessage ="O campo {0} recisa ter entre {2} e {1} ", MinimumLength = 2 )]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [StringLength( 1000, ErrorMessage = "O campo {0} recisa ter entre {2} e {1} ", MinimumLength = 5 )]
        public string Descricao { get; set; }
        public MarcaViewModel Marca { get; set; }

        [NotMapped]
        public IEnumerable<MarcaViewModel> Marcas { get; set; }
    }
}
