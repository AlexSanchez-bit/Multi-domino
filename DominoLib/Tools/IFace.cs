

public interface IFace //interfaz que abstrae la informacion de una cara de ficha
{
    int GetValue(); //obtiene un valor numerico para la ficha
    bool Equals(IFace face);//permite saber si dos fichas son iguales
    string GetRepresentation(); //obtiene un string con la representacion grafica de la imagen
}
