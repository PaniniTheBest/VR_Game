using System.Collections;
using UnityEngine;

public class MovingPosList : MonoBehaviour
{
    [SerializeField] Transform[] transformPosition = new Transform[2];
    int index = 0; //index for transformPosition
    Vector3 nextPos;
    [Header("Speed Vars")]
    [SerializeField] float speed = 2.5f;
    [SerializeField] float pauseDuration = 1.5f;
    
    Coroutine coroutineRef; //Used for stopping the couroutine loop 
    bool isPaused = false; //Bool if the object is moving OR is allowed to move

    private void Start()
    {
        nextPos = transformPosition[index % transformPosition.Length].position; //Next postition to move
        coroutineRef = StartCoroutine(GoToTransformPos());
    }
    private void Update()
    {
        if(!isPaused)
            LerpToPos();
    }
    IEnumerator GoToTransformPos()
    {
        //Debug.Log(index % transformPosition.Length);
        nextPos = transformPosition[index % transformPosition.Length].position;
        index++;
        yield return new WaitForSeconds(pauseDuration + (speed * Time.deltaTime));//Pause time
        coroutineRef = StartCoroutine(GoToTransformPos());
    }
    private void LerpToPos()
    {
        transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
    }

    public void PauseMovement()
    {
        Debug.Log($"{gameObject.name} HAS PAUSED ITS MOVEMENT");
        isPaused = true;

        StopCoroutine(coroutineRef);
        coroutineRef = null;
    }

    public void ContinueMovement()
    {
        Debug.Log($"{gameObject.name} HAS PAUSED ITS MOVEMENT");
        isPaused = false;
        coroutineRef = StartCoroutine(GoToTransformPos());
    }

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
