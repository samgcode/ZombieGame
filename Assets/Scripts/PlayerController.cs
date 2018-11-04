using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Camera rayCamera;
    public Transform bullet;
    public GunController[] guns;
    public int currentGun = 0;
    private GunController gun;
    public float health = 20f;
    public float slowness;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 mVelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        guns[currentGun].gameObject.SetActive(true);
    
    }
	
	// Update is called once per frame
	void Update () {

        gun = guns[currentGun];

        if(health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        mVelocity = moveInput / slowness;

        //rotation
        Ray cameraRay = rayCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        if(Input.GetMouseButtonDown(0)) {

            gun.isFiring = true;
        }
        if(Input.GetMouseButtonUp(0)) {
            gun.isFiring = false;
        }
	}
	void FixedUpdate() {
        transform.position += mVelocity;
	}

    public void decreaseHealth(float factor) {
        health -= factor;
        //Debug.Log(health);
    }

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "handGun") {
            currentGun = 0;
            switchGuns();
        } else if(other.tag == "shotGun") {
            currentGun = 1;
            switchGuns();
        }
	}

	public void switchGuns() {
        for (int i = 0; i < guns.Length; i++) {
            if(i == currentGun) {
                guns[i].gameObject.SetActive(true);
            } else {
                guns[i].gameObject.SetActive(false);
            }
        }
    }
}
