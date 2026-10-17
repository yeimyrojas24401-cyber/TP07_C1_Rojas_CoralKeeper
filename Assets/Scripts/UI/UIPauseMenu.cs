using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnMainMenu;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnHowToPlay;

    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelHowToPlay;


    private void Awake()
    {
        btnContinue.onClick.AddListener(OnBtnContinueClicked);
        btnSettings.onClick.AddListener(OnBtnSettingsClicked);
        btnMainMenu.onClick.AddListener(OnBtnMainMenuClicked);
        btnRetry.onClick.AddListener(OnBtnRetryClicked);
        btnHowToPlay.onClick.AddListener(OnBtnHowToPlayClicked);
    }

    private void OnEnable()
    {
        gameManager.OnPauseChanged += HandlePauseChanged;
    }

    private void OnDisable()
    {
        if(gameManager != null)
        gameManager.OnPauseChanged -= HandlePauseChanged;
    }

    private void Start()
    {
        panelPause.SetActive(false);
        panelSettings.SetActive(false);
        panelHowToPlay.SetActive(false);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnBtnContinueClicked();
        }
    }
    private void OnDestroy()
    {
        btnContinue.onClick.RemoveListener(OnBtnContinueClicked);
        btnSettings.onClick.RemoveListener(OnBtnSettingsClicked);
        btnMainMenu.onClick.RemoveListener(OnBtnMainMenuClicked);
        btnRetry.onClick.RemoveListener(OnBtnRetryClicked);
        btnHowToPlay.onClick.RemoveListener(OnBtnHowToPlayClicked);

    }

    private void OnBtnContinueClicked()
    {
        gameManager.SetPaused(!gameManager.IsPaused);
    }

    private void HandlePauseChanged(bool isPaused)
    {
        panelPause.SetActive(isPaused);
        if(!isPaused)
        {
            panelSettings.SetActive(false);
            panelHowToPlay.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnBtnSettingsClicked()
    {
        panelSettings.SetActive(true);
        panelPause.SetActive(false);
        panelHowToPlay.SetActive(false);
    }

    private void OnBtnMainMenuClicked()
    {
        gameManager.SetPaused(false);
        SceneManager.LoadScene("MainMenu");
    }
    private void OnBtnRetryClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }
    private void OnBtnHowToPlayClicked()
    {
        panelHowToPlay.SetActive(true);
        panelPause.SetActive(false);
        panelSettings.SetActive(false);
    }

}
