using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField]private float moveSpeed = 10f;
	[SerializeField]private float rotationSpeed = 10f;

	private float rotation;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		rotation = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
	
	}

}