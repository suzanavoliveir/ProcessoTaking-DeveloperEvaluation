using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalIdentitiesController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ExternalIdentitiesController> _logger;
        private readonly IExternalIdentitiesService _service;

        public ExternalIdentitiesController(IMediator mediator, IMapper mapper,
                        ILogger<ExternalIdentitiesController> logger,
                        IExternalIdentitiesService service)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _service = service;
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
            _logger.LogInformation("Begin Create ExternalIdentities: {@Request}", request);

            var validator = new CreateExternalIdentitiesRequestValidator(_logger);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            var entity = _mapper.Map<Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities>(request);
            var created = await _service.CreateAsync(entity, cancellationToken);

            if (created == null)
            {
                _logger.LogError("Failed to create ExternalIdentities");
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Failed to create External Identities"
                });
            }

            _logger.LogInformation("End Create ExternalIdentities: {@Created}", created);

            var response = _mapper.Map<CreateExternalIdentitiesResponse>(created);
            return Created(string.Empty, new ApiResponseWithData<CreateExternalIdentitiesResponse>
            {
                Success = true,
                Message = "External Identities created successfully",
                Data = response
            });
        }

        /// <summary>
        /// Retrieves a External Identitie by their ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateExternalIdentitiesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExternalIdentitie([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Get ExternalIdentities: Id {Id}", id);

            var entity = await _service.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                _logger.LogWarning("ExternalIdentities not found: Id {Id}", id);
                return NotFound("ExternalIdentities not found");
            }

            var response = _mapper.Map<CreateExternalIdentitiesResponse>(entity);
            _logger.LogInformation("End Get ExternalIdentities: {@Response}", response);

            return Ok(new ApiResponseWithData<CreateExternalIdentitiesResponse>
            {
                Success = true,
                Message = "External Identitie retrieved successfully",
                Data = response
            });
        }

        /// <summary>
        /// Updates a External Identitie by their ID
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateExternalIdentitie([FromRoute] Guid id, [FromBody] Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities externalIdentities, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Update ExternalIdentities: {@ExternalIdentities}", externalIdentities);

            var updated = await _service.UpdateAsync(externalIdentities, cancellationToken);

            if (!updated)
            {
                _logger.LogError("Failed to update ExternalIdentities: Id {Id}", id);
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Failed to update External Identities"
                });
            }

            _logger.LogInformation("End Update ExternalIdentities: Id {Id}", id);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "External Identities updated successfully"
            });
        }


        /// <summary>
        /// Deletes a External Identitie by their ID
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteExternalIdentitie([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Delete ExternalIdentities: Id {Id}", id);

            var deleted = await _service.DeleteAsync(id, cancellationToken);
            if (!deleted)
            {
                _logger.LogWarning("Failed to delete ExternalIdentities: Id {Id}", id);
                return NotFound("ExternalIdentities not found");
            }

            _logger.LogInformation("End Delete ExternalIdentities: Id {Id}", id);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "External Identities deleted successfully"
            });
        }
    }
}

