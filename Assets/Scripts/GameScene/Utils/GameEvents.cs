using System;
using UnityEngine;
public class GameEvents : MonoBehaviour {
    public static Action<Vector3> onSwipeTrue;
    public static Action<bool> onPaused;
    
    public static Action onGameOver;
    public static Action onFinish;

    public static Action onAddCoin;
    public static Func<int> onGetCoin;

    public static Func<int> onGetSession;
}
