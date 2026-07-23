using UnityEngine;

public class GameManger : MonoBehaviour
{
    GameManger instance;
    public static System.Action ApplyToUpdate;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        ApplyToUpdate?.Invoke();
    }
}
