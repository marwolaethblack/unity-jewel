using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    // Use this for initialization
    private GameObject _panelGameObject;
    public ParticleSystem pE;
    private RenderMenuOnClick sn;
    void Start()
    {
        pE.Stop();
        _panelGameObject = GameObject.FindGameObjectWithTag("PanelCardPanel");
        sn = _panelGameObject.GetComponent<RenderMenuOnClick>();

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
                if (hit.collider.tag == "Upgrade")
                {
                    BuyUpgrade(hit.collider.name);
                }
            }
        }
    }

    void CalculateJewels()
    {
        State.jewels += (ulong)State.jewelsPerClick * State.clickMultiplier;
    }

   

    void BuyBuilding(string name)
    {
        var buildingIndex = State.buildings.FindIndex(x => x.name == name);

        if(buildingIndex != -1)
        {
            var foundBuilding = State.buildings[buildingIndex];
            if (State.jewels >= foundBuilding.basePrice)
            {
                foundBuilding.amount++;
                State.jewels -= (ulong)foundBuilding.basePrice;
                State.buildings[buildingIndex].basePrice *= foundBuilding.priceIncrease;

                foreach (GameObject building in GameObject.FindGameObjectsWithTag("Building"))
                {
                    if (building.name == name)
                    {
                        building.GetComponentInChildren<Text>().text = "Buy " + foundBuilding.name + " :\n " + (int)foundBuilding.basePrice;
                    }
                }
            }
        }
        State.calcNewCps();
    }

    void BuyUpgrade(string name)
    {
        var upgradeIndex = State.upgrades.FindIndex(x => x.name == name);


        if (upgradeIndex != -1)
        {
            var foundUpgrade = State.upgrades[upgradeIndex];
            if (State.jewels >= foundUpgrade.price)
            {
                State.jewels -= (ulong)foundUpgrade.price;

                foreach (GameObject upgrade in GameObject.FindGameObjectsWithTag("Upgrade"))
                {
                    if (upgrade.name == name)
                    {
                        Building foundBuilding =
                            State.buildings.Find(x => x.name == foundUpgrade.requiredBuilding);
                        foundBuilding.upgrades.Add(foundUpgrade);
                        upgrade.GetComponentInChildren<Text>().text = "Buy " + foundUpgrade.name + " :\n " + (int)foundUpgrade.price;

                        //Delete upgrade
                        State.upgrades.Remove(foundUpgrade);
                        sn.DestroyPanelCards();
                        sn.GenerateUpgradesPanelCards();
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
