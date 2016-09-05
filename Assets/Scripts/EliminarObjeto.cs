using UnityEngine;
using System.Collections;

public class EliminarObjeto : MonoBehaviour {

	bool tocado = false;
	public Puntuacion puntuacion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D objeto){
		//tocado = true;
		if(objeto.gameObject.tag != "Player"){
			puntuacion.AumentarObjetosDestruidos();
			Destroy(objeto.gameObject);
		}else{
			tocado = true;
		}
	}

	void OnGUI(){
		if(tocado){
			Time.timeScale = 0;
			GUI.color = Color.black;
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "OUCH");
			if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25 + 55, 100, 50), "Reiniciar")){
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale = 1;
			}
		}
	}
}
