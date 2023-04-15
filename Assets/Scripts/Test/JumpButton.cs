using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public  class JumpButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public BallShoot ballshoot;
  
    private void Awake()
    {
      
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        print("OnPointerClick");
       
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      
        ballshoot.clickJumping(true);
        ballshoot.myBody.isKinematic = true;

      
       print("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ballshoot.myBody.isKinematic = false;
        ballshoot.clickJumping(false);
        //forceX = 0;
        //forceY = 0;
        print("OnPointerUp");
    }
}
