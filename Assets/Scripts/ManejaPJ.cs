using UnityEngine;
using System.Collections;

public class ManejaPJ : MonoBehaviour {

	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.4f;
	public LayerMask mascaraSuelo;

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
	}

}