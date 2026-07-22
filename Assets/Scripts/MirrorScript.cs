using UnityEngine;
public class MirrorScript : MonoBehaviour
{
    //Do not Activate script, only works for smaller mirror
    [SerializeField] Transform playerPos;
    [SerializeField] Transform mirror;
    void Update()
    {
        Vector3 localPlayerpos = mirror.InverseTransformPoint(playerPos.position);
        transform.position = mirror.TransformPoint(new Vector3(localPlayerpos.x,localPlayerpos.y,-localPlayerpos.z));

        Vector3 mirrorLookAt =  mirror.TransformPoint(new Vector3(-localPlayerpos.x, localPlayerpos.y,localPlayerpos.z));
        transform.LookAt(mirrorLookAt);
    }
}
