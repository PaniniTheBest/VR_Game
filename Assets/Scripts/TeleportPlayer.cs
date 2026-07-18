using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] string playerName = null;
    [SerializeField] WallSpawner wallSpawner;
    private void Awake()
    {
        if(playerName != null)
            player = GameObject.Find(playerName);
        else return;
    }
    public void TeleportToNewPos(Transform teleportPosition)
    {
        player.transform.position = teleportPosition.position;
    }
    public void StartTheWallSpawner()
    {
        GameManger.ApplyToUpdate += wallSpawner.EnableWave;
    }
}
