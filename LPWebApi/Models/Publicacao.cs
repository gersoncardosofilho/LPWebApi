using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LPWebApi.Models
{
    [Table("tbPublicacoes")]
    public class Publicacao
    {
        /// <summary>
        /// Id da publicação
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPublicacao { get; set; }

        /// <summary>
        /// Título da publicação
        /// </summary>
        [DataType(DataType.Text)]
        public string TituloPublicacao { get; set; }

        /// <summary>
        /// Url da publicação
        /// </summary>
        [DataType(DataType.ImageUrl)]
        public string UrlPublicacao { get; set; }

    }
}