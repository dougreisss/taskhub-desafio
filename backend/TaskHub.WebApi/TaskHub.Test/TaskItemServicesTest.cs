using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using Moq;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Models;
using TaskHub.WebApi.Repository.Interfaces;
using TaskHub.WebApi.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskHub.Test
{
    public class TaskItemServicesTest
    {
        private readonly Mock<ITaskItemRepository> _taskItemRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TaskItemServices _taskItemServices;
        public TaskItemServicesTest()
        {
            _taskItemRepositoryMock = new Mock<ITaskItemRepository>();
            _mapperMock = new Mock<IMapper>();
            _taskItemServices = new TaskItemServices(_mapperMock.Object, _taskItemRepositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnMappedDto_WhenEntityExists()
        {
            // Arrange 

            var dueDate = DateTime.Now.AddDays(2);
            var createdAt = DateTime.Now;

            var taskItem = new TaskItem 
            { 
                Id = 1, 
                Title = "Test", 
                Description = "Teste",  
                StatusId = 1, 
                Status = new WebApi.Models.TaskStatus
                {
                    Id = 1,
                    Status = "Todo"
                },
                DueDate = dueDate, 
                CreatedAt = createdAt
            };

            var dto = new TaskItemDto 
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Status = new TaskStatusDto { Id = 1, Status = "Todo" },
                DueDate = dueDate,
                CreatedAt = createdAt
            };

            _taskItemRepositoryMock.Setup(r => r.GetById(1)).ReturnsAsync(taskItem);
            _mapperMock.Setup(m => m.Map<TaskItemDto>(taskItem)).Returns(dto);

            // Action

            var result = await _taskItemServices.GetById(1);

            // Assert 

            Assert.NotNull(result);
            Assert.Equal(dto.Id, result.Id);
            Assert.Equal(dto.Title, result.Title);
            Assert.Equal(dto.Description, result.Description);
            Assert.Equal(dto.Status.Id, result.Status.Id);
            Assert.Equal(dto.Status.Status, result.Status.Status);
            Assert.Equal(dto.DueDate, result.DueDate);
            Assert.Equal(dto.CreatedAt, result.CreatedAt);
        }

        [Fact]
        public async Task Create_ShouldCallRepositoryWithMappedEntity()
        {
            // Arrange 

            var dueDate = DateTime.Now.AddDays(2);
            var createdAt = DateTime.Now;

            var taskItem = new TaskItem
            {
                Id = 1,
                Title = "Test",
                Description = "Teste",
                StatusId = 1,
                Status = new WebApi.Models.TaskStatus
                {
                    Id = 1,
                    Status = "Todo"
                },
                DueDate = dueDate,
                CreatedAt = createdAt
            };

            var dto = new CreateTaskItemDto
            {
                Title = "Test",
                Description = "Test",
                StatusId = 1,
                DueDate = dueDate
            };

            _mapperMock.Setup(m => m.Map<TaskItem>(dto)).Returns(taskItem);

            // Action

            await _taskItemServices.Create(dto);

            // Assert 
            _taskItemRepositoryMock.Verify(r => r.Create(taskItem), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenEntityDoesNotExist()
        {
            // Arrange

            var dueDate = DateTime.Now.AddDays(2);

            var dto = new UpdateTaskItemDto
            {
                Id = 999,
                Title = "Test",
                Description = "Test",
                StatusId = 1,
                DueDate = dueDate
            };

            _taskItemRepositoryMock.Setup(r => r.GetById(dto.Id)).ReturnsAsync((TaskItem)null);

            // Action
            var ex = await Assert.ThrowsAsync<Exception>(() => _taskItemServices.Update(dto));

            // Assert 
            Assert.Equal("Task item not found", ex.Message);
        }

        [Fact]
        public async Task Delete_ShouldThrowException_WhenEntityDoesNotExist()
        {
            // Arrange 

            _taskItemRepositoryMock.Setup(r => r.GetById(999)).ReturnsAsync((TaskItem)null);

            // Action

            var ex = await Assert.ThrowsAsync<Exception>(() => _taskItemServices.Delete(999));

            // Assert 
            Assert.Equal("Task item not found", ex.Message);
        }
    }
}
