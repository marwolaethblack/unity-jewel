using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderMenuOnClick : MonoBehaviour {

    // Use this for initialization
    public Transform _panelTransform;
    public GameObject _panelGameObject;
    public GameObject PrefabBuilding;
    public GameObject PrefabUpgrade;
    public Button buildingsButton;
    public Button upgradeButton;
    public bool buildingsActive;
    public bool upgradesActive;

    void Start()
    {
        _panelGameObject.SetActive(true);

        Button Buildingsbutton = buildingsButton.GetComponent<Button>();
        Buildingsbutton.onClick.AddListener(BuildingsClickHandler);

        Button Upgradesbutton = upgradeButton.GetComponent<Button>();
        Upgradesbutton.onClick.AddListener(UpgradesClickHandler);

        buildingsActive = false;
        upgradesActive = false;
    }

    public void UpgradesClickHandler()
    {
        upgradesActive = !upgradesActive;
        if (upgradesActive)
        {
            if (buildingsActive)
            {
                DestroyPanelCards();
                buildingsActive = false;
            }
            GenerateUpgradesPanelCards();
        }
        else
        {
            DestroyPanelCards();
        }
    }

    public void BuildingsClickHandler()
    {
        buildingsActive = !buildingsActive;
        if (buildingsActive)
        {
            if (upgradesActive)
            {
                DestroyPanelCards();
                upgradesActive = false;
            }
            GenerateBuildingsPanelCards();
        }
        else
        {
            DestroyPanelCards();
        }
    }

    public void GenerateUpgradesPanelCards()
    {
        foreach (var upgrade in State.upgrades)
        {
            //Assigning button prefab to use for generating buttons
            var PanelCard = Instantiate(PrefabUpgrade);
            PanelCard.name = upgrade.name;
            PanelCard.tag = "Upgrade";

            Text[] texts = PanelCard.GetComponentsInChildren<Text>();
            texts[1].text = upgrade.description;
            texts[0].text = upgrade.name + " :\n " + (int)upgrade.price;

            //Setting parent for reference
            PanelCard.transform.SetParent(_panelTransform);

            //Properly positioning the buttons
            PanelCard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            PanelCard.transform.localPosition = new Vector3(PanelCard.transform.position.x, PanelCard.transform.position.y, 0);
        }
    }
    public void GenerateBuildingsPanelCards()
    {
        foreach (var building in State.buildings)
        {
            //Assigning button prefab to use for generating buttons
            var PanelCard = Instantiate(PrefabBuilding);
            PanelCard.name = building.name;
            PanelCard.tag = "Building";
            PanelCard.GetComponentInChildren<Text>().text = "1 " + building.name + " :\n " + (int)building.basePrice;

            //Sprite
            Sprite image = Resources.Load<Sprite>(building.spritePath);
            PanelCard.GetComponentInChildren<SpriteRenderer>().sprite = image;

            //Setting parent for reference
            PanelCard.transform.SetParent(_panelTransform);

            //Properly positioning the buttons
            PanelCard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            PanelCard.transform.localPosition = new Vector3(PanelCard.transform.position.x, PanelCard.transform.position.y, 0);
        }
    }

    public void DestroyPanelCards()
    {
        foreach (Transform child in _panelGameObject.transform)
        {
            Destroy(child.gameObject);
        }
        //_panelGameObject.SetActive(false);
    }
}
