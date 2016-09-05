using UnityEngine;
using System.Collections;

public class ObjetoExplosivo : MonoBehaviour {

	private Animator animator;
	public float retardoExplo = 1f;
	public float ratioExplo = 1f;
	public float tamanoExplo = 5f;
	public float velocidadExplo = 1f;
	public CircleCollider2D radioExplo;
	public float radioActual = 0f;
	private bool explota = false;
	private bool activada = false;



	// Use this for initialization
	void Start () {
		animator.enabled = false;
	}

	void Awake(){
		animator = transform.GetComponent<Animator>();
		radioExplo = transform.GetComponent<CircleCollider2D>();
	}	

	
	// Update is called once per frame
	void Update () {
		if(activada){
			retardoExplo -= Time.deltaTime;
			if(retardoExplo <= 0){
				explota = true;
			}

		}
	}

	void FixedUpdate () {
		if(explota){
			if(radioActual < tamanoExplo){
				radioActual += ratioExplo;
			}
			radioExplo.radius = radioActual;
		}
	}

	
	void OnTriggerEnter2D(Collider2D coll){
		if(explota){
			if(coll.gameObject.GetComponent<Rigidbody2D>() != null){
				Vector2 target = coll.gameObject.transform.position;
				Vector2 bomb = gameObject.transform.position;
				Vector2 direc = 50f * (target - bomb);
				coll.gameObject.GetComponent<Rigidbody2D>().AddForce(direc);
				Destroy(gameObject);
			}
		}
	}


	void OnCollisionEnter2D(Collision2D collisionInfo){
		if(collisionInfo.transform.tag == "ObjetoConstruccion"){
			animator.enabled = true;
			if(animator!=null){
				activada = true;
				animator.SetTrigger("Explosion");
			}
		}
	}
}
