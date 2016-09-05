using UnityEngine;
using System.Collections;

public class IniciarVelocidadObj : MonoBehaviour {


	public Vector3 velocidadInicial;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = velocidadInicial;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
