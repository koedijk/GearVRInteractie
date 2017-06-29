using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private const float duration = 3f;
    private int _score = 0;
    public int _Score {
        get { return _score; }
        set { _score = value; }
    }

    void Awake ()
	{
	    scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
	    scoreText.text = _score.ToString();
	}

    public IEnumerator CountTo(int AmountGain)
    {
        int start = _score;
        int target = start + AmountGain;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float _progress = timer / duration;
            _score = (int)Mathf.Lerp(start, target,_progress);
            scoreText.text = _score.ToString();
            yield return null;
        }
        _score = target;
        scoreText.text = _score.ToString();
    }

    public void AnimateCounter(int PlusScore)
    {
        StartCoroutine(CountTo(PlusScore));
    }
}
