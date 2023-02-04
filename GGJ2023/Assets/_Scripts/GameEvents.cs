using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameEvents : MonoBehaviour
{
    public event Action OnTurnStart;

    public void CallDayChanged()
    {
        OnTurnStart?.Invoke();
    }
}
