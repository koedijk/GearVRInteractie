using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    [SerializeField]
    private Text _textQuestion;
    public Score score;
    public VideoManage _Video;
    private GazeInteraction _Gaze;
    private AdvisersManager _advise;

    private ShowEndStats _showEnd;

    public GameObject AnswerButtons;
    private int AddScore = 20;

    public string[] QuestionStrings;
    public bool[] AnswersBooleans;
    public float[] TimeTillQuestion;

    private int CurrentQuestion = 0;
    private bool CurrentRightAnswer;

    void Awake()
    {
        
        _advise = GetComponent<AdvisersManager>();
        _Gaze = GameObject.Find("Camera").GetComponent<GazeInteraction>();
        score = GameObject.Find("Game_Manager").GetComponent<Score>();
        _showEnd = _Gaze.gameObject.GetComponent<ShowEndStats>();
        StartCoroutine(ShowQuestion());
    }

    void GetQuestion()
    {
        _textQuestion.text = QuestionStrings[CurrentQuestion];
        CurrentRightAnswer = AnswersBooleans[CurrentQuestion];
    }

    public void Waar()
    {
        if (!_advise.usedAdviser)
        {
            if (CurrentRightAnswer)
            {
                score.AnimateCounter(AddScore);
            }
        }
        AnswerButtons.SetActive(false);
        _Gaze.SetActive(false);
        _Video.PlayOrResume();
        StartCoroutine(ShowQuestion());
    }

    public void NietWaar()
    {
        if (!_advise.usedAdviser)
        {
            if (!CurrentRightAnswer)
            {
                score.AnimateCounter(AddScore);
            }
        }
        AnswerButtons.SetActive(false);
        _Gaze.SetActive(false);
        _Video.PlayOrResume();
        StartCoroutine(ShowQuestion());
    }

    IEnumerator ShowQuestion()
    {
        if (CurrentQuestion <= QuestionStrings.Length-1)
        {
            yield return new WaitForSeconds(TimeTillQuestion[CurrentQuestion]);
            AnswerButtons.SetActive(true);
            GetQuestion();
            _Video.Pause();
            
            if (_advise._adviserLeft == 0)
            {
                _advise.ActiveAdviseur(false);
            }
            else
            {
                _advise.ActiveAdviseur(true);
            }
            CurrentQuestion++;
        }
        else if(CurrentQuestion == QuestionStrings.Length)
        {
            _Video.Pause();
            yield return new WaitForSeconds(2);
            _showEnd.ActiveStats();

        }
    }
}
