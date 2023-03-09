namespace Application.DTOs
{
    public class CreateCategoryDto
    {
        public CreateCategoryDto()
        {

        }
        public CreateCategoryDto(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
        public string? Content { get; set; }

    }
}
