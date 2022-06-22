using System;
using System.Collections.Generic;

namespace CPTM.ABI.WebApi.Models
{
    public class EmailArgs
    {
        public string SistemaSigla { get; set; }
        public string RementeNome { get; set; }
        public string RemetenteEmail { get; set; }
        public List<string> Destinatarios { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime EnviarEm { get; set; }
        public int IdUsuarioCpu { get; set; }
        public string MensagemErro { get; set; }
    }
}