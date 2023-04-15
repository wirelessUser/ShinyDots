using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallShoot : MonoBehaviour
{
    public Rigidbody2D myBody;

    public float forceX ;
    public float forceY ;


    public bool Clicking =true;

    // Extra....................................
    public float power = 2.0f;
    public Vector2 startPosition;
    Vector2 forces = Vector2.zero;

    public GameObject prefab;
   public Vector2 pos;

    public JumpButton jumpObj;
    private void Awake()
    {


        Debug.Log("Input.mousePosition.x>>" + Input.mousePosition.x + "Input.mousePosition.y>>" + Input.mousePosition.y);
        startPosition = Input.mousePosition;

    }
    private void Start()
    {

    }
    private void LateUpdate()
    {
      
    }

   
    private void Update()
    {
        
        
        ClickingToJump();
        GetForce(Input.mousePosition);
      
    }
    

    Vector2 GetForce(Vector3 mouse)
    {


        
        forces = ((new Vector2(startPosition.x, startPosition.y)) - new Vector2(mouse.x, mouse.y));

        Debug.Log("startPosition.x>>" + startPosition.x + "startPosition.x>>" + startPosition.y);
        Debug.Log("Input.mousePosition.x>>" + Input.mousePosition.x + "Input.mousePosition.y>>" + Input.mousePosition.y);
        print("GetForce>>>" + " " + forces.x + ">>" + forces.y);
        return forces;

    }

    public Vector2 ClickingToJump()
    {

      return  GetForce(Input.mousePosition);
       
    }


    public void clickJumping(bool _Clicking)
    {
        this.Clicking = _Clicking;
     
        if (Clicking==false)
        {
            //Debug.Log("startPosition.x>>" + startPosition.x + "startPosition.x>>" + startPosition.y);
            //Debug.Log("Input.mousePosition.x>>" + Input.mousePosition.x + "Input.mousePosition.y>>" + Input.mousePosition.y);
            //print("GetForce>>>" + " " + forces.x + ">>" + forces.y);
            Jump();
           
        }

    }

    public void Jump()
    {
       
        myBody.AddForce(new Vector2(ClickingToJump().x, ClickingToJump().y));
        forceX = forceY = 0;
    }

}
