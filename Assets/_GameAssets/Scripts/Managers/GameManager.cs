using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // t�m sahnelerde kal�c�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Sahne kontrol fonksiyonlar�
    public void Play() => SceneManager.LoadScene("GameScene");
    public void Quit() => Application.Quit();
    public void Win() => SceneManager.LoadScene("WinMenu");
    public void Lose() => SceneManager.LoadScene("DieMenu");
    public void BackToMenu() => SceneManager.LoadScene("MainMenu");
    public void Replay() => SceneManager.LoadScene("GameScene");
}
