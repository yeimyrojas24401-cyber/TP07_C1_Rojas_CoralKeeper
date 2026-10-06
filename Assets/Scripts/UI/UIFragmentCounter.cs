using TMPro;
using UnityEngine;
public class UIFragmentCounter : MonoBehaviour
{
    [SerializeField] private LevelDataSo levelData;
    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private GameObject[] fragmentIcons;

    private void Start()
    {
        Refresh(coralProgress.CollectedFragments);
    }
    private void OnEnable()
    {
        coralProgress.OnFragmentsChanged += Refresh;
    }

    private void OnDisable()
    {
        coralProgress.OnFragmentsChanged -= Refresh;
    }
    private void Refresh(int collected)
    {
        for (int i = 0; i < fragmentIcons.Length; i++)
        {
            fragmentIcons[i].SetActive(i < collected);
        }
        counterText.text = $"{collected}/{levelData.RequiredFragments}";
    }
}
