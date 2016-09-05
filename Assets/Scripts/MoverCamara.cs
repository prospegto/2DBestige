using UnityEngine;
using System.Collections;

public class MoverCamara : MonoBehaviour {

	public float targetY = 0;
	public float targetX = 0;
	//public Rigidbody2D pj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posicion = transform.position;
		posicion.y = Mathf.Lerp(transform.position.y, targetY, 1 * Time.deltaTime);
		posicion.x = Mathf.Lerp(transform.position.x, targetX, 1 * Time.deltaTime);
		transform.position = posicion;

		// seguir a pj
		//transform.position = new Vector3(pj.position.x+6,0,-10);//you can  adjust the numbers as you need. 
	}
}
