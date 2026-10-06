using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "CoralProgressData", menuName = "Data/Game/CoralProgressData")]
public class CoralProgressSo : ScriptableObject
{
    [SerializeField] private int collectedFragments;
    public int CollectedFragments => collectedFragments;

    public event UnityAction<int> OnFragmentsChanged;

    public void AddFragment()
    {
        collectedFragments++;
        OnFragmentsChanged?.Invoke(CollectedFragments);
    }
    public void ResetProgress()
    {
        collectedFragments = 0;
        OnFragmentsChanged?.Invoke(CollectedFragments);
    }
}
