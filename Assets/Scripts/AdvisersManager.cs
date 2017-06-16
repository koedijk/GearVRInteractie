using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvisersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonAdviser;
    private GameObject Advisers;
    private Image[] Image_Advisers;

    private bool _usedAdviser;
    public bool usedAdviser{get{return _usedAdviser;}set{_usedAdviser=value;}}

    private int _AdvisersLeft = 3;
    public int _adviserLeft{get{return _AdvisersLeft;}set{_AdvisersLeft = value;}}

    void Awake ()
	{
	    Advisers = GameObject.FindGameObjectWithTag("AdviseImages").gameObject;
	    Image_Advisers = Advisers.GetComponentsInChildren<Image>();
	}

    public void UseAdviser()
    {
        _usedAdviser = true;
        if (_AdvisersLeft > 0)
        {
            _AdvisersLeft--;
            Image_Advisers[_AdvisersLeft].color = new Color(255, 0, 0);
        }
        if (_AdvisersLeft == 0)
        { 
            ActiveAdviseur(false);
        }
        ActiveAdviseur(false);
    }

    public void ActiveAdviseur(bool a)
    {
        ButtonAdviser.SetActive(a);
    }
}
