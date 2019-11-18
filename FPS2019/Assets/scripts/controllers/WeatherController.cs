﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;
    private float _fullIntensity;
    //private float _cloudValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _fullIntensity = sun.intensity;
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    // Update is called once per frame
    void Update()
    {
        //SetOvercast(_cloudValue);
        //_cloudValue += .005f;
    }

    private void OnWeatherUpdated()
    {
        SetOvercast(Managers.Weather.cloudValue);
    }

    private void SetOvercast(float value)
    {
        if (value <= 1)
           sky.SetFloat("_Blend", value);
        sun.intensity = _fullIntensity - (_fullIntensity * value);
    }
}
