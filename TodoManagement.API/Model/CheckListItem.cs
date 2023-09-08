namespace TodoManagement.API.Model;


public class CheckListItem: Entity
{
    protected CheckListItem()
    {
        
    }
    public CheckListItem(string title, ToDo toDo)
    {
        Title = title;
        ToDo = toDo;
    }

    public string Title {get; set;}
    public bool IsChecked {get; set;}
    public ToDo ToDo {get; set;}

}