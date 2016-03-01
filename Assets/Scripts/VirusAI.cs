using UnityEngine;
using System.Collections;
using System;

public class VirusAI : MonoBehaviour {
	//Private Variables
	private Vector3 waypoint;						//Stores Waypoint for patrolling AI
	private Vector3 pos;								//Stores current Position;
	private Vector3 wpOffset;
	private Vector3 playerOffset;
	private System.Random rng;
	private float elapsedTime;

	//Public Variables
	public float speed;									//Virus' speed
	public Transform player;						//Used to access player and their position
	public float proxDistance;					//Distance in which two objects are considered "close"
	public float updateTime;
	private int rangeZ;

	void Start(){
		rng = new System.Random((int)DateTime.Now.Ticks);
		pos = transform.position;
		elapsedTime = 0;
	}

	void Update(){
		patrol();
	}

	void patrol(){
		pos = transform.position;
		wpOffset = waypoint - transform.position;

		if(Time.time > elapsedTime){
			elapsedTime += updateTime;
			updateWaypoint();
		}

		transform.LookAt(waypoint);
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		if (pos.x > 15 || pos.x < -15 || pos.z > 15 || pos.z < -15){
			updateWaypoint();
		} else if (wpOffset.sqrMagnitude < proxDistance * proxDistance){
      updateWaypoint();
		}
	}

	void chase(){
		transform.LookAt(player);
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void updateWaypoint(){
		waypoint.x = rng.Next(-35, 35);
		waypoint.y = 1.0F;
		rangeZ = Math.Abs((int)waypoint.x);
		waypoint.z = rng.Next(-rangeZ, rangeZ);

		transform.LookAt(waypoint);
	}
}
