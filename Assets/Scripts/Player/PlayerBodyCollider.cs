using UnityEngine;

public class PlayerBodyCollider : MonoBehaviour
{
    [SerializeField] private int points = 10;
    private void OnCollisionEnter(Collision collision) //To pause a wall
    {
        if (collision.gameObject.TryGetComponent<MovingWall>(out MovingWall wall))//Player Layer
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            wall.PauseMovement();
        }
        else if(collision.gameObject.GetComponentInParent<GameObject>().gameObject.TryGetComponent<MovingWall>(out MovingWall parentwall))
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            parentwall.PauseMovement();
        }
        else return;

    }
    private void OnCollisionExit(Collision collision) //To unpause a wall
    {
        if (collision.gameObject.TryGetComponent<MovingWall>(out MovingWall wall))//Player Layer
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            wall.ContinueMovement();
        }
        else if (collision.gameObject.GetComponentInParent<GameObject>().gameObject.TryGetComponent<MovingWall>(out MovingWall parentwall))
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            parentwall.ContinueMovement();
        }
        else return;
    }

    private void OnTriggerEnter(Collider pointsPlane)
    {
        if (pointsPlane.TryGetComponent<WallColliderz>(out WallColliderz wall))
            if (wall.gameObject.layer == 8 && wall.GetIsTouched() == false) // Point Layer
            {
                wall.ColliderIsTouched();
                PointHandler.instance.AddPoint(points);
            }
            else if (wall.gameObject.layer == 3 && wall.GetIsTouched() == false) // Wall Layer
            {
                wall.ColliderIsTouched();
                PointHandler.instance.MinusPoint(points / 2);
            }
            else return;
    }
}
