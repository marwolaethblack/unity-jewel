using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButtons : MonoBehaviour
{

    public Transform _panelGameObject;

    public GameObject buttonPrefab;
	// Use this for initialization
	void Start () {
	    foreach (var building in State.buildings)
	    {
	        GameObject button = Instantiate(buttonPrefab);
	        button.name = building.name;
            button.GetComponentInChildren<Text>().text = building.name;
	        button.tag = "Building";
	        button.transform.SetParent(_panelGameObject);
	        button.transform.localScale = new Vector3(1f,1f,1f);
	        button.transform.localPosition = new Vector3(button.transform.position.x, button.transform.position.y, 0);
	    }
	}
}
