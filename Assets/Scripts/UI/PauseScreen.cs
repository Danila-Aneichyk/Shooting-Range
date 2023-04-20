using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : BaseScreen
{
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _continueButton;

    private void Awake()
    {
        _toMenuButton.onClick.AddListener(MoveToNextScene);
        _exitButton.onClick.AddListener(Exit);
        _continueButton.onClick.AddListener(FindObjectOfType<Pause>().Resume);
    }
}