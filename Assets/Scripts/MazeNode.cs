using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState {
    AVAILABLE,
    CURRENT,
    COMPLETED
}

public class MazeNode : MonoBehaviour
{
    [Header("Стены")]
    [SerializeField]
    private GameObject[] _walls;

    [Header("Пол")]
    [SerializeField]
    private MeshRenderer _floor;

    public void RemoveWall(int wallToRemove) {
        _walls[wallToRemove].gameObject.SetActive(false);
    }

    public void SetState(NodeState state) {
        switch(state) {
            case NodeState.AVAILABLE:
                _floor.material.color = Color.white;
                break;
            case NodeState.CURRENT:
                _floor.material.color = Color.yellow;
                break;
            case NodeState.COMPLETED:
                _floor.material.color = Color.blue;
                break;
        }
    }
}
