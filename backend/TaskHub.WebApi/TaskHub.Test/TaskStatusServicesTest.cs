using AutoMapper;
using Moq;
using TaskHub.WebApi.Repository.Interfaces;
using TaskHub.WebApi.Services;
using TaskHub.WebApi.Models;
using TaskHub.WebApi.DTOs;

namespace TaskHub.Test
{
    public class TaskStatusServicesTest
    {
        private readonly Mock<ITaskStatusRepository> _taskStatusRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TaskStatusServices _taskStatusServicesMock;

        public TaskStatusServicesTest()
        {
            _taskStatusRepositoryMock = new Mock<ITaskStatusRepository>();
            _mapperMock = new Mock<IMapper>();
            _taskStatusServicesMock = new TaskStatusServices(_mapperMock.Object, _taskStatusRepositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnMappedDto_WhenEntityExists()
        {
            // Arrange 

            var taskStatus = new WebApi.Models.TaskStatus { Id = 1, Status = "Todo" };
            var dto = new TaskStatusDto { Id = 1, Status = "Todo" };

            _taskStatusRepositoryMock.Setup(r => r.GetById(1)).ReturnsAsync(taskStatus);
            _mapperMock.Setup(m => m.Map<TaskStatusDto>(taskStatus)).Returns(dto);

            // Action

            var result = await _taskStatusServicesMock.GetById(1);

            // Assert 

            Assert.NotNull(result);
            Assert.Equal(dto.Id, result.Id);
            Assert.Equal(dto.Status, result.Status);
        }

        [Fact]
        public async Task Create_ShouldCallRepositoryWithMappedEntity()
        {
            // Arrange
            var dto = new TaskStatusDto { Id = 1, Status = "New" };
            var entity = new WebApi.Models.TaskStatus { Id = 1, Status = "New" };

            _mapperMock.Setup(m => m.Map<WebApi.Models.TaskStatus>(dto)).Returns(entity);

            // Action
            await _taskStatusServicesMock.Create(dto);

            // Assert
            _taskStatusRepositoryMock.Verify(r => r.Create(entity), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenEntityDoesNotExist()
        {
            // Arrange
            var dto = new TaskStatusDto { Id = 99, Status = "Nonexistent" };
            _taskStatusRepositoryMock.Setup(r => r.GetById(dto.Id)).ReturnsAsync((WebApi.Models.TaskStatus)null);

            // Action
            var ex = await Assert.ThrowsAsync<Exception>(() => _taskStatusServicesMock.Update(dto));

            // Assert 
            Assert.Equal("Task status not found", ex.Message);
        }

        [Fact]
        public async Task Delete_ShouldThrowException_WhenEntityDoesNotExist()
        {
            // Arrange

            _taskStatusRepositoryMock.Setup(r => r.GetById(999)).ReturnsAsync((WebApi.Models.TaskStatus)null);

            // Action

            var ex = await Assert.ThrowsAsync<Exception>(() => _taskStatusServicesMock.Delete(999));

            // Assert
            Assert.Equal("Task status not found", ex.Message);
        }
    }
}
