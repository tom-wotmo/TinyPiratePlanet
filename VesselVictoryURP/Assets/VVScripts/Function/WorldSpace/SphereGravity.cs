using UnityEngine;

public class SphereGravity : MonoBehaviour
{
    [SerializeField] private float gravity = -10f;

    private SphereCollider col;

    public static SphereGravity Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        col = GetComponent<SphereCollider>();
    }
    public void Attract(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;

        body.AddForce(gravityUp * gravity);

        RotateBody(body);
    }
    public void PlaceOnSurface(Rigidbody body)
    {
        body.MovePosition((body.position - transform.position).normalized * (transform.localScale.x * col.radius));

        RotateBody(body);
    }
    void RotateBody(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;

        body.MoveRotation(Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime));
    }
   
    
}
