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

    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelSettings;


    private void Awake()
    {
        btnContinue.onClick.AddListener(OnBtnContinueClicked);
        btnSettings.onClick.AddListener(OnBtnSettingsClicked);
        btnMainMenu.onClick.AddListener(OnBtnMainMenuClicked);
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
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnBtnSettingsClicked()
    {
        panelSettings.SetActive(true);
        panelPause.SetActive(false);
    }

    private void OnBtnMainMenuClicked()
    {
        gameManager.SetPaused(false);
        SceneManager.LoadScene("MainMenu");
    }

}
