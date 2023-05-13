using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
public class StatisticsPlay : MonoBehaviour {
    [SerializeField]
    private TMP_Text _oneMazeText;
    [SerializeField]
    private TMP_Text _oneCoinText;

    [SerializeField]
    private TMP_Text _twoMazeText;
    [SerializeField]
    private TMP_Text _twoCoinText;

    [SerializeField]
    private TMP_Text _threeMazeText;
    [SerializeField]
    private TMP_Text _threeCoinText;

    private string DEFAULT_FALUE = "--";


    private void Start() { ViewStatisticsGame(); }

    private void OnEnable() { GameEvents.onRemoveStatsSaves += ViewStatisticsGame; }

    private void OnDisable() { GameEvents.onRemoveStatsSaves -= ViewStatisticsGame; }

    private void ViewStatisticsGame() {
        // List<int> oldMaze = ReloadStatisticsFromPlayerPrefs(GameConstants.PASSED_ROUNDS_KEY);
        // List<int> oldCoin = ReloadStatisticsFromPlayerPrefs(GameConstants.All_COIN_IN_SESSION_KEY);

        List<int> oldMaze = new List<int>();
        List<int> oldCoin = new List<int>();
        
        var map = ReloadStatsInDictionary();

        foreach(var item in map) {
            oldMaze.Add(item.Key);
            oldCoin.Add(item.Value);
        }
        

        if(oldMaze.Count > 0 && oldMaze.Count > 0) {
            _oneMazeText.text = oldMaze[0].ToString();
            _oneCoinText.text = oldCoin[0].ToString();
        } else {
            _oneMazeText.text = DEFAULT_FALUE;
            _oneCoinText.text = DEFAULT_FALUE;
        }

        if(oldMaze.Count > 1 && oldMaze.Count > 1) {
            _twoMazeText.text = oldMaze[1].ToString();
            _twoCoinText.text = oldCoin[1].ToString();
        } else {
            _twoMazeText.text = DEFAULT_FALUE;
            _twoCoinText.text = DEFAULT_FALUE;
        }

        if(oldMaze.Count > 2 && oldMaze.Count > 2) {
            _threeMazeText.text = oldMaze[2].ToString();
            _threeCoinText.text = oldCoin[2].ToString();
        } else {
            _threeMazeText.text = DEFAULT_FALUE;
            _threeCoinText.text = DEFAULT_FALUE;
        }
    }

    private List<int> ReloadStatisticsFromPlayerPrefs(string value) {
        List<int> returnList = new List<int>();
        int session = 0;

        if(PlayerPrefs.HasKey(GameConstants.SESSION_KEY)) {
            session = PlayerPrefs.GetInt(GameConstants.SESSION_KEY);
        }

        for(int i = 0; i <= session; i++) {
            if(PlayerPrefs.HasKey(value + i)) {
                returnList.Add(PlayerPrefs.GetInt(value + i));
            }
        }

        return returnList;
    }

    private Dictionary<int, int> ReloadStatsInDictionary() {
        int session = 0;

        Dictionary<int, int> map = new Dictionary<int, int>();
        Dictionary<int, int> resultMap = new Dictionary<int, int>();

        if(PlayerPrefs.HasKey(GameConstants.SESSION_KEY)) {
            session = PlayerPrefs.GetInt(GameConstants.SESSION_KEY);
        }

        for(int i = 0; i <= session; i++) {
            if(PlayerPrefs.HasKey(GameConstants.PASSED_ROUNDS_KEY + i) && 
               PlayerPrefs.HasKey(GameConstants.All_COIN_IN_SESSION_KEY + i)) {
               
                map.Add(PlayerPrefs.GetInt(GameConstants.PASSED_ROUNDS_KEY + i), 
                              PlayerPrefs.GetInt(GameConstants.All_COIN_IN_SESSION_KEY + i));
            }
        }

        foreach (var item in map.OrderByDescending(key => key.Value)) {
            resultMap.Add(item.Key, item.Value);
        }

        return resultMap;
    }
}
