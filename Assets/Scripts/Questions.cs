using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    [SerializeField]
    private Text _textQuestion;
    public Score Score;
    public VideoManage _Video;
    private GazeInteraction _Gaze;
    private AdvisersManager _advise;

    [SerializeField]
    private ShowEndStats _showEnd;

    public GameObject AnswerButtons;
    private Text HintText;
    private int AddScore = 20;

    public string[] QuestionStrings;
    public bool[]   AnswersBooleans;
    public string[] Hints;
    public float[]  TimeTillQuestion;

    [SerializeField]
    private int  CurrentQuestion = 0;
    private bool CurrentRightAnswer;

    void Awake()
    {
        HintText = GameObject.FindGameObjectWithTag("HintText").GetComponent<Text>();
        _advise = GetComponent<AdvisersManager>();
        _Gaze = GameObject.Find("Camera").GetComponent<GazeInteraction>();
        Score = GameObject.Find("Game_Manager").GetComponent<Score>();
        _showEnd = _Gaze.gameObject.GetComponent<ShowEndStats>();
        StartCoroutine(ShowQuestion());
        _advise.ShowHint(false);
        AnswerButtons.SetActive(false);
        
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
                Score.AnimateCounter(AddScore);
            }
        }
        AnswerButtons.SetActive(false);
        _Gaze.SetActive(false);
        _Video.PlayOrResume();
        StartCoroutine(ShowQuestion());
        _advise.usedAdviser = false;
        _advise.ShowHint(false);
    }

    public void NietWaar()
    {
        if (!_advise.usedAdviser)
        {
            if (!CurrentRightAnswer)
            {
                Score.AnimateCounter(AddScore);
            }
        }
        AnswerButtons.SetActive(false);
        _Gaze.SetActive(false);
        _Video.PlayOrResume();
        StartCoroutine(ShowQuestion());
        _advise.usedAdviser = false;
        _advise.ShowHint(false);
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
            yield return new WaitForSeconds(5);
            _showEnd.ActiveStats();
        }
    }

    public void SetHInt()
    {
        HintText.text = Hints[CurrentQuestion-1];
    }
}
