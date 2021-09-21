using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;

    public float boatSpeed;
    public float runSpeed;

    public float boatTurnSpeed;
    public float turnSpeed;

    public float underWater;
    public float diveTime;

    //public float cameraMoveX;
    //public float camX;

    //public float cameraMoveY;
    //public float camY;

    Rect box;
    Rect btn1;
    Rect btn2;
    Rect slider1;
    Rect slider2;
    Rect slider3;
    //Rect slider4;
    //Rect slider5;

    GUISkin skinGui;
 
    //the GUI scale ratio
    private float guiRatioX;
    private float guiRatioY;
    //the screen width
    private float sWidth;
    private float sHeight;
    //A vector3 that will be created using the scale ratio
    private Vector3 GUIsF;
    float sizegui;
    

        

    private void Awake()
    {
        runSpeed = 5f;
        turnSpeed = 20f;
        diveTime = 5f;
        /*
        box = new Rect(2, 640, 150, 250);
        btn1 = new Rect(4, 640, 100, 20);
        btn2 = new Rect(4, 665, 100, 20);
        slider1 = new Rect(8, 705, 100, 5);
        slider2 = new Rect(8, 730, 100, 5);
        slider3 = new Rect(8, 755, 100, 5);
        */

        box = new Rect(2, 400, 150, 550);
        btn1 = new Rect(4, 402, 148, 100);
        btn2 = new Rect(4, 500, 148, 100);
        slider1 = new Rect(8, 620, 142, 150);
        slider2 = new Rect(8, 740, 142, 150);
        slider3 = new Rect(8, 860, 142, 150);
        //slider4 = new Rect(8, 780, 100, 5);
        //slider5 = new Rect(8, 805, 100, 5);

        //get the screen's width
        sWidth = Screen.width;
        sHeight = Screen.height;
        //calculate the rescale ratio
        guiRatioX = sWidth / 1920 * sizegui;
        guiRatioY = sHeight / 1080 * sizegui;
        //create a rescale Vector3 with the above ratio
        GUIsF = new Vector3(guiRatioX, guiRatioY, 1f);
    }
 
    public void OnOffObstacles(bool state) 
    {
        foreach (GameObject obj in obstacles)
        {
            obj.SetActive(state);
        }
    }

    private void OnGUI()
    {
        //GUI.skin = skinGui;

        //GUI.matrix = Matrix4x4.TRS(new Vector3(GUIsF.x, GUIsF.y, 0f), Quaternion.identity, GUIsF);
        GUI.Box(box,"");

        if (GUI.Button(btn1,"ObstacleOn")) 
        {
            OnOffObstacles(true);
        }

        if (GUI.Button(btn2,"ObstaclesOff"))
        {
            OnOffObstacles(false);
        }

        GUI.Label(new Rect(8, 600, 100, 25),"BoatSpeed");

        boatSpeed = GUI.HorizontalSlider(slider1, runSpeed, 0.0f, 50f);
        if (boatSpeed != runSpeed) 
        {
            runSpeed = boatSpeed;
        }

        GUI.Label(new Rect(8, 720, 100, 25), "TurnSpeed");

        boatTurnSpeed = GUI.HorizontalSlider(slider2, turnSpeed, 80f, 0.0f);
        if (boatTurnSpeed != turnSpeed)
        {
            turnSpeed = boatTurnSpeed;
        }

        GUI.Label(new Rect(8, 840, 100, 25), "DiveTime");

        underWater = GUI.HorizontalSlider(slider3, diveTime, 0.0f, 15f);
        if (underWater != diveTime)
        {
            diveTime = underWater;
        }

        /*
        GUI.Label(new Rect(8, 738, 100, 20), "CameraRotateY");
        underWater = GUI.HorizontalSlider(slider4, diveTime, 0.0f, 15f);
        if (underWater != diveTime)
        {
            diveTime = underWater;
        }

        GUI.Label(new Rect(8, 738, 100, 20), "CameraRotateX");
        underWater = GUI.HorizontalSlider(slider5, diveTime, 0.0f, 15f);
        if (underWater != diveTime)
        {
            diveTime = underWater;
        }
        */
    }
}