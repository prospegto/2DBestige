using UnityEngine;
using System.Collections;

public class LanzaObjetos : MonoBehaviour {

	public GameObject[] objetos;
	public float tiempoEntreObjetos;
	public float proximoPunto = 1f;
	public float velocidadInicial = 8f;
	public BotonPausar botonPausar;
	public Puntuacion puntuacion;
	public ManejaPJ jugador;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if(!botonPausar.enPausa && jugador.enSuelo)
		proximoPunto -= Time.deltaTime;

		if(proximoPunto <= 0 && !botonPausar.enPausa){
			proximoPunto = tiempoEntreObjetos;

			GameObject mObj = Instantiate(objetos[Random.Range(0, objetos.Length)], transform.position, transform.rotation) as GameObject;
			mObj.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, velocidadInicial);
			puntuacion.AumentarPuntuacion(1);
		}
	}
}
