namespace TodoManagement.API.Model;

public class Project : Entity
{
    public Project(string name, string description)
    {
        Name = name;
        Description = description;
        ToDos = new List<ToDo>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public List<ToDo> ToDos { get; set; }
    public int ProgressPercent
    {
        get

        {
            var totalStoryPoint = ToDos.Sum(x => x.StoryPoint);
            var doneStoryPoint = ToDos.Where(x => x.Status == ToDoStatus.Done).Sum(x => x.StoryPoint);
            if (totalStoryPoint == 0)
                return 100;
            return (doneStoryPoint * 100) / totalStoryPoint;
        }

    }
    public DateTimeOffset? DeadLine { get; set; }

    public DeadLineState DeadLineState
    {
        get
        {
            if (!DeadLine.HasValue)
                return DeadLineState.HasTime;

            var remainTime = (DeadLine.Value - DateTimeOffset.Now).Days;

            if (remainTime > 5)
                return DeadLineState.HasTime;

            else if (remainTime > 0 && remainTime < 5)
                return DeadLineState.TimeIsTight;

            else
                return DeadLineState.DeadLineIsTouch;


        }
    }


}
public enum DeadLineState
{
    HasTime = 0,
    TimeIsTight = 1,
    DeadLineIsTouch = 2,
}
