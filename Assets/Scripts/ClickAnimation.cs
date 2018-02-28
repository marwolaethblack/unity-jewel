using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour {


    Animator anim { get; set; }
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.name == "Jewel")
                {
                    anim.Play("JewelClick", -1, 0f);                    

                }

            }
        }
    }
}
