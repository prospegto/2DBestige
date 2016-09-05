using UnityEngine;
using System.Collections;

public class FantasmaRepele : MonoBehaviour {

	private bool activado = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll){

		if(!activado){
			Vector3 subir = new Vector3(0, 0.3f, 0);
			gameObject.transform.position += subir;
		}

		activado = true;
		
			if(coll.gameObject.GetComponent<Rigidbody2D>() != null){
				if(coll.transform.tag == "ObjetoConstruccion"){
					Vector2 target = coll.gameObject.transform.position;
					Vector2 bomb = gameObject.transform.position;
					Vector2 direc = 30f * (target - bomb);
					coll.gameObject.GetComponent<Rigidbody2D>().AddForce(direc);
				}
			}
	}
}
