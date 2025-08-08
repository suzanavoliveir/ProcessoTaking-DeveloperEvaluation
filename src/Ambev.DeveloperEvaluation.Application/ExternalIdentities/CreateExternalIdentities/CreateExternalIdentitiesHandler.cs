using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.CreateIExternalIdentities;

/// <summary>
/// Handler for processing CreateExternalIdentitiesCommand requests
/// </summary>
public class CreateExternalIdentitiesHandler : IRequestHandler<CreateExternalIdentitiesCommand, CreateExternalIdentitiesResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of CreateExternalIdentitiesHandler
    /// </summary>
    /// <param name="userRepository">The External Identities repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateExternalIdentitiesCommand</param>
    public CreateExternalIdentitiesHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Handles the CreateExternalIdentitiesCommand request
    /// </summary>
    /// <param name="command">The CreateExternalIdentities command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<CreateExternalIdentitiesResult> Handle(CreateExternalIdentitiesCommand command, CancellationToken cancellationToken)
    {

        var externalIdentities = _mapper.Map<User>(command); //ALTERAR
        var createdExternalIdentities = await _userRepository.CreateAsync(externalIdentities, cancellationToken);
        var result = _mapper.Map<CreateExternalIdentitiesResult>(createdExternalIdentities);
        return result;
    }
}
