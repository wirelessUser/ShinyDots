using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class projectile : MonoBehaviour
{




    public int dots = 30;
    private Vector2 startPosition;
    private bool isClicking = false;
    public GameObject Dots;
    public List<GameObject> projectilesPath;

    void Start()
    {
        Dots = GameObject.Find("dots");
        startPosition = Vector2.zero;
        projectilesPath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);

        for (int i = 0; i < projectilesPath.Count; i++)
        {
            projectilesPath[i].GetComponent<Renderer>().enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicking = true;
            startPosition = Input.mousePosition;
            projectlePath(startPosition);
        }

        if (Input.GetMouseButton(0) && isClicking)
        {
            projectlePath(startPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClicking = false;
            HideProjectilePath();
        }
    }

    void projectlePath(Vector2 startPosition)
    {
        Vector2 velocity = (startPosition - (Vector2)Input.mousePosition);

        for (int i = 0; i < projectilesPath.Count; i++)
        {
            projectilesPath[i].GetComponent<SpriteRenderer>().enabled = true;

            float t = i / (float)dots;

            // Calculate the trajectory of projectile motion
            float g = Physics2D.gravity.y;
            Vector2 point = startPosition + velocity * t + 0.5f * new Vector2(1, g) * t * t;

            // Convert the point to world space
            point = Camera.main.ScreenToWorldPoint(point);

            projectilesPath[i].transform.position = point;
        }
    }


    void HideProjectilePath()
    {
        for (int i = 0; i < projectilesPath.Count; i++)
        {
            projectilesPath[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }




} // ShootScript






























































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
