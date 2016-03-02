using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed;
	private GameObject player;

	void Start(){
		player = GameObject.Find("Player");
	}

	void Update (){
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Player"){
			transform.LookAt(player.transform.position);
		}
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.name == "Player"){
			transform.LookAt(player.transform.position);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}

	void OnTriggerExit(Collider col){
		transform.Translate(0F, 0F, 0F);
	}

}
