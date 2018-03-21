using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUpgradesButtons : MonoBehaviour {

    public Transform _panelTransform;
    public GameObject _panelGameObject;
    public GameObject Prefab;
    public Button upgradeButton;
    public bool IsActive = false;

    void Start()
    {
        Button button = upgradeButton.GetComponent<Button>();
        button.onClick.AddListener(GeneratePanelCards);
    }

    public void GeneratePanelCards()
    {
        foreach (Transform child in _panelGameObject.transform)
        {
            Destroy(child.gameObject);
        }
        _panelGameObject.SetActive(!_panelGameObject.activeSelf);
        IsActive = _panelGameObject.activeSelf;
        //IsActive = !IsActive;
        //_panelGameObject.SetActive(false);

        if (IsActive)
        {
            //foreach (Transform child in _panelTransform)
            //{
            //    if (child.tag == "Upgrade")
            //    {
            //        child.gameObject.SetActive(true);
            //    }
            //    else
            //    {
            //        child.gameObject.SetActive(false);
            //    }
            //}

            foreach (var upgrade in State.upgrades)
            {
                //Assigning button prefab to use for generating buttons
                var PanelCard = Instantiate(Prefab);
                PanelCard.name = upgrade.name;
                PanelCard.tag = "Upgrade";

                //Button in PanelCard
                Button templateButton = GameObject.Find("PanelButton").GetComponent<Button>();
                templateButton.GetComponentInChildren<Text>().text = upgrade.price.ToString();
                templateButton.name = upgrade.name;

                //Tag for buying building
                templateButton.tag = "Upgrade";

                //Setting parent for reference
                PanelCard.transform.SetParent(_panelTransform);

                //Properly positioning the buttons
                PanelCard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                PanelCard.transform.localPosition = new Vector3(PanelCard.transform.position.x, PanelCard.transform.position.y, 0);
            }

            _panelGameObject.SetActive(true);
        }
        else
        {
            _panelGameObject.SetActive(false);
        }
    }
}
