using UnityEngine;
using System.Collections;

public class PuntoFinal : MonoBehaviour {

	private Animator animator;
	public Canvas canvasFinal;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		animator = transform.parent.GetComponent<Animator>();
	}	
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D collisionInfo){
		if(collisionInfo.transform.tag == "Player"){
			if(animator!=null){
				animator.SetTrigger("Final");
			}
			Time.timeScale = 0;
			canvasFinal.gameObject.SetActive(true);
		}
	}
}
