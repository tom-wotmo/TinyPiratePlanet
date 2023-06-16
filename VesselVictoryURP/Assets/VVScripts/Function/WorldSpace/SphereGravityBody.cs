using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereGravityBody : MonoBehaviour
{
    
    [SerializeField] private bool placeOnSurface = false;

    private SphereGravity attractor;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attractor = SphereGravity.Instance;
    }

    private void FixedUpdate()
    {
        if (placeOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb);
    }

}
