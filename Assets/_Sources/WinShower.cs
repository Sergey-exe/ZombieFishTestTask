using UnityEngine;

public class WinShower : MonoBehaviour
{
    [SerializeField] private WinWindow _winWindow;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private TimeChanger _timeChanger;

    private void OnEnable()
    {
        _wallet.Win += Show;
    }

    private void OnDisable()
    {
        _wallet.Win -= Show;
    }

    public void Show()
    {
        _winWindow.ShowWindow();
        _levelBuilder.StopGame();
        _timeChanger.StopTime();
    }
}