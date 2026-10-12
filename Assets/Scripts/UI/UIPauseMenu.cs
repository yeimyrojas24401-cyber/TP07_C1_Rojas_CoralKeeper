using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnMainMenu;

    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelSettings;

    private bool isPause = false;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnBtnContinueClicked);
        btnSettings.onClick.AddListener(OnBtnSettingsClicked);
        btnMainMenu.onClick.AddListener(OnBtnMainMenuClicked);
    }


    private void Start()
    {
        Time.timeScale = 1f;
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
        isPause = !isPause;
        panelPause.SetActive(isPause);
        if(!isPause)
        {
            panelSettings.SetActive(false);
        }
        Time.timeScale = isPause ? 0f : 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnBtnSettingsClicked()
    {
        panelSettings.SetActive(true);
        panelPause.SetActive(false);
    }

    private void OnBtnMainMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
