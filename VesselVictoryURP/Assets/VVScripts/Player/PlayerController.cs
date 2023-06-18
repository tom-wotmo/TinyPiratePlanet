using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField]private float moveSpeed;
	[SerializeField]private float rotationSpeed;

	private float rotation;
	private Rigidbody rb;

	public static PlayerController Instance { get; private set; }
	private void Awake()
	{
		if (Instance == null)
		{ Instance = this; }
	}
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
	public float getPlayerControllerMoveSpeed() { return moveSpeed; }
	public void setPlayerControllerMoveSpeed(float i) { moveSpeed = i; }

}