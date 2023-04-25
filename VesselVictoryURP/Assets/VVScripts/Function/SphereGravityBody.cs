using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereGravityBody : MonoBehaviour
{
    private SphereGravity attractor;
    private Rigidbody rb;

    public bool placeOnSurface = false;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attractor = SphereGravity.instance;
    }

    private void FixedUpdate()
    {
        if (placeOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb);
    }


}
