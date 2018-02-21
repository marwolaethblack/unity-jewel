using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
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
	            if (hit.collider.tag == "Jewel")
	            {
	                CalculateJewels();
                }
                if (hit.collider.tag == "Building")
	            {
	                BuyBuilding();
                }
	        }
	    }
    }

    void CalculateJewels()
    {
        State.jewels = State.jewels + (ulong)State.jewelsPerClick;
        Debug.Log(State.jewels);
    }

    void BuyBuilding()
    {
        if (State.jewels >= 5)
        {
            State.jewels = State.jewels - 5;
            State.jewelsPerSecond = State.jewelsPerSecond + 0.1f;
            Debug.Log(State.jewels + " " + State.jewelsPerSecond);
        }
    }
}
