using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ClinicServiceTests
{
    public class ConsultationControllerTests
    {
        private ConsultationController _consultationController;
        private Mock<IConsultationRepository> _mockConsultationRepository;

        public ConsultationControllerTests()
        {
            _mockConsultationRepository = new Mock<IConsultationRepository>();
            _consultationController = new ConsultationController(_mockConsultationRepository.Object);
        }

        [Fact]
        public void CreateConsultationTest()
        {
            // Arrange
            CreateConsultationRequest createConsultationRequest = new CreateConsultationRequest
            {
                ClientId = 1,
                PetId = 1,
                ConsultationDate = DateTime.Now,
                Description = "Regular checkup"
            };

            _mockConsultationRepository.Setup(repository => repository.Create(It.IsNotNull<Consultation>())).Returns(1).Verifiable();

            // Act
            var operationResult = _consultationController.Create(createConsultationRequest);

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockConsultationRepository.Verify(repository => repository.Create(It.IsNotNull<Consultation>()), Times.AtLeastOnce());
        }

        [Fact]
        public void UpdateConsultationTest()
        {
            // Arrange
            UpdateConsultationRequest updateConsultationRequest = new UpdateConsultationRequest
            {
                ConsultationId = 1,
                ClientId = 1,
                PetId = 1,
                ConsultationDate = DateTime.Now,
                Description = "Updated checkup"
            };

            _mockConsultationRepository.Setup(repository => repository.Update(It.IsNotNull<Consultation>())).Returns(1).Verifiable();

            // Act
            var operationResult = _consultationController.Update(updateConsultationRequest);

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockConsultationRepository.Verify(repository => repository.Update(It.IsNotNull<Consultation>()), Times.AtLeastOnce());
        }

        [Fact]
        public void DeleteConsultationTest()
        {
            // Arrange
            int consultationId = 1;

            _mockConsultationRepository.Setup(repository => repository.Delete(consultationId)).Returns(1).Verifiable();

            // Act
            var operationResult = _consultationController.Delete(consultationId);

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockConsultationRepository.Verify(repository => repository.Delete(consultationId), Times.AtLeastOnce());
        }
    }
}
