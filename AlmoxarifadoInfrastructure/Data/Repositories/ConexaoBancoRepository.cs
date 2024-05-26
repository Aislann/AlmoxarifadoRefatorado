using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ConexaoBancoRepository
    {
        public class PrimeiraConexao : IConexaoBanco
        {
            private readonly IConfiguration _configuration;

            public PrimeiraConexao(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string GetConnectionString()
            {
                return _configuration.GetConnectionString("ConexaoAislan");
            }
        }

        public class ReplicaConexao : IConexaoBanco
        {
            private readonly IConfiguration _configuration;

            public ReplicaConexao(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string GetConnectionString()
            {
                return _configuration.GetConnectionString("ConexaoReplicaSQL");
            }
        }

    }
}
