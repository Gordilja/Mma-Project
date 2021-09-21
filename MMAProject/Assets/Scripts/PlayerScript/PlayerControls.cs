using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;
    [SerializeField] AudioManager audioManager;
    [SerializeField] SwipeControls swipeControl;
    [SerializeField] SettingsManager settings;
    float turnSpeedIn;
    bool submerged;
    Vector3 Vz;
    Vector3 Vy;
    Vector3 Vx;
    public float diveTime;

    private void Start()
    {
        submerged = false;
        turnSpeedIn = settings.turnSpeed;
        diveTime = settings.diveTime;
        Vy = new Vector3(0, -0.03f, 0);
        Vx.x = transform.position.x;
        Vz = new Vector3(0, 0, -5f);
    }

    private void FixedUpdate()
    {
        turnSpeedIn = settings.turnSpeed;
        diveTime = settings.diveTime;

        Vx.x = transform.position.x;
        Vz.z = transform.position.z;
        if (!submerged)
        {
            Vy.y = -0.03f;
            transform.position = new Vector3(Vx.x, Vy.y, Vz.z);
        }
        else 
        {
            Vy.y = transform.position.y;
        }
    }

    public void TouchControl()
    {
        if (swipeControl.swipeLeft)
        {
            if (Vx.x == 0 || Vx.x <= 1.5f || Vx.x >= -1.5f)
            {
                transform.DOMove(new Vector3(-2.5f, Vy.y, Vz.z), turnSpeedIn * Time.deltaTime);
                transform.DORotate(new Vector3(0, -45f, 0), turnSpeedIn * Time.deltaTime).OnComplete(() => { transform.DORotate(new Vector3(0, 0, 0), turnSpeedIn * Time.deltaTime); });
            }

            if (Vx.x == 2.5f || Vx.x >= 1.5f)
            {
                transform.DOMove(new Vector3(0, Vy.y, Vz.z), turnSpeedIn * Time.deltaTime);
                transform.DORotate(new Vector3(0, -45f, 0), turnSpeedIn * Time.deltaTime).OnComplete(() => { transform.DORotate(new Vector3(0, 0, 0), turnSpeedIn * Time.deltaTime); });
            }

            if (Vx.x == -2.5 || Vx.x <= -2f)
            {
                Debug.Log("Cant move to left!");
            }
        }
        else if (swipeControl.swipeRight)
        {
            if (Vx.x >= 0 || Vx.x <= 1.5f)
            {
                transform.DOMove(new Vector3(2.5f, Vy.y, Vz.z), turnSpeedIn * Time.deltaTime);
                transform.DORotate(new Vector3(0, 45f, 0), turnSpeedIn * Time.deltaTime).OnComplete(() => { transform.DORotate(new Vector3(0, 0, 0), 10f * Time.deltaTime); });
            }

            if (Vx.x == -2.5f || Vx.x <= -1.5f)
            {
                transform.DOMove(new Vector3(0, Vy.y, Vz.z), turnSpeedIn * Time.deltaTime);
                transform.DORotate(new Vector3(0, 45f, 0), turnSpeedIn * Time.deltaTime).OnComplete(() => { transform.DORotate(new Vector3(0, 0, 0), 10f * Time.deltaTime); });
            }

            if (Vx.x <= 2.5 || Vx.x >= 2f)
            {
                Debug.Log("Cant move to right!");
            }
        }
    
    }

    public void WaveUpCollide() 
    {
        StartCoroutine(WaveUp());
    }

    IEnumerator WaveUp()
    {
        playerScript.controls = false;
        audioManager.waveUpPlay();
        audioManager.splashPlay();
        transform.DOMove(new Vector3(playerScript.waveUpPos.x, 2, Vz.z), turnSpeedIn * Time.deltaTime).OnComplete(() => { transform.DOMove(new Vector3(Vx.x, -1, Vz.z), turnSpeedIn * Time.deltaTime); });
        transform.DORotate(new Vector3(-40f, 0, 0), turnSpeedIn * Time.deltaTime).OnComplete(() => { transform.DORotate(new Vector3(0, 0, 0), 0.1f * Time.deltaTime); });
        audioManager.bdDiveUnmute();
        audioManager.bdDivePlay();
        yield return new WaitForSeconds(0.5f);
        submerged = true;
        playerScript.controls = true;
        yield return new WaitForSeconds(diveTime);
        audioManager.bdDiveMute();
        transform.DOMove(new Vector3(Vx.x, -0.03f, Vz.z), turnSpeedIn * Time.deltaTime);
        submerged = false;
    }

    public void ResetPosition() 
    {
        Vx.x = 0;
        Vy.y = -0.03f;
        Vz.z = -5;
        transform.position = new Vector3(Vx.x, Vy.y, Vz.z);
    }
}