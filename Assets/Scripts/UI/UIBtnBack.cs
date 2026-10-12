using UnityEngine;
using UnityEngine.UI;

public class UIBtnBack : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject backPanel;

    private void Awake()
    {
        btnBack.onClick.AddListener(OnBtnBackClicked);
    }
    private void OnDestroy()
    {
        btnBack.onClick.RemoveListener(OnBtnBackClicked);
    }

    private void OnBtnBackClicked()
    {
        currentPanel.SetActive(false);
        backPanel.SetActive(true);
    }
}
