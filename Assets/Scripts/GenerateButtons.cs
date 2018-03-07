using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButtons : MonoBehaviour
{

    public Transform _panelTransform;
    public GameObject _panelGameObject;
    public GameObject Prefab;
    public Button buildingsButton;
    public bool IsActive = false;

    void Start()
    {
        Button button = buildingsButton.GetComponent<Button>();
        button.onClick.AddListener(GeneratePanelCards);

        foreach (var building in State.buildings)
        {
            //Assigning button prefab to use for generating buttons
            var PanelCard = Instantiate(Prefab);
            PanelCard.name = building.name;
            GameObject.Find("Text_Product").GetComponent<Text>().text = building.name;
            GameObject.Find("PanelButton").GetComponent<Button>().GetComponentInChildren<Text>().text = building.basePrice.ToString();
            GameObject.Find("PanelButton").GetComponent<Button>().name = building.name;
            //Tag for buying building
            PanelCard.tag = "Building";

            //Setting parent for reference
            PanelCard.transform.SetParent(_panelTransform);

            //Properly positioning the buttons
            PanelCard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            PanelCard.transform.localPosition = new Vector3(PanelCard.transform.position.x, PanelCard.transform.position.y, 0);

            //Generating BuyBuilding OnClick
            button.onClick.AddListener(() => BuyBuilding(building.name));
        }
    }

    void BuyBuilding(string name)
    {
        GameObject.Find(name).GetComponentInChildren<Text>().text = name + " : " + State.buildings.Find(x => x.name == name).basePrice;
    }

    public void GeneratePanelCards()
    {
        IsActive = !IsActive;
        if (IsActive)
        {
            _panelGameObject.SetActive(true);
        }
        else
        {
            _panelGameObject.SetActive(false);
        }
    }
}
