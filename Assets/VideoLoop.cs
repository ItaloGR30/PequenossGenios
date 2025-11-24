using UnityEngine;
using UnityEngine.Video;

public class LoopVideo : MonoBehaviour
{
    void Start()
    {
        GetComponent<VideoPlayer>().isLooping = true;
    }
}
