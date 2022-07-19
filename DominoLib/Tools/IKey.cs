public interface IKey //interface que abstrae las propiedades de una ficha
{
    IFace GetFace(int i);// obtiene la cara i-esima de la ficha
    IEnumerable<IFace> GetAllFaces(); //devuelve un enumerable con las caras de la ficha      
    bool FitWith(IKey other);//perite saber si una ficha encaja con otra
    int GetValue();//obtiene el valor de la ficha
}
