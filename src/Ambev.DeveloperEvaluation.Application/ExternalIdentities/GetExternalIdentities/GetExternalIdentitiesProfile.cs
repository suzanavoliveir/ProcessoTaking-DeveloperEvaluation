using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.GetExternalIdentities;

/// <summary>
/// Profile for mapping between External Identities entity and GetExternalIdentitiesResponse
/// </summary>
public class GetExternalIdentitiesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetExternalIdentitiesProfile()
    {
        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities, GetExternalIdentitiesResult>();
    }
}
