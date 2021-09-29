//Robado de aca jeje
//https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#5cf5960fedbc2a281acd21fa

using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Utils;

public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager eventManager;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if (eventDictionary == null)       
            eventDictionary = new Dictionary<string, UnityEvent>();      
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;

        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}