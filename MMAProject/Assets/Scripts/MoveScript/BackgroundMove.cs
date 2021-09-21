using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] SettingsManager settings;

    private float speed;
    public bool movingBG;

    internal bool resetBGPos;
    Vector3 position;

    private void Start()
    {
        speed = settings.runSpeed;
        position = new Vector3(0, 0, 0);
    }
    private void FixedUpdate()
    {
        speed = settings.runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingBG)
            transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (resetBGPos) 
        {
            transform.position = position;
            speed += 0.03f;
            resetBGPos = false;
        }        
    }
}
