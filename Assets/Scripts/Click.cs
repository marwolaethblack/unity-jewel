using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    // Use this for initialization
    public GameObject _panelGameObject;
    public ParticleSystem pE;
    void Start()
    {
        pE.Stop();

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
                    pE.Play();
                    Invoke("stopEmmiting", 0.4f);
                }
                if (hit.collider.tag == "Building")
                {
                    Debug.Log(hit.collider.name);
                    BuyBuilding(hit.collider.name);
                }
            }
        }
    }

    void CalculateJewels()
    {
        State.jewels = State.jewels + (ulong)State.jewelsPerClick;
        Debug.Log(State.jewels);
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

                foreach (GameObject building in GameObject.FindGameObjectsWithTag("Building"))
                {
                    if (building.name == name)
                    {
                        building.GetComponentInChildren<Text>().text = State.buildings[buildingIndex].name + " : " + (int)State.buildings[buildingIndex].basePrice;
                    }
                }
            }
        }
        State.calcNewCps();
    }

    public void stopEmmiting()
    {
        pE.Stop();
    }
}
