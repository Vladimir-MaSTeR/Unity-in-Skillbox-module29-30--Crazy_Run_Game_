using System;
using UnityEngine;
public class GameEvents : MonoBehaviour {
    public static Action<Vector3> onSwipeTrue;
    public static Action<bool> onPaused;
    
    public static Action onGameOver;
    public static Action onFinish;

    public static Action onAddCoin;
    public static Action<bool, int> onModifayCoin;
    public static Func<int> onGetCoin;

    public static Func<int> onGetSession;

    public static Action onRemoveStatsSaves;

    public static Action<bool> onActivePathAbility;

    //Sounds
    public static Action onNegativeAbility;
    public static Action onPositiveAbility;


}
