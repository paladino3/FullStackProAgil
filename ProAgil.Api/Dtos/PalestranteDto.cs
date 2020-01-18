using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.Api.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage=" O nome {0} é obrigatório")]
        public string Nome { get; set; }
        public string MiniCurriculum { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocialDto> RedeSociais { get; set; }
        public List <EventoDto> Eventos { get; set; }
  
    }
}