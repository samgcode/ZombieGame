using UnityEngine;

public class FallApart : MonoBehaviour
{

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
	}

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player") {
            rb.isKinematic = false;
        }
	}
}
