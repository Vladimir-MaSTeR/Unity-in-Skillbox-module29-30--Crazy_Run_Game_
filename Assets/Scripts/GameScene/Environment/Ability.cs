using System;
using TMPro;
using UnityEngine;
public class Ability : MonoBehaviour {

    [SerializeField]
    private TMP_Text _pathAbilityText;

    [Space(20)]

    [SerializeField]
    private int _prisePathAbility = 5;

    private void Start() { _pathAbilityText.text = $"{_prisePathAbility} тонет"; }

    public void clickPathAbility() {
        var currentCoin = GameEvents.onGetCoin?.Invoke();

        if(currentCoin > _prisePathAbility) {
            GameEvents.onPositiveAbility?.Invoke();
            GameEvents.onActivePathAbility?.Invoke(true);
            GameEvents.onModifayCoin?.Invoke(false, _prisePathAbility);
        } else {
            GameEvents.onNegativeAbility?.Invoke();
        }
        
    }
}
