using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ManageEvents : MonoBehaviour
{

    public Text text;
    public ParticleSystem particle;

	// Use this for initialization
	void Start ()
	{
	    InvokeRepeating("CheckForEvent", 1, 30);
	}

    void CheckForEvent()
    {
        State.CheckNewEvents();
        System.Random rnd = new System.Random();
        int chance = rnd.Next(1, 101);
        foreach (var e in State.events)
        {
            if (e.probability >= chance && e.active)
            {
                text.text = e.name;
                State.TriggerEvent(e);
                particle.Emit(800);
                Invoke("Hide", e.duration);
            }
        }
    }

    void Hide()
    {
        text.text = "";
   }
}
