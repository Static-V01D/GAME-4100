using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier;
    [SerializeField]
    private float startHour;
    [SerializeField] 
    private TextMeshProUGUI timeText;
    [SerializeField]
    private Light sunLight;
    [SerializeField]
    private float sunriseHour;        
    [SerializeField]
    private float sunSetHour;
    [SerializeField]
    private Color dayAmbientLight;
    [SerializeField]
    private Color nightAmbientLight;
    [SerializeField]
    private AnimationCurve lightChangeCurve;
    [SerializeField]
    private float maxSunLightIntensity;
    [SerializeField]
    private Light moonLight;
    [SerializeField]
    private float maxMoonLightIntensity;





    private DateTime curremtTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunSetTime;



    // Start is called before the first frame update
    void Start()
    {
        curremtTime = DateTime.Now.Date+ TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunSetTime = TimeSpan.FromHours(sunSetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        curremtTime = curremtTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if(timeText != null ) 
        {
            timeText.text = curremtTime.ToString("HH:mm");
        
        }
    }

    private void RotateSun()
    {
        float SunlightRotation;

        if(curremtTime.TimeOfDay > sunriseTime && curremtTime.TimeOfDay < sunSetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTheDifference(sunriseTime, sunSetTime);
            TimeSpan TimeSinceSunrise = CalculateTheDifference(sunriseTime, curremtTime.TimeOfDay);


            double percentage = TimeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            SunlightRotation = Mathf.Lerp(0,180,(float)percentage);

        }
        else
        {
            TimeSpan sunSetToSunriseDuration = CalculateTheDifference(sunSetTime, sunriseTime);
            TimeSpan TimeSinceSunSet = CalculateTheDifference(sunSetTime, curremtTime.TimeOfDay);

            double percentage = TimeSinceSunSet.TotalMinutes / sunSetToSunriseDuration.TotalMinutes;

            SunlightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis( SunlightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);

        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        maxMoonLightIntensity = Mathf.Lerp(maxMoonLightIntensity, 0 , lightChangeCurve.Evaluate(dotProduct));

        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

    private TimeSpan CalculateTheDifference(TimeSpan fromtime, TimeSpan totime)
    {
        TimeSpan diff = totime - fromtime;

        if(diff.TotalSeconds < 0) 
        {
            diff += TimeSpan.FromHours(24);           
        
        }

        return diff;
    }
}
