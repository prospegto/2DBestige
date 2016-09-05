using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D collisionInfo){
		if(collisionInfo.transform.tag == "Player"){
			Destroy(collisionInfo.transform.gameObject);
		}
	}
}
