using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;

public class CheckListItemInputBase
{
    public string Title {get; set;}
    public bool IsChecked {get; set;} 
}

public class AddCheckListItemInput : CheckListItemInputBase
{

}

public class UpdateCheckListItemInput : CheckListItemInputBase
{

}