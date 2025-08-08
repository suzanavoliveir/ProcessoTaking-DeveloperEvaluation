using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.CreateIExternalIdentities;

/// <summary>
/// Profile for mapping between External Identities entity and CreateExternalIdentitiesResponse
/// </summary>
public class CreateExternalIdentitiesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateExternal operation
    /// </summary>
    public CreateExternalIdentitiesProfile()
    {

        CreateMap<CreateExternalIdentitiesCommand, Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities>();
        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities, CreateExternalIdentitiesResult>();

    }
}
