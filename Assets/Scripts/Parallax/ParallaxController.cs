using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ParallaxLayer[] layers;
    private Vector3 cameraStartPosition;

    private void Start()
    {
        cameraStartPosition = cameraTransform.position;
        foreach(ParallaxLayer layer in layers)
        {
            layer.SaveStartPosition();
        }
    }
    private void LateUpdate()
    {
        Vector3 cameraDelta = cameraTransform.position - cameraStartPosition;   // lo que se movio la camara
        foreach (ParallaxLayer layer in layers)
        {
            layer.Apply(cameraDelta);                                          // cada capa se mueve su parte
        }
    }
}
