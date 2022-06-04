using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFeatures : MonoBehaviour
{
    [SerializeField] private Text year;
    public int currentYear;
    
    [SerializeField] private float co2MaxDelta;
    [SerializeField] private float co2MinDelta;
    [SerializeField] private Slider co2Meter;

    public void OnEndTurn()
    {
        currentYear += 10;
        year.text = (currentYear).ToString();
        
        float co2Delta = Random.Range(co2MinDelta, co2MaxDelta);
        co2Meter.value += co2Delta;
    }
}
