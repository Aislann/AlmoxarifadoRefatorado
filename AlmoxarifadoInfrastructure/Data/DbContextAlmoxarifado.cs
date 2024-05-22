using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data
{
    public class DbContextAlmoxarifado
    {
        private readonly IConexaoBanco _primeiraConexaco;
        private readonly IConexaoBanco _replicaConexaco;

        public DbContextAlmoxarifado(IConexaoBanco primeiraConexaco, IConexaoBanco replicaConexaco)
        {
            _primeiraConexaco = primeiraConexaco;
            _replicaConexaco = replicaConexaco;
        }

        public string GetConnectionString()
        {
            try
            {
                return _primeiraConexaco.GetConnectionString();
            }
            catch
            {
                return _replicaConexaco.GetConnectionString();
            }
        }
    }

}
