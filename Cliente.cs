using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationSolution.Models
{
    public class Usuario
    {
        [Key]
        [Column("CD_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("NM_USUARIO")]
        public string Nome { get; set; }

        [Column("DS_CPF")]
        public string CPF { get; set; }

        [Column("DS_RG")]
        public string RG { get; set; }

        [Column("DT_EXPEDICAO")]
        public DateTime DataExpedicao { get; set; }

        [Column("DS_ORGAO_EXPEDITOR")]
        public string OrgaoExpeditor { get; set; }

        [Column("DS_UF")]
        public string UF { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("DS_SEXO")]
        public string Sexo { get; set; }

        [Column("DS_ESTADO_CIVIL")]
        public string EstadoCivil { get; set; }
    }
}
