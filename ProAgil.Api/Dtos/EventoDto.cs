using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.Api.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage="Campo Obrigatório")]
        [StringLength (100, MinimumLength=3, ErrorMessage="Local é entre 3 e 100 Caracters")]
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required (ErrorMessage="O Tema deve ser Preeenchido")]
        public string Tema { get; set; }
        
        [Range(2, 5000, ErrorMessage="Quatidade de Pessoas é entre 2 e 5000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }

        [Phone]//dataNotation Telefone
        public string Telefone { get; set; }
        
        [EmailAddress]//dataNotation Email
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}