using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportBack : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] string name = "[Player BackRooms] XR Origin (XR Rig)";
    private void OnCollisionEnter(Collision collision)
    {
        int index = Random.Range(0, transforms.Length - 1);

        if (collision.gameObject != null)
        {
            GameObject player = GameObject.Find(name.Trim());
            player.transform.position = transforms[index].position;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        int index = Random.Range(0, transforms.Length - 1);

        if (collision.gameObject != null)
        {
            GameObject player = GameObject.Find(name.Trim());
            player.transform.position = transforms[index].position;
        }
    }
}
