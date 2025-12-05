using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class DeleteAvisoHandler: IRequestHandler<DeleteAvisoRequest, IOperationResult<DeleteAvisoResponse>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IContext _context => _serviceProvider.GetRequiredService<IContext>();
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public DeleteAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<DeleteAvisoResponse>> Handle(DeleteAvisoRequest request, CancellationToken cancellationToken)
        {
            var aviso = await _avisoRepository.ObterAvisoPorIdAsync(request.Id);

            if (aviso == null)
            {
                return OperationResult<DeleteAvisoResponse>.ReturnNotFound();  
            }

            aviso.Ativo = false;
            aviso.AtualizadoEm = DateTime.UtcNow;

            await _avisoRepository.RemoverAvisoAsync(aviso, TrackingBehavior.NoTracking);

            var response = new DeleteAvisoResponse { Id = aviso.Id, Mensagem = "Aviso removido com sucesso!" };

            // Não estou usando o ReturnCreated, pois queria customizar o response
            return OperationResult<DeleteAvisoResponse>.Return(CustomHttpStatusCode.NoContent, response);
        }
    }
}


