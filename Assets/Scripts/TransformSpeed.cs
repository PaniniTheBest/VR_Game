using System.Collections;
using UnityEngine;

public class TransformSpeed : MonoBehaviour
{
    [SerializeField] float timePerCheck = 0.1f;
    Vector3 previousPos;
    float speed;
    void Start()
    {
        StartCoroutine(PerSecond());
    }

    IEnumerator PerSecond()
    {
        previousPos = transform.position;
        yield return new WaitForSeconds(timePerCheck);
        yield return speed = Vector3.Distance(transform.position, previousPos);
        Debug.Log(speed);
        StartCoroutine(PerSecond());
    }
    public float GetSpeed() { return speed; }
}
