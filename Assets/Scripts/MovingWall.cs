using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Transform finalPos;
    [Header("Speed Vars")]
    [SerializeField] float speed = 2.5f;
    [SerializeField] float pauseDuration = 1.5f;
    [SerializeField] bool isPunchable = true;
    
    //Coroutine coroutineRef; //Used for stopping the couroutine loop 
    bool isPaused = false; //Bool if the object is moving OR is allowed to move
    public bool isPunched = false;

    private void Update()
    {
        if(!isPunched)
            if(!isPaused)
                LerpToPos();
    }

    private void LerpToPos()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos.position, speed * Time.deltaTime);
    }

    public void PauseMovement()
    {
        Debug.Log($"{gameObject.name} HAS PAUSED ITS MOVEMENT");
        isPaused = true;

        //StopCoroutine(coroutineRef);
        //coroutineRef = null;
    }

    public void ContinueMovement()
    {
        Debug.Log($"{gameObject.name} HAS PAUSED ITS MOVEMENT");
        isPaused = false;
        //coroutineRef = StartCoroutine(GoToTransformPos());
    }
    public float GetPauseTime() { return pauseDuration; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)//Player Layer
        {
            Debug.Log($"{gameObject.name} Is Collided with {collision.gameObject.name}");
            PauseMovement(); 
        }
        else return;
    }
}
