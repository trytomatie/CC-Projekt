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
    public int realDayCount = 0;
    public float dayLenght = 120;
    public int currentDayTimeInMinutes;


    public Color dayColor;
    public Color nightColor;
    public Color currentColor;

    public Light[] lights;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dayText;

    private static DayNightCycler instance;
    private bool afterMidnight = false;



    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        InvokeRepeating("UpdateTimeText", 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;
        dayTime += Time.deltaTime;
        if(!afterMidnight && dayTime > dayLenght/2)
        {
            afterMidnight = true;
            realDayCount++;
        }
        if (dayTime > dayLenght)
        {
            afterMidnight = false;
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
        lights[0].transform.rotation = Quaternion.Euler(Mathf.Round(lights[0].transform.rotation.eulerAngles.x), lights[0].transform.rotation.eulerAngles.y + (360 / dayLenght * Time.deltaTime), lights[0].transform.rotation.eulerAngles.z);
        currentColor = new Color(r, g, b,1);
        foreach (Light light in lights)
        {
            light.color = currentColor;
        }
    }

    private void UpdateTimeText()
    {
        TimeSpan span = TimeSpan.FromSeconds(86400 * (dayTime / dayLenght) + (86400/2));
        currentDayTimeInMinutes = (int)span.TotalMinutes;
        timeText.text = "Time: " + span.ToString(@"hh\:mm");
        dayText.text = "Day: " + realDayCount;
    }

    public static DayNightCycler Instance { get => instance; private set => instance = value; }
}
