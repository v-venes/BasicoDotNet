using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;

namespace Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories
{
    public interface IAvisoRepository : IRepository<AvisoEntity>
    {
        Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> ObterAvisoPorIdAsync(int Id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> CriarAvisoAsync(AvisoEntity aviso, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task EditarAvisoAsync(AvisoEntity aviso, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task RemoverAvisoAsync(AvisoEntity aviso, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
    }
}