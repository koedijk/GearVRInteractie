using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeInteraction : MonoBehaviour
{
    private Timer Time;
    private GazeRaycast Raycast;
    private GameObject GazeHolder;
    private FillUp Fill;

    private int PointEnterCount;

	void Awake ()
	{
	    Time = GameObject.Find("Game_Manager").GetComponent<Timer>();
	    Raycast = GetComponent<GazeRaycast>();
	    GazeHolder = GameObject.FindGameObjectWithTag("Gaze");
	    Fill = GazeHolder.GetComponent<FillUp>();
	}

    void Start()
    {
        GazeHolder.SetActive(false);
    }

	void Update ()
    {
        if (Raycast.Hit.collider && PointEnterCount == 0)
	    {
            PointerEnter();
	        PointEnterCount = 1;
	    }
        else if (Raycast.Hit.collider && Raycast.Hit.collider != null)
	    {
            PointerStay();
	    }
	    else if(Raycast.Hit.collider == null && PointEnterCount == 1)
	    {
            PointerExit();
	        GazeHolder.SetActive(false);
            PointEnterCount = 0;
        }
	    if (Time.stopWatch >= 2)
	    {
            PointerDown();
	    }
	}

    public void PointerEnter()
    {
        GazeHolder.SetActive(true);
    }

    public void PointerStay()
    {
        Time.StartTimer();
        Fill.CurrentAmount = Time.stopWatch;
    }

    public void PointerExit()
    {
        Time.stopWatch = 0;
    }

    public void PointerDown()
    {
        ExecuteEvents.Execute(Raycast.Hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        Time.stopWatch = 0;
    }

    public void SetActive(bool a)
    {
        GazeHolder.SetActive(a);
    }
}
