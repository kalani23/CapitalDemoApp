using CapitalPlacement.Data;
using CapitalPlacement.Models.Entities;
using CapitalPlacement.Repositories;
using Microsoft.Azure.Cosmos;
using Moq;
using Xunit;

namespace YourNamespace.Tests.Repositories
{
    public class ApplicationFormRepositoryTests
    {
        private readonly Mock<CosmosDbService> _cosmosDbServiceMock;
        private readonly Mock<Container> _containerMock;
        private readonly Mock<IExceptionHandler> _exceptionHandlerMock;
        private readonly ApplicationFormRepository _repository;

        public ApplicationFormRepositoryTests()
        {
            _cosmosDbServiceMock = new Mock<CosmosDbService>();
            _containerMock = new Mock<Container>();
            _exceptionHandlerMock = new Mock<IExceptionHandler>();
            _repository = new ApplicationFormRepository(_cosmosDbServiceMock.Object, _exceptionHandlerMock.Object);
        }

        [Fact]
        public async Task CreateFormFieldAsync_ValidField_ReturnsField()
        {
            // Arrange
            var field = new ApplicationFormField
            {
                Id = Guid.NewGuid(),
                QuestionText = "What is the program you are interested?",
                AnswerOptions = new List<string> { "Test Program1", "Test Program2" },
                FieldType = FieldType.MultipleChoice,
                IsRequired = true
            };

            var itemResponseMock = new Mock<ItemResponse<ApplicationFormField>>();
            itemResponseMock.SetupGet(r => r.Resource).Returns(field);

            _containerMock.Setup(c => c.CreateItemAsync(field, It.IsAny<PartitionKey>(), null, default))
                          .ReturnsAsync(itemResponseMock.Object);

            // Act
            var result = await _repository.CreateFormFieldAsync(field);

            // Assert
            Assert.NotNull(result); 
            Assert.Equal(field, result);
        }

    }
}
