using UnityEngine;

public class WallColliderz : MonoBehaviour
{
    [SerializeField] bool isTouched;
    MovingWall mainWall;

    private void Awake()
    {
        if(mainWall == null)
        mainWall = gameObject.GetComponentInParent<MovingWall>();
        else return;
    }
    public void ColliderIsTouched()
    {
        isTouched  = true;
    }
    public bool GetIsTouched() { return isTouched; }


}
