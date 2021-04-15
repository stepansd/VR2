using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGAZE : MonoBehaviour
{
    public Image imGaze;
    public int distanceOfRay = 10;
    public Transform teleport;
    float vrTimer;
    bool vrStatus;
    public float totalTime=2;
    private RaycastHit hit;

    public void VrOn()
    {
        vrStatus = true;
    }
    public void VrOff()
    {
        vrStatus = false;
        vrTimer = 0;
        imGaze.fillAmount = 0;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        imGaze.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (vrStatus)
        {
            vrTimer += Time.deltaTime;
            imGaze.fillAmount = vrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));//sozdali luch
        
        if (Physics.Raycast(ray, out hit, distanceOfRay)) //esli stolknetsa
        {
            if (hit.transform.tag == "TP" && imGaze.fillAmount == 1) //pokazali s kakim objektom dolzhen stolknutsa
            {
                hit.transform.GetComponent<Teleport>().Teleporting();
            }
        }
    }
}
