using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Puntuacion : MonoBehaviour {

	public int puntuacion;
	public int objetosDestruidos;
	public Text textoPuntuacion;

	// Use this for initialization
	void Start () {
		puntuacion = 0;
	}
	
	// Update is called once per frame
	void Update () {
		textoPuntuacion.text = puntuacion + " puntos";
	}
	

	public void AumentarObjetosDestruidos(){
		objetosDestruidos++;
	}

	public void AumentarPuntuacion(int puntos){
		puntuacion += puntos;
	}


}
