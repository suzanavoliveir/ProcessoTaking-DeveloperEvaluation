using Ambev.DeveloperEvaluation.Application.ExternalIdentities.CreateIExternalIdentities;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateExternalIdentitiesProfile : Profile
{
    public CreateExternalIdentitiesProfile()
    {
        CreateMap<CreateExternalIdentitiesRequest, CreateExternalIdentitiesCommand>();
    }
}