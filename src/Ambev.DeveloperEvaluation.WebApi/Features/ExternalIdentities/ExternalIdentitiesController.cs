using Ambev.DeveloperEvaluation.Application.ExternalIdentities.CreateIExternalIdentities;
using Ambev.DeveloperEvaluation.Application.ExternalIdentities.DeleteExternalIdentities;
using Ambev.DeveloperEvaluation.Application.ExternalIdentities.GetExternalIdentities;
using Ambev.DeveloperEvaluation.Application.ExternalIdentities.UpdateExternalIdentities;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.GetExternalIdentities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalIdentitiesController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ExternalIdentitiesController> _logger;


        public ExternalIdentitiesController(IMediator mediator, IMapper mapper,
                        ILogger<ExternalIdentitiesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }



        /// <summary>
        /// Creates a new External Identities
        /// </summary>
        /// <param name="request">The External Identities creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created External Identities details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateExternalIdentitiesResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateExternalIdentities([FromBody] CreateExternalIdentitiesRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Create ExternalIdentities: {request}", request);

            var validator = new CreateExternalIdentitiesRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Error Validation Create ExternalIdentities: "+ validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }

            var command = _mapper.Map<CreateExternalIdentitiesCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
            {
                _logger.LogError("Failed to create ExternalIdentities");
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Failed to create External Identities"
                });
            }
            else
            {
                _logger.LogInformation("End Create ExternalIdentities: {response}", response);

            }

            return Created(string.Empty, new ApiResponseWithData<CreateExternalIdentitiesResponse>
                {
                    Success = true,
                    Message = "External Identities created successfully",
                    Data = _mapper.Map<CreateExternalIdentitiesResponse>(response)
                });

        }

        /// <summary>
        /// Retrieves a External Identitie by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the External Identitie</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The External Identitie details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetExternalIdentitiesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExternalIdentitie([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Get ExternalIdentities: Id {id}", id);

            var request = new GetUserRequest { Id = id };
            var command = _mapper.Map<GetExternalIdentitiesCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("End Get ExternalIdentities: {response}", request);

            return Ok(new ApiResponseWithData<GetExternalIdentitiesResponse>
            {
                Success = true,
                Message = "External Identitie retrieved successfully",
                Data = _mapper.Map<GetExternalIdentitiesResponse>(response)
            });
        }

        /// <summary>
        /// Updates a External Identitie by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the External Identitie to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the user was deleted</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateExternalIdentitie([FromBody] Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities externalIdentities, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Update ExternalIdentities: "+ externalIdentities);

            var command = new UpdateExternalIdentitiesCommand(externalIdentities);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Failed to Update ExternalIdentities");
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Failed to Update External Identities"
                });
            }
            else
            {
                _logger.LogInformation("End Update ExternalIdentities: {result}", result);
            }

            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        /// <summary>
        /// Deletes a External Identitie by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the External Identitie to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the user was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteExternalIdentitie([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Delete ExternalIdentities: Id" + id);

            var command = _mapper.Map<DeleteExternalIdentitiesCommand>(id);
            await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("End Delete ExternalIdentities: {Id}", id);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "User deleted successfully"
            });
        }


    }
}
