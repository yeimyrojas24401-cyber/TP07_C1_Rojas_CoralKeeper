using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOverMenu : MonoBehaviour
{
    [SerializeField] private GameResultSo gameResultData;
    [SerializeField] private CoralProgressSo coralProgressData;
    [SerializeField] private LevelDataSo levelData;
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_Text fragments;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMain;

    [SerializeField] private Image panelBackground;
    [SerializeField] private Sprite winBackground;
    [SerializeField] private Sprite loseBackground;

    private void Start()
    {
        panelBackground.sprite = gameResultData.Won ? winBackground : loseBackground;
        fragments.text = $"Fragmentos: {coralProgressData.CollectedFragments}/{levelData.RequiredFragments}";
        btnRetry.onClick.AddListener(OnBtnRetryClicked);
        btnMain.onClick.AddListener(OnBtnMainClicked);
    }
    private void OnDestroy()
    {
        btnRetry.onClick.RemoveListener(OnBtnRetryClicked);
        btnMain.onClick.RemoveListener(OnBtnMainClicked);
    }

    private void OnBtnRetryClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnBtnMainClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
