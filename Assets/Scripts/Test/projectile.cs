using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class projectile : MonoBehaviour
{




	public Vector2 startPos;
	public Vector2 mousePos;

	public int dots = 30;

	private Vector2 startPosition;
	private bool isClicking = false;

	public GameObject Dots;
	public List<GameObject> projectilesPath;

	
	

	void Start()
	{
		startPos = Vector2.zero;
		Dots = GameObject.Find("dots");
	
		startPosition = transform.position;
		projectilesPath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
		for (int i = 0; i < projectilesPath.Count; i++)
		{
			projectilesPath[i].GetComponent<Renderer>().enabled = false;
		}
	}

	void Update()
	{
		
		mousePos = Input.mousePosition;
		
		if (Input.GetAxis("Fire1") == 1)
		{
		
			if (!isClicking)
			{
				isClicking = true;
                startPosition = Input.mousePosition;
				Debug.Log("startPosition>>" + startPosition);
                projectlePath(startPosition);

			}
			else
			{
				projectlePath(startPosition);
			}
		}
		

	}// End  Update.........

   



	void projectlePath(Vector2 startPosition)
	{
	
		Vector2 velocity =  (startPosition- mousePos) ;

		for (int i = 0; i < projectilesPath.Count; i++)
		{
			projectilesPath[i].GetComponent<Renderer>().enabled = true;

			float t = i;

// Postion = startPosition(which is Mouse Position) + vecloty(which is diffrence of start&endPos*t (points indexers in loop) +  0.5f*g*sqaure of t(points indexers in loop) 

	Vector2 point = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + ( velocity.normalized  *t) + ( 0.5f*Physics2D.gravity* t * t);

			

			projectilesPath[i].transform.position = point;
		}

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
