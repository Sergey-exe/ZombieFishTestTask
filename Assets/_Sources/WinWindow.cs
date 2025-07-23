using UnityEngine;

public class WinWindow : Window
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private TimeChanger _timeChanger;

    protected override void StartAction()
    {
        _sceneLoader.LoadScene();
        _timeChanger.StartTime();
    }

    public void ShowWindow()
    {
        MainWindow.SetActive(true);
    }
}