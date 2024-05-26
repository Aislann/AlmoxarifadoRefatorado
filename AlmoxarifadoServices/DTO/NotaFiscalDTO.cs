namespace AlmoxarifadoServices.DTO
{
    public class NotaFiscalGetDTO
    {
        public int IdNota { get; set; }
        public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; }
        public decimal ValorNota { get; set; }
        public int QtdItem { get; set; }
        public int? Icms { get; set; }
        public int? Iss { get; set; }
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public DateTime? DataNota { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
        public int? EmpenhoNum { get; set; }
    }
    public class NotaFiscalPostDTO
    {
        //public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; }
        public decimal ValorNota { get; set; }
        public int QtdItem { get; set; }
        public int? Icms { get; set; }
        public int? Iss { get; set; }
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public DateTime? DataNota { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
        public int? EmpenhoNum { get; set; }
    }
    public class NotaFiscalPutDTO
    {
        public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; }
        public decimal ValorNota { get; set; }
        public int QtdItem { get; set; }
        public int? Icms { get; set; }
        public int? Iss { get; set; }
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public DateTime? DataNota { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
        public int? EmpenhoNum { get; set; }
    }
}
