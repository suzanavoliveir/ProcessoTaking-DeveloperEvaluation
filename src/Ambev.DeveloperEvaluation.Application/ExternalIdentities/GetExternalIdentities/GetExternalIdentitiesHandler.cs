using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.GetExternalIdentities;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class GetExternalIdentitiesHandler : IRequestHandler<GetExternalIdentitiesCommand, GetExternalIdentitiesResult>
{
    private readonly IExternalIdentitiesRepository _externalIdentitiesRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetExternalIdentitiesHandler
    /// </summary>
    /// <param name="externalIdentitiesRepository">The External Identities repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetExternalIdentitiesCommand</param>
    public GetExternalIdentitiesHandler(
        IExternalIdentitiesRepository externalIdentitiesRepository,
        IMapper mapper)
    {
        _externalIdentitiesRepository = externalIdentitiesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetExternalIdentitiesCommand request
    /// </summary>
    /// <param name="request">The GetExternalIdentities command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The External Identities details if found</returns>
    public async Task<GetExternalIdentitiesResult> Handle(GetExternalIdentitiesCommand request, CancellationToken cancellationToken)
    {

        var user = await _externalIdentitiesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"External Identities with ID {request.Id} not found");

        return _mapper.Map<GetExternalIdentitiesResult>(user);
    }
}
