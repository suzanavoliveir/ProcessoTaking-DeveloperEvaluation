using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities;
using Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="ExternalIdentities"/> class.
/// </summary>
public class ExternalIdentitiesTests
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    private readonly Mock<IExternalIdentitiesService> _serviceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ILogger<ExternalIdentitiesController>> _loggerMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ExternalIdentitiesController _controller;

    public ExternalIdentitiesTests()
    {
        _serviceMock = new Mock<IExternalIdentitiesService>();
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<ExternalIdentitiesController>>();
        _mediatorMock = new Mock<IMediator>();

        _controller = new ExternalIdentitiesController(
            _mediatorMock.Object,
            _mapperMock.Object,
            _loggerMock.Object,
            _serviceMock.Object
        );
    }

    [Fact]
    public async Task CreateExternalIdentities_ShouldReturn201_WhenValid()
    {
        // Arrange
        var request = new CreateExternalIdentitiesRequest {
            SaleNumber = "12345",
            DateSale = DateTime.UtcNow,
            Customer = "Test Customer",
            TotalSaleAmout = 276,
            BranchSale = "Main Branch",
            Products = ExternalIdentitiesProduct.ProdutionOne,
            Quantities = 12,
            UnitPrices = 23.00,
            Discounts = 10,
            TotalItem = 250.00,
            StatusCancel = ExternalIdentitiesCancel.NotCancelled

        };
        var entity = new ExternalIdentities { };

        _mapperMock.Setup(m => m.Map<ExternalIdentities>(request)).Returns(entity);
        _serviceMock.Setup(s => s.CreateAsync(entity, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);
        _mapperMock.Setup(m => m.Map<CreateExternalIdentitiesResponse>(entity))
                   .Returns(new CreateExternalIdentitiesResponse { 
                        Id = Guid.NewGuid(),
                        SaleNumber = request.SaleNumber,
                        Customer = request.Customer,
                        Quantities = request.Quantities,
                        BranchSale = request.BranchSale,
                        UnitPrices = request.UnitPrices,
                        Discounts = request.Discounts,
                        StatusCancel = request.StatusCancel
                   });

        // Act
        var result = await _controller.CreateExternalIdentities(request, CancellationToken.None);

        // Assert
        var createdResult = Assert.IsType<CreatedResult>(result);
        var response = Assert.IsType<ApiResponseWithData<CreateExternalIdentitiesResponse>>(createdResult.Value);
        Assert.True(response.Success);
    }

    [Fact]
    public async Task GetExternalIdentitie_ShouldReturn200_WhenFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = new ExternalIdentities { };

        _serviceMock.Setup(s => s.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(entity);

        _mapperMock.Setup(m => m.Map<CreateExternalIdentitiesResponse>(entity))
                   .Returns(new CreateExternalIdentitiesResponse { Id = id });

        // Act
        var result = await _controller.GetExternalIdentitie(id, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ApiResponseWithData<CreateExternalIdentitiesResponse>>(okResult.Value);
        Assert.True(response.Success);
        Assert.Equal("Test User", response.Message);
    }

    [Fact]
    public async Task GetExternalIdentitie_ShouldReturn404_WhenNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        _serviceMock.Setup(s => s.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                    .ReturnsAsync((ExternalIdentities?)null);

        // Act
        var result = await _controller.GetExternalIdentitie(id, CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task UpdateExternalIdentitie_ShouldReturn200_WhenUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = new ExternalIdentities {
            SaleNumber = "12345",
            DateSale = DateTime.UtcNow,
            Customer = "Test Customer",
            TotalSaleAmout = 276,
            BranchSale = "Main Branch",
            Products = ExternalIdentitiesProduct.ProdutionOne,
            Quantities = 10,
            UnitPrices = 23.00,
            Discounts = 5,
            TotalItem = 250.00,
            StatusCancel = ExternalIdentitiesCancel.NotCancelled
        };

        _serviceMock.Setup(s => s.UpdateAsync(entity, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateExternalIdentitie(id, entity, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ApiResponse>(okResult.Value);
        Assert.True(response.Success);
    }

    [Fact]
    public async Task DeleteExternalIdentitie_ShouldReturn200_WhenDeleted()
    {
        // Arrange
        var id = Guid.NewGuid();
        _serviceMock.Setup(s => s.DeleteAsync(id, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteExternalIdentitie(id, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ApiResponse>(okResult.Value);
        Assert.True(response.Success);
    }

    [Fact]
    public async Task DeleteExternalIdentitie_ShouldReturn404_WhenNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        _serviceMock.Setup(s => s.DeleteAsync(id, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteExternalIdentitie(id, CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }


}
