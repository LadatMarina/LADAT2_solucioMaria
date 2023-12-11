using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public static PauseUI Instance { get; private set; }

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
        
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ResumeGame();
            SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            Loader.Load(Loader.Scene.MainMenu);
            SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        });
        
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
