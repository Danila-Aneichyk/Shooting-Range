using UnityEngine;

public class UIMediator : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private Pause _pause;
    public bool IsPaused;

    private void Awake()
    {
        _pauseScreen.SetActive(false);
    }

    private void Start()
    {
        _pause.OnPaused += Paused; 
    }

    private void OnDestroy()
    {
        _pause.OnPaused -= Paused;
    }

    private void Paused(bool isPaused)
    {
        _pauseScreen.SetActive(isPaused);
        IsPaused = true;
    }
}