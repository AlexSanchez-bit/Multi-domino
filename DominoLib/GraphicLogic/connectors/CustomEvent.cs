public class CustomEvent<T> : IEvent<T>
{
    T eventData;

    public CustomEvent(T data)
    {
        eventData=data;
    }
    public T GetEventData()
    {
        return eventData; 
    }
}