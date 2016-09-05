using UnityEngine;
using System.Collections;

public class ManejaClick : MonoBehaviour {

	public LineRenderer rastroPulsacion;
	Rigidbody2D objetoSinGravedad = null;
	SpringJoint2D springJoint = null;
	public bool usaLinea = false;
	public float velocidad = 4f;
	public Rigidbody2D pj;
	public float velocidadPj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Vector3 puntoMundo3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 puntoPulsado = new Vector2(puntoMundo3D.x, puntoMundo3D.y);
			Vector2 direccion = Vector2.zero;
			RaycastHit2D hit = Physics2D.Raycast(puntoPulsado, direccion);
			// Si pulsa algún collider
			if(hit.collider != null && hit.collider.tag != "Player"){
				if(hit.collider.GetComponent<Rigidbody2D>() != null){
					objetoSinGravedad = hit.collider.GetComponent<Rigidbody2D>();
					if(usaLinea){
						springJoint = objetoSinGravedad.gameObject.AddComponent<SpringJoint2D>();
						// hit.point es world
						Vector3 puntoLocal = objetoSinGravedad.transform.InverseTransformPoint(hit.point);
						springJoint.anchor = puntoLocal;
						// conectar lengua con pj
						// se queda activada
						if(objetoSinGravedad.tag == "RecogerObjeto"){
							springJoint.connectedAnchor = pj.transform.position;
						}else{
							springJoint.connectedAnchor = puntoMundo3D;
						}

						springJoint.enableCollision = true;
						springJoint.distance = 0.5f;
						springJoint.dampingRatio = 0.5f;
						springJoint.frequency = 1;
						// referencia del rigidbody2d a la articulación
						springJoint.connectedBody = null;
					}else{
						objetoSinGravedad.gravityScale = 0;
					}
					rastroPulsacion.enabled = true;
				}
			}else{
				// Movimiento PJ
				//pj.gravityScale = 0.6f;
				if(pj.GetComponent<ManejaPJ>().enSuelo){
					Vector2 posicion = new Vector2(pj.position.x, pj.position.y);
					Vector2 direccion2 = puntoPulsado - posicion;
					direccion2.Normalize();
					pj.velocity = direccion2 * velocidadPj;
				}

			}
		}


		// Soltar ratón y quitar rastro
		if(Input.GetMouseButtonUp(0) && objetoSinGravedad != null){
			if(usaLinea){
				Destroy(springJoint);
				springJoint = null;
			}else{
				objetoSinGravedad.gravityScale = 1;
			}
			objetoSinGravedad = null;
			rastroPulsacion.enabled = false;
		}

		// Camara en pj
		Camera.main.GetComponent<MoverCamara>().targetY = pj.position.y;
		Camera.main.GetComponent<MoverCamara>().targetX = pj.position.x;

	}

	void FixedUpdate(){
		if(objetoSinGravedad!=null){
			Vector2 puntoMundo2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(usaLinea){
				// Atraer objeto a pj
				if(objetoSinGravedad.tag == "RecogerObjeto"){
					springJoint.connectedAnchor = pj.transform.position;
				}else{
					springJoint.connectedAnchor = puntoMundo2D;
				}
			}else{
				objetoSinGravedad.velocity = (puntoMundo2D - objetoSinGravedad.position) * velocidad;
			}
		}
	}

	void LateUpdate(){
		if(objetoSinGravedad != null){
			if(usaLinea){
				// Se captura el punto exacto donde pulsa en el objeto
				Vector3 anchorPulsacion = objetoSinGravedad.transform.TransformPoint(springJoint.anchor);
				rastroPulsacion.SetPosition(0, new Vector3(anchorPulsacion.x, anchorPulsacion.y, -1));
				rastroPulsacion.SetPosition(1, new Vector3(springJoint.connectedAnchor.x, springJoint.connectedAnchor.y, -1));
			}else{
				// Se situa en el centro del objeto
				Vector3 puntoMundo3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				rastroPulsacion.SetPosition(0, new Vector3(objetoSinGravedad.position.x, objetoSinGravedad.position.y, -1));
				rastroPulsacion.SetPosition(1, new Vector3(puntoMundo3D.x, puntoMundo3D.y, -1));
			}
		}
	}
}
