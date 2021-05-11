using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNightCycler : MonoBehaviour
{

    public float dayTime;
    public float totaltime;
    public int dayCount = 0;
    public float dayLenght = 120;


    public Color dayColor;
    public Color nightColor;
    public Color currentColor;

    public Light[] lights;

    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTimeText", 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;
        dayTime += Time.deltaTime;
        if (dayTime > dayLenght)
        {
            dayTime -= dayLenght;
            dayCount++;
        }
        int nightTimeModifier = 0;
        int nightTimeModifier2 = 1;
        if (dayTime > (dayLenght / 2) )
        {
            nightTimeModifier = 2;
            nightTimeModifier2 = -1;
        }
        float lerpValue = Mathf.Clamp01(nightTimeModifier + nightTimeModifier2 * (dayTime / (dayLenght / 2)));
        float r = Mathf.Lerp(dayColor.r, nightColor.r, lerpValue);
        float g = Mathf.Lerp(dayColor.g, nightColor.g, lerpValue);
        float b = Mathf.Lerp(dayColor.b, nightColor.b, lerpValue);
        currentColor = new Color(r, g, b,1);
        foreach (Light light in lights)
        {
            light.color = currentColor;
        }
    }

    private void UpdateTimeText()
    {
        TimeSpan span = TimeSpan.FromSeconds(86400 * (dayTime / dayLenght) + (86400/2));
        timeText.text = "Time: " + span.ToString(@"hh\:mm");
    }
}
