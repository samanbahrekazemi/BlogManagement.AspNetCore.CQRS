namespace Application.DTOs
{
    public class CreateCategoryDto
    {
        public CreateCategoryDto()
        {

        }
        public CreateCategoryDto(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string? Content { get; set; }

    }
}
