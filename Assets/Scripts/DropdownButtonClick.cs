using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownButtonClick : MonoBehaviour
{
    private bool _isActive { get; set; }
    public GameObject _buildingsPanel;
    private Button _buildingsButton { get; set; }

    // Use this for initialization
    void Start ()
    {
        _isActive = false;
        _buildingsButton = GameObject.Find("BuildingsButton").GetComponent<Button>();
        _buildingsButton.onClick.AddListener(ExpandList);
	}

    void ExpandList()
    {
        if (_isActive == false)
        {
            _buildingsPanel.SetActive(true);
            _isActive = true;
        }
        else
        {
            _buildingsPanel.SetActive(false);
            _isActive = false;
        }
    }
}
