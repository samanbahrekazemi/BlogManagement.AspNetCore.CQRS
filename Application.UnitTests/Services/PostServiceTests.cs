using Application.DTOs;
using Application.Services;
using AutoMapper;
using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Application.UnitTests.Services
{
    public class PostServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<PostService>> _loggerMock;
        private readonly Mock<IRepository<Post, int>> _repositoryMock;
        private readonly PostService _postService;

        public PostServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<PostService>>();
            _repositoryMock = new Mock<IRepository<Post, int>>();
            _postService = new PostService(_loggerMock.Object, _repositoryMock.Object, _mapperMock.Object);
        }



        [Fact]
        public async Task CreateAsync_WithValidDto_ShouldReturnSuccessResultWithPostDto()
        {
            // Arrange
            var createDto = new CreatePostDto() { Title = "ASP.NET Core", CategoryId = 1 };
            var post = new Post();
            var entry = new Post();
            var expectedDto = new PostDto();

            _mapperMock.Setup(m => m.Map<Post>(createDto)).Returns(post);
            _repositoryMock.Setup(r => r.AddAsync(post)).ReturnsAsync(entry);
            _mapperMock.Setup(m => m.Map<PostDto>(entry)).Returns(expectedDto);

            // Act
            var result = await _postService.CreateAsync(createDto);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(expectedDto, result.Data);
        }


        [Fact]
        public async Task CreateAsync_WithInvalidDto_ShouldReturnFailureResultWithErrorMessage()
        {
            // Arrange
            var createDto = new CreatePostDto();
            var post = new Post();
            var entry = new Post();
            var expectedDto = new PostDto();

            _mapperMock.Setup(m => m.Map<Post>(createDto)).Returns(post);
            _repositoryMock.Setup(r => r.AddAsync(post)).ReturnsAsync(entry);
            _mapperMock.Setup(m => m.Map<PostDto>(entry)).Returns(expectedDto);

            // Act
            var result = await _postService.CreateAsync(createDto);

            // Assert
            Assert.False(result.Succeeded);
        }

    }

}
