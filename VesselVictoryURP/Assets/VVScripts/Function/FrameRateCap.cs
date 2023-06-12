using UnityEngine;
public class FrameRateCap : MonoBehaviour
{
    [SerializeField][Tooltip("Framerate Cap")][Range(30, 144)] private int framerate;
    void Start()
    {
        Application.targetFrameRate = framerate;
        QualitySettings.vSyncCount = 1;
    }
}