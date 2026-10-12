using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;

    [Header("Panels")]
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelCredits;


    private void Awake()
    {
        btnPlay.onClick.AddListener(OnBtnPlayClicked);
        btnSettings.onClick.AddListener(OnBtnSettingsClicked);
        btnCredits.onClick.AddListener(OnBtnCreditsClicked);
        btnExit.onClick.AddListener(OnBtnExitClicked);

#if UNITY_WEBGL && !UNITY_EDITOR
btnExit.gameObject.SetActive(false);
#endif
    }


    private void Start()
    {
        panelMainMenu.SetActive(true);
        panelSettings.SetActive(false);
        panelCredits.SetActive(false);
    }
    private void OnDestroy()
    {
        btnPlay.onClick.RemoveListener(OnBtnPlayClicked);
        btnSettings.onClick.RemoveListener(OnBtnSettingsClicked);
        btnCredits.onClick.RemoveListener(OnBtnCreditsClicked);
    }

    private void OnBtnPlayClicked()
    {
        panelMainMenu.SetActive(false);
        Invoke(nameof(PlayAction), 0.5f);
    }

    private void PlayAction()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnBtnSettingsClicked()
    {
        panelSettings.SetActive(true);
        panelCredits.SetActive(false);
        panelMainMenu.SetActive(false);
    }

    private void OnBtnCreditsClicked()
    {
        panelCredits.SetActive(true);
        panelSettings.SetActive(false);
        panelMainMenu.SetActive(false);
    }
    private void OnBtnExitClicked()
    {
        Invoke(nameof(ExitAction), 0.5f);
        Time.timeScale = 1.0f;
    }

    private void ExitAction()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
