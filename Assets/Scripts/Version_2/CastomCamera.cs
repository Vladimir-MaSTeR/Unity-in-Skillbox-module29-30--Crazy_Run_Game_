using UnityEngine;
public class CastomCamera : MonoBehaviour {
    
    [SerializeField]
    private GameObject _playerPrefab;
    
    private Vector3 offset; 
    
    void Start () 
    {        
        offset = this.transform.position - _playerPrefab.transform.position;
    }
    void FixedUpdate () 
    {        
        this.transform.LookAt(_playerPrefab.transform);
        this.transform.position = _playerPrefab.transform.position + offset;
    }
}
