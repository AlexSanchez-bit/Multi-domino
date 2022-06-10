public interface IScreen :ITableObserver ,IPlayerChangedObserver,IWinnerObserver
{

 public void Start();
 public void Stop();
}