using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Transform finalPos;
    [Header("Speed Vars")]
    [SerializeField] float speed = 0.25f;
    [SerializeField] float durationTime = 10f;
    [SerializeField] bool isPunchable = true;
    [SerializeField] float destroyTime = 2.0f;
    
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

    public IEnumerator PauseMovement()
    {
        Debug.Log($"{gameObject.name} HAS PAUSED ITS MOVEMENT");
        isPaused = true;
        yield return null;
    }

    public void ContinueMovement()
    {
        Debug.Log($"{gameObject.name} HAS PAUSED ITS MOVEMENT");
        isPaused = false;
        //coroutineRef = StartCoroutine(GoToTransformPos());
    }
    public IEnumerator DestroyObjTimely()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
    public float GetDurationTime() { return durationTime; }
    public bool GetIsPunchable() { return isPunchable; }
}
