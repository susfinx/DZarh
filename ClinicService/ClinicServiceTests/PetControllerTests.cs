namespace ClinicServiceTests
{
    public class PetControllerTests
    {
        private PetController _petController;
        private Mock<IPetRepository> _mockPetRepository;

        public PetControllerTests()
        {
            _mockPetRepository = new Mock<IPetRepository>();
            _petController = new PetController(_mockPetRepository.Object);
        }

        [Fact]
        public void CreatePetTest()
        {
            // Arrange
            CreatePetRequest createPetRequest = new CreatePetRequest
            {
                ClientId = 1,
                Name = "Buddy",
                Birthday = new DateTime(2010, 5, 10)
            };

            _mockPetRepository.Setup(repository => repository.Create(It.IsNotNull<Pet>())).Returns(1).Verifiable();

            // Act
            var operationResult = _petController.Create(createPetRequest);

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockPetRepository.Verify(repository => repository.Create(It.IsNotNull<Pet>()), Times.AtLeastOnce());
        }

        [Fact]
        public void UpdatePetTest()
        {
            // Arrange
            UpdatePetRequest updatePetRequest = new UpdatePetRequest
            {
                PetId = 1,
                ClientId = 1,
                Name = "UpdatedBuddy",
                Birthday = new DateTime(2010, 5, 10)
            };

            _mockPetRepository.Setup(repository => repository.Update(It.IsNotNull<Pet>())).Returns(1).Verifiable();

            // Act
            var operationResult = _petController.Update(updatePetRequest);

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockPetRepository.Verify(repository => repository.Update(It.IsNotNull<Pet>()), Times.AtLeastOnce());
        }

        [Fact]
        public void DeletePetTest()
        {
            // Arrange
            int petId = 1;

            _mockPetRepository.Setup(repository => repository.Delete(petId)).Returns(1).Verifiable();

            // Act
            var operationResult = _petController.Delete(petId);

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockPetRepository.Verify(repository => repository.Delete(petId), Times.AtLeastOnce());
        }
    }
}
