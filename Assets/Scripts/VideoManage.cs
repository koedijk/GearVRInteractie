using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManage : MonoBehaviour {
    public VideoPlayer _Video;
    public VideoClip[] Videos;
    public int CurrentVideo = 0;
    public Timer _time;
    // Use this for initialization
    void Awake()
    {
        _Video = GetComponent<VideoPlayer>();
        Videos = Resources.LoadAll<VideoClip>("");
        _Video.clip = Videos[CurrentVideo];
    }

    public void Pause()
    {
        _Video.Pause();
    }

    public void PlayOrResume()
    {
        _Video.Play();
    }

    public void LoadVideo(int num)
    {
        if (CurrentVideo == 0 && num == -1)
        {
            _Video.clip = Videos[Videos.Length-1];
        }
        else if (CurrentVideo == Videos.Length - 1 && num == 1)
        {
            CurrentVideo = 0;
            _Video.clip = Videos[CurrentVideo];
        }
        else
        {
            CurrentVideo = CurrentVideo + num;
            _Video.clip = Videos[CurrentVideo];
        }
    }
}
