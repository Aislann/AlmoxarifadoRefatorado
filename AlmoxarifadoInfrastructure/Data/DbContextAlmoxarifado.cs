using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using static AlmoxarifadoInfrastructure.Data.Repositories.ConexaoBancoRepository;

namespace AlmoxarifadoInfrastructure.Data
{
    public class ConexaoBancoService
    {
        private readonly PrimeiraConexao _primeiraConexao;
        private readonly ReplicaConexao _replicaConexao;
        private readonly ILogger<ConexaoBancoService> _logger;

        public ConexaoBancoService(PrimeiraConexao primeiraConexao, ReplicaConexao replicaConexao, ILogger<ConexaoBancoService> logger)
        {
            _primeiraConexao = primeiraConexao;
            _replicaConexao = replicaConexao;
            _logger = logger;
        }

        public string GetConnectionString()
        {
            if (VerificarConexao(_primeiraConexao.GetConnectionString()))
            {
                return _primeiraConexao.GetConnectionString();
            }
            else
            {
                _logger.LogWarning("Conexão primária indisponível. Tentando conexão de réplica.");
                return _replicaConexao.GetConnectionString();
            }
        }

        private bool VerificarConexao(string connectionString)
        {
            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar conectar usando a string de conexão: {ConnectionString}", connectionString);
                return false;
            }
        }
    }
}
