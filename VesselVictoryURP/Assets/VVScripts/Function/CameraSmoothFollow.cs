using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
	[SerializeField]private Transform target;
	[SerializeField]private float smoothness = 1f;
	[SerializeField]private float rotationSmoothness = .1f;
	[SerializeField]private Vector3 offset;

	private Vector3 velocity = Vector3.zero;
	void FixedUpdate()
	{
		if (target == null)
		{
			return;
		}
		Vector3 newPos = target.TransformDirection(offset);
		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothness);
		Quaternion targetRot = Quaternion.LookRotation(-transform.position.normalized, target.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationSmoothness);
	}
}