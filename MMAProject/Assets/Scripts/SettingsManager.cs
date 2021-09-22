using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] GameObject camMove;
    Quaternion camRotate;
    Vector3 moveCam;

    [SerializeField] Slider runSpeedSlider;
    [SerializeField] Text runSpeedTxt;

    [SerializeField] Slider turnSpeedSlider;
    [SerializeField] Text turnSpeedTxt;

    [SerializeField] Slider diveTimeSlider;
    [SerializeField] Text diveTimeTxt;

    [SerializeField] Slider camXRotateSlide;
    [SerializeField] Slider camYRotateSlide;
    [SerializeField] Slider camZPos;

    public float runSpeed;
    public float turnSpeed;
    public float diveTime;

    public float camX;
    public float camY;
    public float moveZ;

    private void Awake()
    {
        moveZ = -13;
        camX = 30;
        camY = 0;
        camRotate = Quaternion.Euler(camX,camY,0);
        camMove.transform.rotation = camRotate;
        moveCam = new Vector3(0,5, moveZ);
        camMove.transform.position = moveCam;
        runSpeed = 5f;
        turnSpeed = 20f;
        diveTime = 5f;
    }

    private void Start()
    {
        SliderValue(runSpeedSlider, runSpeed, 0, 30);
        SliderValue(turnSpeedSlider, turnSpeed, 0, 50);
        SliderValue(diveTimeSlider, diveTime, 0.5f, 15);
        SliderValue(camXRotateSlide, camX, -180, 180);
        SliderValue(camYRotateSlide, camY, -180, 180);
        SliderValue(camZPos, moveZ, -13, 200);
    }

    private void FixedUpdate()
    {
        camMove.transform.rotation = camRotate;
        camMove.transform.position = moveCam;
        moveCam.z = moveZ;
        camRotate = Quaternion.Euler(camX, camY, 0);

        if (runSpeedSlider.value != runSpeed) 
        {
            runSpeed = runSpeedSlider.value;        
        }

        if (turnSpeedSlider.value != turnSpeed)
        {
            turnSpeed = turnSpeedSlider.value;
        }

        if (diveTimeSlider.value != diveTime)
        {
            diveTime = diveTimeSlider.value;
        }

        if (camXRotateSlide.value != camX) 
        {
            camX = camXRotateSlide.value;
        }

        if (camYRotateSlide.value != camY)
        {
            camY = camYRotateSlide.value;
        }

        if (camZPos.value != moveZ)
        {
            moveZ = camZPos.value;
        }

        TextRead();
    }

    public void TextRead() 
    {
        runSpeedTxt.text = "RunSpeed:" + (float)Math.Round(runSpeed, 1);
        turnSpeedTxt.text = "TurnSpeed:" + (float)Math.Round(turnSpeed, 1);
        diveTimeTxt.text = "DiveTime:" + (float)Math.Round(diveTime, 1);
    }

    private void SliderValue(Slider slide, float value, float minValue, float maxValue) 
    {
        slide.minValue = minValue;
        slide.maxValue = maxValue;
        slide.value = value;
    }
    private void OnOffObstacles(bool state) 
    {
        foreach (GameObject obj in obstacles)
        {
            obj.SetActive(state);
        }
    }

    public void ObstacleOn() 
    {
        OnOffObstacles(true);
    }

    public void ObstacleOff()
    {
        OnOffObstacles(false);
    }

    public void ResetCamPos() 
    {
        moveZ = -13;
        camX = 30;
        camY = 0;

        camXRotateSlide.value = camX;
        camYRotateSlide.value = camY;
        camZPos.value = moveZ;
    }
}