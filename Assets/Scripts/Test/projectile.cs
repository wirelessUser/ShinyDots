using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class projectile : MonoBehaviour
{

	#region Old Code


	//    public Vector2 startPos;
	//	public Vector2 mousePos;

	//	public int dots = 30;

	//	private Vector2 startPosition;
	//	private bool isClicking = false;

	//	public GameObject Dots;
	//	public List<GameObject> projectilesPath;




	//	void Start()
	//	{
	//		startPos = Vector2.zero;
	//		Dots = GameObject.Find("dots");

	//		startPosition = transform.position;
	//		projectilesPath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
	//		for (int i = 0; i < projectilesPath.Count; i++)
	//		{
	//			projectilesPath[i].GetComponent<Renderer>().enabled = false;
	//		}
	//	}

	//	void Update()
	//	{

	//		mousePos = Input.mousePosition;

	//		if (Input.GetAxis("Fire1") == 1)
	//		{

	//			if (!isClicking)
	//			{
	//				isClicking = true;
	//                startPosition = Input.mousePosition;
	//				Debug.Log("startPosition>>" + startPosition);
	//                projectlePath(startPosition);

	//			}
	//			else
	//			{
	//				projectlePath(startPosition);
	//			}
	//		}


	//	}// End  Update.........





	//	void projectlePath(Vector2 startPosition)
	//	{

	//		Vector2 velocity =  (startPosition- mousePos) ;

	//		for (int i = 0; i < projectilesPath.Count; i++)
	//		{
	//			projectilesPath[i].GetComponent<Renderer>().enabled = true;

	//			float t = i/40;

	//// Postion = startPosition(which is Mouse Position) + vecloty(which is diffrence of start&endPos*t (points indexers in loop) +  0.5f*g*sqaure of t(points indexers in loop) 

	//	Vector2 point = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + ( velocity  *t) + ( 0.5f*Physics2D.gravity* t * t);

	//			//Vector2 point = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + (velocity.normalized * t) + (0.5f * Physics2D.gravity * t * t);

	//			projectilesPath[i].transform.position = point;
	//		}

	//	}


	#endregion


	public float power = 2.0f;
	public float life = 1.0f;
	public float dead_sense = 25f;

	public int dots = 30;

	private Vector2 startPosition;
	private bool shoot = false, aiming = false, hit_ground = false;

	private GameObject Dots;
	private List<GameObject> projectilesPath;

	private Rigidbody2D myBody;
	private Collider2D myCollider;

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D>();
	}

	void Start()
	{

		Dots = GameObject.Find("dots");
		myBody.isKinematic = true;
		myCollider.enabled = false;
		startPosition = transform.position;
		projectilesPath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
		for (int i = 0; i < projectilesPath.Count; i++)
		{
			projectilesPath[i].GetComponent<Renderer>().enabled = false;
		}
	}

	void Update()
	{
		Aim();

		if (hit_ground)
		{
			life -= Time.deltaTime;

			Color c = GetComponent<Renderer>().material.GetColor("_Color");
			GetComponent<Renderer>().material.SetColor("_Color", new Color(c.r, c.g, c.g, life));

			if (life < 0)
			{

				if (GameManager.instance != null)
				{
					GameManager.instance.CreateBall();
				}

				Destroy(gameObject);
			}

		}

	}

	void Aim()
	{
		if (shoot)
			return;

		if (Input.GetAxis("Fire1") == 1)
		{
			if (!aiming)
			{
				aiming = true;
				startPosition = Input.mousePosition;
				CalculatePath();
				
			}
			else
			{
				CalculatePath();
			}
		}
		else if (aiming && !shoot)
		{
			if (inDeadZone(Input.mousePosition) || inReleaseZone(Input.mousePosition))
			{
				aiming = false;
				
				return;
			}
			myBody.isKinematic = false;
			myCollider.enabled = true;
			shoot = true;
			aiming = false;
			myBody.AddForce(GetForce(Input.mousePosition));
			
			GameManager.instance.DecrementBalls();
		}

	}

	Vector2 GetForce(Vector3 mouse)
	{
		return (new Vector2(startPosition.x, startPosition.y) - new Vector2(mouse.x, mouse.y)) * power;
	}

	bool inDeadZone(Vector2 mouse)
	{
		if (Mathf.Abs(startPosition.x - mouse.x) <= dead_sense && Mathf.Abs(startPosition.y - mouse.y) <= dead_sense)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool inReleaseZone(Vector2 mouse)
	{
		if (mouse.x <= 70)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void CalculatePath()
	{
		Vector2 vel = GetForce(Input.mousePosition) * Time.fixedDeltaTime / myBody.mass;

		for (int i = 0; i < projectilesPath.Count; i++)
		{
			projectilesPath[i].GetComponent<Renderer>().enabled = true;
			float t = i / 30f;
			Vector3 point = PathPoint(transform.position, vel, t);
			point.z = 1.0f;
			projectilesPath[i].transform.position = point;
		}

	}

	Vector2 PathPoint(Vector2 startP, Vector2 startVel, float t)
	{
		return startP + startVel * t + 0.5f * Physics2D.gravity * t * t;
	}

	
} // ShootScript













//here i am calcutain the projectile motin and it's working perfctely but i have some doubt >>>>> becuase in projectie motion i am using number of circles to make a proejctile path  by placing them one after another
//>>>> to calcute vbelocty i have used the differnce initial positon of mouse and and last dragged position
//But in the formula instead of time t the index numbers of the circles have been used , So i am confused why the index number used ?
















































#region Old Code.........

//public Vector2 startPos;
//public Vector2 endPos;

//public GameObject[] pointsArray;
//public GameObject pointPrefab;
//public Vector2 direction;

//public Transform shotPoint;
//public GameObject ArrowPrefab;
//public float launchForce;
//public int numerPoint;
//private void Awake()
//{
//    pointsArray = new GameObject[numerPoint];

//    for (int i = 0; i < numerPoint; i++)
//    {
//        pointsArray[i] = Instantiate(pointPrefab, shotPoint.position, Quaternion.identity);
//    }

//}


//private void Update()
//{
//    startPos = transform.position;
//    endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//    Vector2 direction = endPos - startPos;

//    transform.right = direction;



//    for (int i = 0; i < pointsArray.Length; i++)
//    {
//        pointsArray[i].transform.position = PointPosition(i*0.025f);
//        pointsArray[i].transform.right = direction;
//        Debug.Log("Calling For loop>>");
//    }
//}

//private void Shoot()
//{
//    GameObject newArrow = Instantiate(ArrowPrefab, shotPoint.position, shotPoint.rotation);
//    newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

//}

//public Vector2 PointPosition(float time)
//{
//    Vector2 pointPrefabPos = (Vector2)shotPoint.position + (direction.normalized * launchForce * time) + 0.5f * Physics2D.gravity * time * time * 1f;
//    Debug.Log("pointPrefab>>" + pointPrefabPos);
//    return pointPrefabPos;
//}



#endregion





//}// edn class 
