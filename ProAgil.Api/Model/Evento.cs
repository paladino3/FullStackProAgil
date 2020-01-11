namespace ProAgil.Api.Model {
    public class Evento {
        public Evento (int eventoId, string local, string dataEvento, string tema, int qtdePessoas, string lote, string imagemUrl) {
            this.EventoId = eventoId;
            this.Local = local;
            this.DataEvento = dataEvento;
            this.Tema = tema;
            this.QtdePessoas = qtdePessoas;
            this.Lote = lote;
            this.ImagemUrl = imagemUrl;

        }
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdePessoas { get; set; }
        public string Lote { get; set; }
        public string ImagemUrl { get; set; }
    }

}