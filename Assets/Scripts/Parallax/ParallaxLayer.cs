using UnityEngine;
[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform layer;
    [SerializeField, Range(0f, 1f)] private float followFactor;
    private Vector3 startPosition;
    public void SaveStartPosition()
    {
        startPosition = layer.position;
    }
    public void Apply(Vector3 cameraDelta)
    {
        Vector3 offset = cameraDelta * followFactor;
        layer.position = new Vector3(startPosition.x + offset.x, startPosition.y + offset.y, startPosition.z);
    }
}
