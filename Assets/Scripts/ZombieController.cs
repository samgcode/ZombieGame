using UnityEngine;

public class ZombieController : MonoBehaviour {

    public PlayerController player;
    public float damage;

    private Rigidbody rb;
    public float speed;

    public float health = 2f;
    public float damageTaken;
    private bool isDamaging = false;

    private float timeToDamage;
    private float damageRate = 5f;

	void Start () {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("damagePlayer", 0.0f, 0.5f);
	}

	void FixedUpdate()
	{
            rb.velocity = (transform.forward * speed);
	}

	void Update () {
        transform.LookAt(player.transform.position);

        if(health <= 0) {
            Destroy(gameObject);
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player") {
            isDamaging = true;
            damagePlayer();
        }

	}

	private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            isDamaging = false;
        }
	}

	public void OnCollisionEnter(Collision other)
	{
        if(other.collider.tag == "bullet") {
            health -= damageTaken;
        }
	}

    public void damagePlayer() {
        if (isDamaging == true) {
            player.decreaseHealth(damage);
        } 
    }
}
