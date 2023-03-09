using Application.DTOs;
using AutoMapper;
using Core.Models;
using System.Reflection;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            //Mappings
            CreateMap<CreateCategoryDto, CategoryDto>()
                .ForMember(a => a.Id , opt => opt.Ignore())
                .ForMember(a => a.CreatedAt , opt => opt.Ignore())
                .ForMember(a => a.ModifiedAt , opt => opt.Ignore())
                .ForMember(a => a.Posts, opt => opt.Ignore());

            CreateMap<CreatePostDto, PostDto>()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.CreatedAt, opt => opt.Ignore())
                .ForMember(a => a.ModifiedAt, opt => opt.Ignore())
                .ForMember(a => a.PostTags, opt => opt.Ignore())
                .ForMember(a => a.Category, opt => opt.Ignore());

            CreateMap<CreateTagDto, TagDto>()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.CreatedAt, opt => opt.Ignore());




            CreateMap<UpdateCategoryDto, CategoryDto>()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.CreatedAt, opt => opt.Ignore())
                .ForMember(a => a.ModifiedAt, opt => opt.Ignore())
                .ForMember(a => a.Posts, opt => opt.Ignore());

            CreateMap<UpdatePostDto, PostDto>()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.CreatedAt, opt => opt.Ignore())
                .ForMember(a => a.ModifiedAt, opt => opt.Ignore())
                .ForMember(a => a.PostTags, opt => opt.Ignore())
                .ForMember(a => a.Category, opt => opt.Ignore());

            CreateMap<UpdateTagDto, TagDto>()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.CreatedAt, opt => opt.Ignore());

        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);

            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);
                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}
