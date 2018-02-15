using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelScore : MonoBehaviour {


    public Text _text;

    // Use this for initialization
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            string text = "Jewels: " + Click.Result;
            _text.text = text;
        }
    }

