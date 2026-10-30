namespace DefaultNamespace;

public interface IEventService
{
    void setTitle(string title);
    void setDescription(string description);
    void setStartAt(DateTime startAt);
    void setEndAt(DateTime  endAt);    
}