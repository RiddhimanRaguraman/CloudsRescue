using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public Scrollbar volumeScrollbar;

    private void Start()
    {
        // Set the initial value of the scrollbar to match the current volume
        volumeScrollbar.value = audioSource1.volume;

        // Subscribe to the value changed event of the scrollbar
        volumeScrollbar.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float newVolume)
    {
        // Update the volume of the AudioSource based on the scrollbar value
        audioSource1.volume = newVolume;
        audioSource2.volume = newVolume/5;
    }
}
