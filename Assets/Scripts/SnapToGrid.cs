using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    public bool snap = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (snap)
        {
            Vector3 rawPos = transform.localPosition;
            Vector3 snappedPos = new Vector3(Mathf.Round(rawPos.x), Mathf.Round(rawPos.y), Mathf.Round(rawPos.z));
            Debug.Log(snappedPos);
            transform.localPosition = snappedPos;
        }
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grid"))
        {
            Debug.Log("snapping");
            snap = true;
            //this.transform.parent = grid.transform;
        }
        else
        {
            Debug.Log("poop");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grid"))
        {
            snap = false;
            //this.transform.parent = null;
        }
    }
}
