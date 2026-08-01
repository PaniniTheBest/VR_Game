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
        if (pointsPlane.gameObject.layer == 8) // Point Layer
            PointHandler.instance.AddPoint(points);
        else if (pointsPlane.gameObject.layer == 3) // Wall Layer
        {
            PointHandler.instance.MinusPoint(points / 2);
            Destroy(pointsPlane.gameObject);
        }
        else return;
    }
}
