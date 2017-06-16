using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FillUp : MonoBehaviour {
    public Timer Time;
    public Image image;
    public float CurrentAmount;
	// Use this for initialization
	void Awake()
	{
	    Time = GameObject.Find("Game_Manager").GetComponent<Timer>();
	    //image = GameObject.FindGameObjectWithTag("LoadingBar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        FillBar();
	}

    public void FillBar()
    {
        image.fillAmount = CurrentAmount / 2;
    }
}
