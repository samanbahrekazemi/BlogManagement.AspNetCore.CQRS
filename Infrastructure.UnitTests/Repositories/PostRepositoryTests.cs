using Core.Models;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Infrastructure.UnitTests.Repositories
{
    [TestFixture]
    public class PostRepositoryTests
    {
        private Mock<IApplicationDbContext> _dbContextMock;
        private IRepository<Post, int> _postRepository;


        [SetUp]
        public void Setup()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _dbContextMock.Setup(x => x.Set<Post>()).Returns(Mock.Of<DbSet<Post>>());
            _postRepository = new Repository<Post, int>(_dbContextMock.Object);
        }

        [Test]
        public async Task AddAsync_ShouldAddPostToContext()
        {
            // Arrange
            var entity = new Post();

            // Act
            var result = await _postRepository.AddAsync(entity);

            // Assert
            Assert.AreEqual(entity, result);

            // Ensure that SaveChangesAsync was called
            _dbContextMock.VerifyAll();
        }

    }

}
