using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGridVirtual : MonoBehaviour
{
    [SerializeField] private SnapToGrid s;
    [SerializeField] private Transform grid;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = s.transform.position;
        if (s.snap)
        {
            transform.parent = grid;
            Vector3 rawPos = s.transform.position;
            Vector3 snappedPos = new Vector3(Mathf.Round(rawPos.x), Mathf.Round(rawPos.y), Mathf.Round(rawPos.z));
            Debug.Log(snappedPos);
            transform.localPosition = snappedPos;
        }
    }
}
