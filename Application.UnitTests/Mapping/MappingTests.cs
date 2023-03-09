using Application.Common.Mapping;
using Application.DTOs;
using AutoMapper;
using Core.Models;
using NUnit.Framework;
using System.Runtime.Serialization;

namespace Application.UnitTests.Mapping
{
    public class MappingTests
    {
        private IMapper _mapper;
        private readonly IConfigurationProvider _configuration;
        public MappingTests()
        {
            _configuration = new MapperConfiguration(config => config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(Post), typeof(PostDto))]
        [TestCase(typeof(Category), typeof(CategoryDto))]
        [TestCase(typeof(Tag), typeof(TagDto))]
        [TestCase(typeof(CreateCategoryDto), typeof(CategoryDto))]
        [TestCase(typeof(CreatePostDto), typeof(PostDto))]
        [TestCase(typeof(CreateTagDto), typeof(TagDto))]
        [TestCase(typeof(UpdateCategoryDto), typeof(CategoryDto))]
        [TestCase(typeof(UpdatePostDto), typeof(PostDto))]
        [TestCase(typeof(UpdateTagDto), typeof(TagDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);
            _mapper.Map(instance, source, destination);
        }



        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
