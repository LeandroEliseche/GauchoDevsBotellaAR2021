using UnityEngine;
using UnityEngine.Playables;

public class TrackingManager : DefaultTrackableEventHandler
{
    [Header("Setting")]
    public GameObject trackingMessage;
    public AudioSource source;

    protected override void OnTrackingFound()
    {
        source.Play();
        trackingMessage.SetActive(false);
        Time.timeScale = 1;

        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        source.Pause();
        trackingMessage.SetActive(true);
        Time.timeScale = 0;

        base.OnTrackingLost();
    }
}