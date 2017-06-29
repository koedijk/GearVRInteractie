using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShowEndStats : MonoBehaviour
{
    private GameObject _gameManager;
    private GameObject _scoreCanvas;
    private GameObject _EndscreenCanvas;

    private Score _score;
    private AdvisersManager _advisersManager;

    private Text _scoreText;
    private Text _adviserText;
	
	void Awake ()
    {
		_gameManager = GameObject.Find("Game_Manager");
	    _score = _gameManager.GetComponent<Score>();
	    _advisersManager = _gameManager.GetComponent<AdvisersManager>();
        _adviserText = GameObject.FindGameObjectWithTag("Advisetext").GetComponent<Text>();
        _scoreText = GameObject.FindGameObjectWithTag("Endscore").GetComponent<Text>();
	    _scoreCanvas = GameObject.FindGameObjectWithTag("ScoreCanvas");
        _EndscreenCanvas = GameObject.FindGameObjectWithTag("Endscreen");

        _EndscreenCanvas.SetActive(false);
    }

    public void ActiveStats()
    {
        _scoreText.text = _score._Score.ToString();
        _adviserText.text = _advisersManager._adviserLeft.ToString();
        _EndscreenCanvas.SetActive(true);
        _scoreCanvas.SetActive(false);
    }
}
