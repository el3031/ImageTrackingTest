using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMorph : MonoBehaviour
{
    [SerializeField] private GameObject[] otherObjects;
    [SerializeField] private float distanceThreshold;
    private int index;
    private bool finalStage;

    private Dictionary<string, int> dict;
    private int currentActiveChild = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }  

    // Update is called once per frame
    
    void Update()
    {
        float[] distances = new float[otherObjects.Length];
        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = Vector3.Distance(transform.position, otherObjects[i].transform.position);
            Debug.Log("distance: " + distances[i] + ", " + i);
            if (distances[i] <= distanceThreshold)
            {
                Debug.Log("transforming " + i + ", distance: " + distances[i]);
                transform.GetChild(currentActiveChild).gameObject.SetActive(false);
                transform.GetChild(i).gameObject.SetActive(true);
                currentActiveChild = i;
            }
        }
    }
    

    /*
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("poop");
        Debug.Log(other.gameObject.name);
        Debug.Log(dict.ContainsKey(other.gameObject.name));
        if (dict.ContainsKey(other.gameObject.name))
        {
            transform.GetChild(currentActiveChild).gameObject.SetActive(false);
            currentActiveChild = dict[other.gameObject.name];
            transform.GetChild(currentActiveChild).gameObject.SetActive(true);
        }
    }
    */

    void NextTransformation()
    {
        GameObject currentActive = transform.GetChild(index).gameObject;
        if (++index == transform.childCount - 1)
        {
            finalStage = true;
        }
        GameObject nextActive = transform.GetChild(index).gameObject;

        currentActive.SetActive(false);
        nextActive.SetActive(true);
    }
}
