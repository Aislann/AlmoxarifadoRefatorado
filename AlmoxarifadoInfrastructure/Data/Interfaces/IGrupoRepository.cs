using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IGrupoRepository
    {
        List<Grupo> ObterTodosGrupos();
        Grupo ObterGrupoPorId(int id);

        Grupo CriarGrupo(Grupo grupo);
    }
}
