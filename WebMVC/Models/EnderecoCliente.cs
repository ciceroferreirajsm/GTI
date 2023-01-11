using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationSolution.WebMVC.Models
{
    public class EnderecoCliente
    {
        [Key]
        [Column("CD_ENDERECO")]
        public int Id { get; set; }

        [Column("DS_CEP")]
        public string CEP { get; set; }

        [Column("DS_LOGRADOURO")]
        public string Logradouro { get; set; }

        [Column("DS_NUMERO")]
        public string Numero { get; set; }

        [Column("DS_COMPLEMENTO")]
        public string Complemento { get; set; }

        [Column("DS_BAIRRO")]
        public string Bairro { get; set; }

        [Column("DS_CIDADE")]
        public string Cidade { get; set; }

        [Column("DS_UF")]
        public string UF { get; set; }
    }
}
