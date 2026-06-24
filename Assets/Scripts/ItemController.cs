using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		GetComponent<Rigidbody>().isKinematic = true;
	}
}
