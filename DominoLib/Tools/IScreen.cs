public interface IScreen :ITableObserver ,IPlayerChangedObserver,IWinnerObserver
//interfaz que describe un controlador de pantalla (parte grafica)
{

 public void Start();//inicializa el proceso
 public void Stop();//finaliza el proceso
}
