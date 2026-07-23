using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Transform finalPos;
    [Header("Speed Vars")]
    [SerializeField] float speed = 0.25f;
    [SerializeField] float durationTime = 10f;
    [SerializeField] bool isPunchable = true;
    
    //Coroutine coroutineRef; //Used for stopping the couroutine loop 
    bool isPaused = false; //Bool if the object is moving OR is allowed to move
    public bool isPunched = false;

    private void Update()
    {
        if(!isPunched && !isPaused)
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
    public float GetDurationTime() { return durationTime; }
}
