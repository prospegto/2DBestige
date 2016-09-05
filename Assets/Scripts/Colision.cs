using UnityEngine;
using System.Collections;

public class Colision : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Cuando coloco el objeto que acaba de salir colindante a otro
	// no seguir a pj con camara 
	// seguir objetos
	void OnCollisionEnter2D(Collision2D collisionInfo){
		Vector3 posicionCamara = Camera.main.transform.position;
		if(posicionCamara.y < transform.position.y){
			Camera.main.GetComponent<MoverCamara>().targetY = transform.position.y;
		}/*else{
			Camera.main.GetComponent<MoverCamara>().targetY = 0;
		}*/

		if(collisionInfo.collider.tag == "Player" && gameObject.tag == "RecogerObjeto"){
			Destroy(gameObject);

		}
	}
}
