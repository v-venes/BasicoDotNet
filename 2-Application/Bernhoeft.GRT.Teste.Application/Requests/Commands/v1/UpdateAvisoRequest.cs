using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using System.Text.Json.Serialization;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class UpdateAvisoRequest : IRequest<IOperationResult<UpdateAvisoResponse>>
    {
        // Ignorando para não exibir no swagger
        [JsonIgnore]
        public int Id { get; set; }
        public string Mensagem { get; set; }
    }
}
