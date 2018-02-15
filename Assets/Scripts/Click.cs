using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    //Can do this for now
    public static ulong Result;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetMouseButtonDown(0))
	    {
	        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

	        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
	        if (hit.collider != null)
	        {
	            CalculateJewels();
	        }
	    }
    }

    void CalculateJewels()
    {
        Result += State.jewels + (ulong)State.jewelsPerClick;
        Debug.Log(Result);
    }
}
