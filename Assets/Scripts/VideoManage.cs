using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManage : MonoBehaviour {
    public VideoPlayer Video;
    public VideoClip[] Videos;
    public int CurrentVideo = 0;
    // Use this for initialization
    void Awake()
    {
        Video = GetComponent<VideoPlayer>();
        Videos = Resources.LoadAll<VideoClip>("");
        Video.clip = Videos[CurrentVideo];
    }

    public void Pause()
    {
        Video.Pause();
    }

    public void PlayOrResume()
    {
        Video.Play();
    }

    public void LoadVideo(int num)
    {
        if (CurrentVideo == 0 && num == -1)
        {
            Video.clip = Videos[Videos.Length-1];
        }
        else if (CurrentVideo == Videos.Length - 1 && num == 1)
        {
            CurrentVideo = 0;
            Video.clip = Videos[CurrentVideo];
        }
        else
        {
            CurrentVideo = CurrentVideo + num;
            Video.clip = Videos[CurrentVideo];
        }
    }
}
