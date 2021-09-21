using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] GameObject boatSkin;
    [SerializeField] Material RedSkin;
    [SerializeField] Material YellowSkin;
    [SerializeField] Material GreenSkin;

    public void changeRed() 
    {
        boatSkin.GetComponent<MeshRenderer>().material = RedSkin;
    }

    public void changeYellow()
    {
        boatSkin.GetComponent<MeshRenderer>().material = YellowSkin;
    }

    public void changeGreen()
    {
        boatSkin.GetComponent<MeshRenderer>().material = GreenSkin;
    }
}
