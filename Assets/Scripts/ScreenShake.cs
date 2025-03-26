using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Start Shake")]
    public void StartShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 100;
    }

    [ContextMenu("End Shake")]
    public void EndShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
}
