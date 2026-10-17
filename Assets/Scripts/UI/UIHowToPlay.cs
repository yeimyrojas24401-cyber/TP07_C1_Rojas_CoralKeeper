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
    [SerializeField] private GameObject returnPanel;

    private int currentPage;
    private void Awake()
    {
        btnNext.onClick.AddListener(OnBtnNextClicked);
        btnPrevious.onClick.AddListener(OnBtnPreviousClicked);
    }
    private void OnEnable()
    {
        ShowPage(0);
    }
    private void OnDestroy()
    {
        btnNext.onClick.RemoveListener(OnBtnNextClicked);
        btnPrevious.onClick.RemoveListener(OnBtnPreviousClicked);
    }
    private void ShowPage(int pageIndex)
    {
        currentPage = pageIndex;
        pageImage.sprite = pageSprites[currentPage];
    }
    private void CloseHowToPlay()
    {
        returnPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnBtnNextClicked()
    {
        if (currentPage == pageSprites.Length - 1)
        {
            CloseHowToPlay();
            return;
        }
        ShowPage(currentPage + 1);
    }
    private void OnBtnPreviousClicked()
    {
        if (currentPage == 0)
        {
            CloseHowToPlay();
            return;
        }
        ShowPage(currentPage - 1);
    }
}
