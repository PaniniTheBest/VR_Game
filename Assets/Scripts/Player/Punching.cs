using UnityEngine;

public class Punching : TransformSpeed
{
    [SerializeField] float speedThreshold = 2.0f;
    [SerializeField] float knocbackStrength = 5.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (GetSpeed() >= speedThreshold)//If in a certain speed, Activate script           
            if (collision.transform.TryGetComponent<MovingWall>(out MovingWall wall)) //Can only interact with "MovingWall Scripts"
            {
                wall.isPunched = true;
                //=======================================//
                //          Script by : Uniykiv
                //https://discussions.unity.com/t/object-knockback/1690979/3
                Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = collision.transform.position - transform.position;
                    //direction.y = 0;
                    rb.AddForce(direction.normalized * knocbackStrength, ForceMode.Impulse);
                }
                //=======================================//
            }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (GetSpeed() >= speedThreshold)//If in a certain speed, Activate script                 
            if (collision.transform.parent.TryGetComponent<MovingWall>(out MovingWall wall) && wall.GetIsPunchable()) //Can only interact with "MovingWall Scripts"
            {
                //=======================================//
                //          Script by : Uniykiv
                //https://discussions.unity.com/t/object-knockback/1690979/3
                Rigidbody rb = collision.GetComponent<Rigidbody>();
                if (rb != null && !wall.isPunched)
                {
                    wall.isPunched = true;
                    Vector3 direction = collision.transform.position - transform.position;
                    //direction.y = 0;
                    rb.AddForce(direction.normalized * knocbackStrength, ForceMode.Impulse);
                    StartCoroutine(wall.DestroyObjTimely());
                }
                //=======================================//
            }       
    }
}
