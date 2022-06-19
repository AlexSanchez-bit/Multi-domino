using Avalonia.Controls;
public interface ITemporalWindow
{
    void GoToNextWindow(Window original);
    void ReturnToOriginal();
}