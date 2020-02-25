using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_the_button : MonoBehaviour
{
    
    RectTransform rectTransform;
    private bool hostage=false;
    public float border=200;
    
    public float dx;
    public float dy;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //Debug.Log(Mathf.Max(1.2f, 2.4f));
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Debug.Log("Update");
        if (hostage==true)
        {
            //Debug.Log("down");
            //this.Transform.Position.x++;
            //Debug.Log(transform.position.x);
            //Debug.Log(rectTransform.rect.position.x);
            //.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
            Debug.Log(rectTransform.anchoredPosition.x);
            float x=rectTransform.anchoredPosition.x;
            float y=rectTransform.anchoredPosition.y;
            float mx=Input.GetAxis("Mouse X")*4.14f;//*7;//7forEditor
            float my=Input.GetAxis("Mouse Y")*4.14f;//*7;//7forEditor
            dx=x+mx;
            dy=y+my;
            dx=Mathf.Min(dx, border);
            dx=Mathf.Max(dx, 0-border);
            dy=Mathf.Min(dy, border);
            dy=Mathf.Max(dy, 0-border);
            rectTransform.anchoredPosition= new Vector2(dx, dy);
            
            
        }
        
        if(Input.GetMouseButtonDown(0)){
            //Debug.Log("cl.");
            if(rectTransform.rect.Contains(Input.mousePosition)){
                //Debug.Log("click.");
                hostage=true;
            }
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
            if (rectTransform.rect.Contains(localMousePosition))
            {
                //Debug.Log("click?!?.");
                hostage=true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("release.");
            hostage=false;
        }
        
    }
}
