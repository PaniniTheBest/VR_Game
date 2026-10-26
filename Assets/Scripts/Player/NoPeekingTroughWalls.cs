using UnityEngine;

public class NoPeekingTroughWalls : MonoBehaviour
{
    [SerializeField] LayerMask collideLayers;
    [SerializeField] float fadeSpeed = 6;
    [SerializeField] float sphereCheckSize = 0.15f;

    [SerializeField] Material cameraMaterial;
    [SerializeField] Color gizmoColor;
    private bool isCameraFadingOut = false;

    private void Awake()
    {
        cameraMaterial = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        if(Physics.CheckSphere(transform.position, sphereCheckSize, collideLayers ,QueryTriggerInteraction.Ignore)) //Head/Camera Collider
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
        cameraMaterial.SetFloat("_AlphaValue", fadeValue);

        if(fadeValue <= 0.01f)
            isCameraFadingOut = false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, sphereCheckSize);
    }
}
