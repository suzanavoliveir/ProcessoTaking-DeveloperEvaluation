using AutoMapper;
using Ambev.DeveloperEvaluation.Application.ExternalIdentities.CreateIExternalIdentities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateExternalIdentitiesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateExternalIdentitiesProfile()
    {
        CreateMap<CreateExternalIdentitiesRequest, CreateExternalIdentitiesCommand>();
        CreateMap<CreateExternalIdentitiesResult, CreateExternalIdentitiesResponse>();
    }
}
