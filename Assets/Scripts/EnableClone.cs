using UnityEngine;

public class EnableClone : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    public void EnableObject()
    {
        targetObject.SetActive(true);
    }
    public void DisableObject()
    {
        targetObject.SetActive(false);
    }
}
