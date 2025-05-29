using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button backButton;
    public Button replayButton;

    void Start()
    {
        if (playButton != null)
            playButton.onClick.AddListener(() => GameManager.Instance.Play());

        if (quitButton != null)
            quitButton.onClick.AddListener(() => GameManager.Instance.Quit());

        if (backButton != null)
            backButton.onClick.AddListener(() => GameManager.Instance.BackToMenu());

        if (replayButton != null)
            replayButton.onClick.AddListener(() => GameManager.Instance.Replay());
    }
}
