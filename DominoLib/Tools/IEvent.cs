

public interface IEvent<T> //interfaz que describe un evento y los datos asociados a este
{
  T GetEventData();//devuelve el dato que guarda el evento
}
