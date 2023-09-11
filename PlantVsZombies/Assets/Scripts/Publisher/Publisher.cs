using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publisher
{
    private List<IListener> _listeners;

    public void AddListener(IListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(IListener listener)
    {
        _listeners.Remove(listener);
    }

    public void Invoke()
    {
        foreach (IListener listener in _listeners)
        {
            listener.OnInvoke();
        }
    }
}
