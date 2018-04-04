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
    public bool IsActive;

    void Start()
    {
        Button button = upgradeButton.GetComponent<Button>();
        IsActive = false;
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

        if (IsActive)
        {

            foreach (var upgrade in State.upgrades)
            {
                //Assigning button prefab to use for generating buttons
                var PanelCard = Instantiate(Prefab);
                PanelCard.name = upgrade.name;
                PanelCard.tag = "Upgrade";
                PanelCard.GetComponentInChildren<Text>().text = upgrade.name + " : " + upgrade.price;


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
