using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.GetExternalIdentities;

/// <summary>
/// Profile for mapping GetExternalIdentities feature requests to commands
/// </summary>
public class GetExternalIdentitiesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetExternalIdentities feature
    /// </summary>
    public GetExternalIdentitiesProfile()
    {
        CreateMap<Guid, Application.ExternalIdentities.GetExternalIdentities.GetExternalIdentitiesCommand>()
            .ConstructUsing(id => new Application.ExternalIdentities.GetExternalIdentities.GetExternalIdentitiesCommand(id));
    }
}
