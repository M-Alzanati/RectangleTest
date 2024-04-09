using System.Text.Json;
using Moq;
using RectangleApi.Models;
using RectangleApi.Services;

namespace RectangleApi.UnitTests.Services;

public class RectangleServiceTests
{
    private RectangleService _rectangleService;
    private CancellationToken _cancellationToken;

    [SetUp]
    public void SetUp()
    {
        _rectangleService = new RectangleService();
        _cancellationToken = new CancellationToken();
    }

    [Test]
    public async Task GetDimensions_ReturnsDimensions_WhenFileExistsAndIsReadable()
    {
        // Arrange
        var expectedDimensions = new Dimensions { Length = 5, Width = 10 };
        _fileMock.Setup(f => f.ReadAllTextAsync(It.IsAny<string>(), _cancellationToken))
            .ReturnsAsync(JsonSerializer.Serialize(expectedDimensions));
        _jsonSerializerMock
            .Setup(js => js.Deserialize<Dimensions>(It.IsAny<string>(), It.IsAny<JsonSerializerOptions>()))
            .Returns(expectedDimensions);

        // Act
        var actualDimensions = await _rectangleService.GetDimensions(_cancellationToken);

        // Assert
        Assert.AreEqual(expectedDimensions, actualDimensions);
    }

    [Test]
    public async Task GetDimensions_ReturnsNull_WhenFileDoesNotExist()
    {
        // Arrange
        _fileMock.Setup(f => f.ReadAllTextAsync(It.IsAny<string>(), _cancellationToken))
            .Throws(new FileNotFoundException());

        // Act
        var actualDimensions = await _rectangleService.GetDimensions(_cancellationToken);

        // Assert
        Assert.IsNull(actualDimensions);
    }

    [Test]
    public async Task GetDimensions_ReturnsNull_WhenFileIsNotReadable()
    {
        // Arrange
        _fileMock.Setup(f => f.ReadAllTextAsync(It.IsAny<string>(), _cancellationToken))
            .Throws(new IOException());

        // Act
        var actualDimensions = await _rectangleService.GetDimensions(_cancellationToken);

        // Assert
        Assert.IsNull(actualDimensions);
    }
}