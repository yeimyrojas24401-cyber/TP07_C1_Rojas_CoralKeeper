using UnityEngine;
using UnityEngine.UI;

public class UIHowToPlay : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] private Image pageImage;
    [SerializeField] private Sprite[] pageSprites;

    [Header("Buttons")]
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnPrevious;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;

    private int currentPage;
    private void Awake()
    {
        btnNext.onClick.AddListener(OnBtnNextAction);
        btnPrevious.onClick.AddListener(OnBtnPreviousAction);
    }
    private void OnEnable()
    {
        ShowPage(0);
    }
    private void OnDestroy()
    {
        btnNext.onClick.RemoveListener(OnBtnNextAction);
        btnPrevious.onClick.RemoveListener(OnBtnPreviousAction);
    }
    private void ShowPage(int pageIndex)
    {
        currentPage = pageIndex;
        pageImage.sprite = pageSprites[currentPage];
    }
    private void CloseHowToPlay()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnBtnNextAction()
    {
        if (currentPage == pageSprites.Length - 1)
        {
            CloseHowToPlay();
            return;
        }
        ShowPage(currentPage + 1);
    }
    private void OnBtnPreviousAction()
    {
        if (currentPage == 0)
        {
            CloseHowToPlay();
            return;
        }
        ShowPage(currentPage - 1);
    }
}
