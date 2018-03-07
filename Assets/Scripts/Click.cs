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
            //RaycastHit hitPoint;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity))
            //{
            //    if (hitPoint.collider.tag == "Jewel")
            //    {
            //        CalculateJewels();
            //    }

            //    if (hitPoint.collider.tag == "Building")
            //    {
            //        BuyBuilding(hitPoint.collider.name);
            //        Debug.Log(hitPoint.collider.name);
            //       }
            //   }



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
                    BuyBuilding(hit.collider.name);
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }

    void CalculateJewels()
    {
        State.jewels = State.jewels + (ulong)State.jewelsPerClick;
    }

   

    void BuyBuilding(string name)
    {
        var buildingIndex = State.buildings.FindIndex(x => x.name == name);

        if(buildingIndex != -1)
        {
            if (State.jewels >= State.buildings[buildingIndex].basePrice)
            {
                State.buildings[buildingIndex].amount++;
                State.jewels -= (ulong)State.buildings[buildingIndex].basePrice;
                State.buildings[buildingIndex].basePrice *= State.buildings[buildingIndex].priceIncrease;
            }
        }


        State.calcNewCps();
    }
}
