using UnityEngine;

public class NoPeekingTroughWalls : MonoBehaviour
{
    [SerializeField] LayerMask collideLayers;
    [SerializeField] float fadeSpeed = 6;
    [SerializeField] float sphereCheckSize = 0.15f;

    private Material cameraMaterial;
    private bool isCameraFadingOut = false;

    private void Awake()
    {
        cameraMaterial = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        if(Physics.CheckSphere(transform.position, sphereCheckSize,collideLayers,QueryTriggerInteraction.Ignore)) //Head/Camera Collider
        {
            CameraFade(1f);
            isCameraFadingOut = true;
        }
        else
        {
            if(!isCameraFadingOut) return;

            CameraFade(0f);
        }
    }
    private void CameraFade(float targetAlpha)
    {
        var fadeValue = Mathf.MoveTowards(cameraMaterial.GetFloat("_AlphaValue"), targetAlpha, Time.deltaTime * fadeSpeed);
        isCameraFadingOut = false;

    }
}
