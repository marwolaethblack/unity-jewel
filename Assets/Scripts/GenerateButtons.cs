using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButtons : MonoBehaviour
{

    public Transform _panelGameObject;
    public Button buttonPrefab;
    public Button button;

	// Use this for initialization
	void Start () {
	    foreach (var building in State.buildings)
	    {
            button = Instantiate(buttonPrefab);
            button.name = building.name;
            button.GetComponentInChildren<Text>().text = building.name + " : " + building.basePrice;
	        button.tag = "Building";
	        button.transform.SetParent(_panelGameObject);
	        button.transform.localScale = new Vector3(1f,1f,1f);
	        button.transform.localPosition = new Vector3(button.transform.position.x, button.transform.position.y, 0);
            button.onClick.AddListener(() => BuyBuilding(building.name));
	    }
	}

    void BuyBuilding(string name)
    {
        GameObject.Find(name).GetComponentInChildren<Text>().text = name + " : " + State.buildings.Find(x => x.name == name).basePrice;
    }
}
