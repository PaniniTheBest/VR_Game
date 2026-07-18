using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static System.Action ApplyToUpdate;
    void Update()
    {
        ApplyToUpdate?.Invoke();
    }
}
