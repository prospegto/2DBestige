using UnityEngine;
using System.Collections;

public class BotonSigLvl : MonoBehaviour {

	public string siguienteNivel = "MenuPrincipal";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CargarSiguienteNivel(){
		Application.LoadLevel(siguienteNivel);
	}
}
