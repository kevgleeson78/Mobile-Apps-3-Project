using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

//Adapted From https://www.youtube.com/watch?v=6kGxSS66Ba8
//Implement interfaces for drag pressed and unpressed functionallity..
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //The images to hold the outer and inner portions of the joystick
    private Image bgImg;
    private Image joystickImg;
    // Get and set the direction of the joystick being dragged.
    public Vector2 Inputdirection {set; get;}
    private void Start()
    {   //Get A handle on the outer image
        bgImg = GetComponent<Image>();
        //Get handle on the inner joystick image child of the outer image.
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        //Reset the value of the input to zero
        Inputdirection = Vector2.zero;
    }
    //On drag functionallity from the IDgragHandler interface.
    public void OnDrag(PointerEventData ped)
    {
        // Variable to hold the positon of the joystick when dragged
        Vector2 pos = Vector2.zero;
        /*
         *Condition to check if the Container has been clicked
         *The  three parameters for (ScreenPointToLocalPointInRectangle)
         * 1: The Background Image has been clicked.
         * 2: The position of the click event within the bgImg.
         * 3: The camera postion of the time of the event.
         * 4: Return the Vector2 local point of the event.
        */
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            // Get the position in realtion to the background image of the x and y cordinates within the bgImg container.
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
            //Get the pivot point of the joystick
            //Condition to check to direction of the joystick 
            // If equal to 1 it's dragged right
            // If not equal to 1 it's dragged left
            float x = (bgImg.rectTransform.pivot.x ==1) ? pos.x *2+1 : pos.x*2-1;
            // If equal to 1 it's dragged up
            // If not equal to 1 it's dragged down
            float y = (bgImg.rectTransform.pivot.y ==1) ? pos.y * 2 + 1 : pos.y * 2 - 1;
            // Stoe the x,y cordinates to the InputDirection variable.
            Inputdirection = new Vector2(x, y);
            //Check if the direction is larger than one set it back to one by normalizing. If its not larger than one leave it as it is.
            Inputdirection = (Inputdirection.magnitude > 1) ? Inputdirection.normalized : Inputdirection;
            //Move the Joystick image when dragged.
            //Constrain the movement of the joystick to with the containing outer image.
            joystickImg.rectTransform.anchoredPosition = new Vector3(Inputdirection.x * (bgImg.rectTransform.sizeDelta.x / 3), Inputdirection.y * (bgImg.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        //Fix to bring the joystick to a click event within the outer container
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        //Set the joystick back to center position and direction to zero when the joystick has been realeased.
        Inputdirection = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
}
