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
    public bool IsActive;

    void Start()
    {
        Button button = buildingsButton.GetComponent<Button>();
        IsActive = false;
        button.onClick.AddListener(GeneratePanelCards);
    }

    public void GeneratePanelCards()
    {
        foreach (Transform child in _panelGameObject.transform)
        {
            Destroy(child.gameObject);
        }
        //IsActive = !IsActive;
        //_panelGameObject.SetActive(false);
        _panelGameObject.SetActive(!_panelGameObject.activeSelf);
        IsActive = _panelGameObject.activeSelf;

        if (IsActive)
        {
            foreach (var building in State.buildings)
            {
                //Assigning button prefab to use for generating buttons
                var PanelCard = Instantiate(Prefab);
                PanelCard.name = building.name;
                PanelCard.tag = "Building";
                PanelCard.GetComponentInChildren<Text>().text = building.name;
                //GameObject.Find("Text_Product").GetComponent<Text>().text = building.name;

                //Button in PanelCard
                Button templateButton = GameObject.Find("PanelButton").GetComponent<Button>();
                templateButton.GetComponentInChildren<Text>().text = building.name + " : " + (int)building.basePrice;
                templateButton.name = building.name;

                //Tag for buying building
                templateButton.tag = "Building";

                //Setting parent for reference
                PanelCard.transform.SetParent(_panelTransform);

                //Properly positioning the buttons
                PanelCard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                PanelCard.transform.localPosition = new Vector3(PanelCard.transform.position.x, PanelCard.transform.position.y, 0);

                //Generating BuyBuilding OnClick
                templateButton.onClick.AddListener(() => BuyBuilding(building.name, templateButton));
            }
            _panelGameObject.SetActive(true);
        }
        else
        {
            _panelGameObject.SetActive(false);
        }
    }

    void BuyBuilding(string name, Button button)
    {
        button.GetComponentInChildren<Text>().text = name + " : " + (int)State.buildings.Find(x => x.name == name).basePrice;
    }
}
