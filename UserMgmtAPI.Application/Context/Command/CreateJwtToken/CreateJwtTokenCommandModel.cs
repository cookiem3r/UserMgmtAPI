using MediatR;

namespace UserMgmtAPI.Application.Context.Command.CreateJwtToken
{
    public class CreateJwtTokenCommandModel : IRequest<string>
    {
    }
}
