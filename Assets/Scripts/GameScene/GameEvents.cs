using System;
using UnityEngine;
public class GameEvents : MonoBehaviour {
    public static Action<Vector3> onSwipeTrue;
    public static Action<bool> onPaused;
    
    public static Action onGameOver;
    public static Action onFinish;

    public static Func<int> onGetCoin;
}
