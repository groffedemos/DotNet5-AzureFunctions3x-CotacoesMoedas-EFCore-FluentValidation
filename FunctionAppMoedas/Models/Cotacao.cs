using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunctionAppMoedas.Models
{
    public class Cotacao
    {
        public string Sigla { get; set; }
        public string NomeMoeda { get; set; }
        public DateTime? UltimaCotacao   { get; set; }
        [Column(TypeName = "numeric(18,4)")]
        public decimal? Valor { get; set; }
        public string LocalExecucao { get; set; }
    }
}