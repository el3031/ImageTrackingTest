using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMorph : MonoBehaviour
{
    [SerializeField] private GameObject[] otherObjects;
    [SerializeField] private float distanceThreshold;
    
    private int index;
    private bool finalStage;

    private int yearTransformed = 0;
    
    //feel free to change this value in the inspector
    //the object can only be transformed once in x number of turns
    //this prevents object from flipping randomly when the transforming object is kept next to it
    [SerializeField] private int waitForDecades = 1;
    private UIFeatures uifeatures;

    private Dictionary<string, int> dict;
    private int currentActiveChild = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        uifeatures = GameObject.Find("Canvas").GetComponent<UIFeatures>();
        Debug.Log(uifeatures);
    }  

    // Update is called once per frame
    
    void Update()
    {
        float[] distances = new float[otherObjects.Length];
        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = Vector3.Distance(transform.position, otherObjects[i].transform.position);
            if (distances[i] <= distanceThreshold)
            {
                int currentYear = uifeatures.currentYear;
                
                //transform only if the distance is correct
                //AND if the correct number of decades has passed
                if ((currentYear - yearTransformed) / 10 >= waitForDecades)
                {
                    yearTransformed = currentYear;
                    transform.GetChild(currentActiveChild).gameObject.SetActive(false);
                    transform.GetChild(i).gameObject.SetActive(true);
                    currentActiveChild = i;
                }
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
