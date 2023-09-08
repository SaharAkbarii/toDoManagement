using TodoManagement.API.Model;


namespace TodoManagement.API.DTO;

public class CheckListItemDto
{
    public string Title { get; set; }
    public bool IsChecked { get; set; }
    public Guid Id { get; set; }
}
