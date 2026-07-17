using UnityEngine;

public class PlayerBodyCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<MovingWall>(out MovingWall wall))//Player Layer
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            wall.PauseMovement();
        }
        else return;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<MovingWall>(out MovingWall wall))//Player Layer
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            wall.ContinueMovement();
        }
        else return;
    }
}
