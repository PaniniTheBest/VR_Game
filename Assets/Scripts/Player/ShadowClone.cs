using UnityEngine;

public class ShadowClone : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform mirror;
    private void OnEnable()
    {
        Debug.Log("Is enabled");
        GameManger.ApplyToUpdate += CloneMimic;
    }
    private void OnDisable()
    {
        Debug.Log("Is DIS enabled");
        GameManger.ApplyToUpdate -= CloneMimic;
    }
    private void CloneMimic()
    {
        Vector3 objectToFollow = mirror.InverseTransformPoint(player.position);
        transform.position = mirror.TransformPoint(new Vector3(objectToFollow.x, objectToFollow.y, -objectToFollow.z));
        transform.localRotation = player.rotation;
    }
}
