namespace RestService.UnitTests;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RestService.Api.Controllers;
using RestService.Api.Entities;
using RestService.Api.Repositories;
using Xunit;

public class ItemsControllerTests
{
    [Fact]
    public async Task GetItemAsync_WithUnexistingItem_NotFound()
    {
        // Arrange
        var repositoryStub = new Mock<IItemsRepository>(); 
        repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Item)null);

        var loggerStub = new Mock<ILogger<ItemsController>>();

        var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

        // Act
        var result = await controller.GetItemAsync(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}