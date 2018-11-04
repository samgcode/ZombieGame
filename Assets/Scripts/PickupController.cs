using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    public GameObject obj;
    public PlayerController player;

	private void Start() {
        switchActive();
    }


	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player") {
            obj.SetActive(false);
            switchActive();
        }
	} 

    private void switchActive() {
        if (obj.tag != player.guns[player.currentGun].gameObject.tag) {
            obj.SetActive(true);
        } else if (obj.tag == player.guns[player.currentGun].gameObject.tag) {
            obj.SetActive(false);
        }
    }
}
