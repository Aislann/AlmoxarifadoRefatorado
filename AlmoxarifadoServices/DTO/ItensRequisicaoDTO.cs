namespace AlmoxarifadoServices.DTO
{
    public class ItensRequisicaoGetDTO
    {
        public int NumItem { get; set; }
        public int IdPro { get; set; }
        public int IdReq { get; set; }
        public int IdSec { get; set; }
        public decimal QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? TotalReal { get; set; }
    }
    public class ItensRequisicaoPostDTO
    {
        public int NumItem { get; set; }
        public int IdPro { get; set; }
        public int IdReq { get; set; }
        public int IdSec { get; set; }
        public decimal QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
    }
    public class ItensRequisicaoPutDTO
    {
        public int IdPro { get; set; }
        public int IdReq { get; set; }
        public int IdSec { get; set; }
        public decimal QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
    }
}
