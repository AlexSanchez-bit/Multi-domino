public class CustomEvent<T> : IEvent<T> //evento generico
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
