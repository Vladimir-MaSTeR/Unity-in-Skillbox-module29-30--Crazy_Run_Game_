using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class SounsMenuScene : MonoBehaviour {
    [SerializeField]
    private AudioSource _fonSource;
    [SerializeField]
    private AudioSource _environmentSource;

    [Header("Фоновая музыка")]
    [SerializeField]
    private AudioClip _menuSceneFonClip;
    [SerializeField]
    private AudioClip[] _gamefonClips;

    [Space(20)]
    [Header("Остальные клипы")]

    [SerializeField]
    private AudioClip _clickButtonClip;
    
    [SerializeField]
    private AudioClip _coinClip;
    
    [SerializeField]
    private AudioClip _finishClip;
    
    [SerializeField]
    private AudioClip _gameOverClip;
    
    [SerializeField]
    private AudioClip _negativeAbilityClip;

    private void Start() { StartFonMusic(); }

    private void OnEnable() {
        GameEvents.onAddCoin += CoinMusic;
        GameEvents.onGameOver += GameOverMusic;
        GameEvents.onFinish += FinishMusic;
        GameEvents.onNegativeAbility += NegativeAbility;
        GameEvents.onPositiveAbility += ClickButtonsMusic;
    }

    private void OnDisable() {
        GameEvents.onAddCoin -= CoinMusic;
        GameEvents.onGameOver -= GameOverMusic;
        GameEvents.onFinish -= FinishMusic;
        GameEvents.onNegativeAbility -= NegativeAbility;
        GameEvents.onPositiveAbility -= ClickButtonsMusic;
    }

    private void StartFonMusic() {
        if(GameConstants.MENU_SCENE_INDEX == SceneManager.GetActiveScene().buildIndex) {
            _fonSource.clip = _menuSceneFonClip;
            _fonSource.Play();
            _fonSource.loop = true;
        } else {
            var clipIndex = Random.Range(0, _gamefonClips.Length);

            _fonSource.clip = _gamefonClips[clipIndex];
            _fonSource.Play();
            _fonSource.loop = true;
        }
    }
    
    private void CoinMusic() {
        _environmentSource.PlayOneShot(_coinClip);
    }
    
    private void FinishMusic() {
        _fonSource.Stop();
        _environmentSource.PlayOneShot(_finishClip);
    }
    
    private void GameOverMusic() {
        _fonSource.Stop();
        _environmentSource.PlayOneShot(_gameOverClip);
    }

    public void ClickButtonsMusic() {
        _environmentSource.PlayOneShot(_clickButtonClip);
    }

    public void NegativeAbility() {
        _environmentSource.PlayOneShot(_negativeAbilityClip);
    }
}
