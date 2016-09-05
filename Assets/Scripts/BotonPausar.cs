using UnityEngine;
using System.Collections;

public class BotonPausar : MonoBehaviour {

	public bool enPausa = false;

	// Use this for initialization
	void Start () {
		enPausa = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.P))
			enPausa = !enPausa;
	}

	public void BotonPausaPulsado(){
			enPausa = !enPausa;
	}
}
