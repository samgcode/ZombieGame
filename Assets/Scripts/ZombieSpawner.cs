using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public Transform[] spawnpoints;
    private float timeToSpawn;
    public float spawnRate = 5f;
    public ZombieController zombie;
    public float speed;
    public PlayerController player;

	void Update() {
        if (Time.time >= timeToSpawn)
        {
            spawnZombies(2);
            timeToSpawn = Time.time + spawnRate;
        }
	}

    public void spawnZombies(int amount) {
        for (int i = 0; i < amount; i++) {
            int randomNumber = Random.Range(0, spawnpoints.Length);
            ZombieController newZombie = Instantiate(zombie, spawnpoints[randomNumber].position, Quaternion.identity);
            newZombie.speed = speed;
            newZombie.player = player;
        }
    }
}
