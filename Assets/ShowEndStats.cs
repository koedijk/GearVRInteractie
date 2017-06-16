using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ShowEndStats : MonoBehaviour
{
    private GameObject _gameManager;
    private Score _score;
    private AdvisersManager _advisersManager;
    private Text _scoreText;
    private Text _adviserText;
	
	void Start ()
    {
		_gameManager = GameObject.Find("Game_Manager");
	    _score = _gameManager.GetComponent<Score>();
	    _advisersManager = _gameManager.GetComponent<AdvisersManager>();
	    _scoreText = GameObject.FindGameObjectWithTag("Endscore").GetComponent<Text>();
	    _adviserText = GameObject.FindGameObjectWithTag("AdviseText").GetComponent<Text>();
        //_scoreText.gameObject.SetActive(false);
        //_adviserText.gameObject.SetActive(false);
	}
	
	void Update ()
    {
		
	}

    public void ActiveStats()
    {
        _scoreText.gameObject.SetActive(true);
        _adviserText.gameObject.SetActive(true);
        _scoreText.text = _score._Score.ToString();
        _adviserText.text = _advisersManager._adviserLeft.ToString();
    }
}
