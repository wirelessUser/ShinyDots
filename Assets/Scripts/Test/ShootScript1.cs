//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//public class ShootScript1 : MonoBehaviour {

//	public float power = 2.0f;
//	public float life = 1.0f;
//	public float dead_sense = 25f;

//	public int dots = 30;

//	private Vector2 startPosition;
//	private bool shoot = false, isClicking = false, hit_ground = false;

////public GameObject Dots;
//	public GameObject[] Dots;
//	public List<GameObject> projectilesPath;

//	private Rigidbody2D myBody;
//	public Collider2D myCollider;

//	void Awake() {
//		myBody = GetComponent<Rigidbody2D> ();
//		myCollider = GetComponent<Collider2D> ();
//	}

//	void Start () {

//		//Dots = GameObject.FindGameObjectsWithTag ("Dot");

//		Dots = GameObject.FindGameObjectsWithTag("Dot");
//		myBody.isKinematic = true;
//		myCollider.enabled = false;
//		startPosition = transform.position;
//		//projectilesPath = Dots.transform.Cast<Transform> ().ToList().ConvertAll(t => t.gameObject);
//		projectilesPath = new List<GameObject>();
//       projectilesPath.AddRange(Dots);
        
//		//for (int i = 0; i < projectilesPath.Count; i++) {
//		////	projectilesPath[i].GetComponent<Renderer>().enabled = false;
//		//}
//	}

//	void Update () {
//		Aim ();

//		if (hit_ground) {
//			life -= Time.deltaTime;

//			Color c = GetComponent<Renderer>().material.GetColor("_Color");
//		GetComponent<Renderer>().material.SetColor("_Color", new Color(c.r, c.g, c.g, life));

//			if(life < 0) {

//				if(GameManager.instance != null) {
//					GameManager.instance.CreateBall();
//				}

//				Destroy(gameObject);
//			}

//		}

//	}

//	void Aim() {
//		if (shoot)
//			return;

//		if (Input.GetAxis ("Fire1") == 1) {
//			if (!isClicking) {
//				isClicking = true;
//				startPosition = Input.mousePosition;
//				projectlePath ();
//				//ShowPath ();
//			} else {
//				projectlePath ();
//			}
//		} else if (isClicking && !shoot) {
//			if(inDeadZone(Input.mousePosition) || inReleaseZone(Input.mousePosition)) {
//				isClicking = false;
//			//	HidePath();
//				return;
//			}
//			myBody.isKinematic = false;
//			myCollider.enabled = true;
//			shoot = true;
//			isClicking = false;
//			myBody.AddForce(GetForce(Input.mousePosition));
//			HidePath();
//			GameManager.instance.DecrementBalls();
//		}

//	}

//	Vector2 GetForce(Vector3 mouse) {
//		print("GetForce");
//		return (new Vector2(mouse.x, mouse.y)-new Vector2(startPosition.x, startPosition.y)) * power;


		
//	}

//	bool inDeadZone(Vector2 mouse) {

//		print("inDeadZone");
//		if (Mathf.Abs (startPosition.x - mouse.x) <= dead_sense && Mathf.Abs (startPosition.y - mouse.y) <= dead_sense) {
//			return true;
//		} else {
//			return false;
//		}

//	}

//	bool inReleaseZone(Vector2 mouse) {
//		print("inReleaseZone");
//		if (mouse.x <= 70) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	void projectlePath() {
//		Vector2 vel = GetForce (Input.mousePosition) /** Time.fixedDeltaTime / myBody.mass*/;
//		//print("projectlePath");
//		for (int i = 0; i < projectilesPath.Count; i++) {
//			projectilesPath[i].GetComponent<Renderer>().enabled = true;
//			float t = i / 30f;
//			Vector3 point = PathPoint(transform.position, vel, t);
//			point.z = 1.0f;
//			projectilesPath[i].transform.position = point;
//		}

//	}

//	Vector2 PathPoint(Vector2 startP, Vector2 startVel, float t) {
//		//print("PathPoint");
//		return startP + startVel * t + 0.5f * Physics2D.gravity * t * t;
//	}

//	void HidePath() {
//		//print("HidePath");
//		for (int i = 0; i < projectilesPath.Count; i++) {
//			projectilesPath[i].GetComponent<Renderer>().enabled = false;
//		}
//	}

//	void ShowPath() {
//		//print("ShowPath");
//		for (int i = 0; i < projectilesPath.Count; i++) {
//			projectilesPath[i].GetComponent<Renderer>().enabled = true;
//		}
//	}

//	void OnCollisionEnter2D(Collision2D target) {
//		//print("OnCollisionEnter2D");
//		if (target.gameObject.tag == "Ground") {
//			hit_ground = true;
//		}
//	}

//} // ShootScript




























































