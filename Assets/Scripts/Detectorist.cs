using System.Collections.Generic;
using UnityEngine;

public class Detectorist : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Animator DoorAnimator;
    [SerializeField] List<GameObject> entities;

    private void Start()
    {
        DoorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        entities.Add(other.gameObject);
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Opening Door");
            DoorAnimator.SetBool("IsOpen", true);
        }
    }
}
