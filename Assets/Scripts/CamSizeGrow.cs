using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSizeGrow : MonoBehaviour
{
    private Camera cam;
    private PlayerMass playerMass;

    [SerializeField]
    private int treshIndex;
    [SerializeField]
    private float[] treshs;
   

    public bool changeCamSize, zoomOut, zoomIn;
    
    [SerializeField]
    private float growTime = 2;
    private float elapsedTime;

    public float currentSize;
    public float nextSize;
    public float previousSize;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        nextSize = 5;
        previousSize = .3f;
        treshIndex = 0;
        Debug.Log(treshs.Length);

        playerMass = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMass>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!changeCamSize)
        {
            if (treshIndex < treshs.Length-1)
            {
                if (playerMass.mass > treshs[treshIndex+1])
                {  
                    changeCamSize = true;
                    treshIndex++;

                    if (treshIndex != treshs.Length)
                    {
                        zoomOut = true;
                    }
                    else changeCamSize = false;

                }
            }
            if (treshIndex > 0)
            {
                if (playerMass.mass < treshs[treshIndex])
                { 
                    changeCamSize = true;
                    zoomIn = true;
                }
            }

          
        }

        if (changeCamSize)
        {
            if (zoomOut)
            {
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / growTime;

                cam.orthographicSize = Mathf.Lerp(treshs[treshIndex], treshs[treshIndex+1], percentageComplete);

                if (cam.orthographicSize >= treshs[treshIndex+1])
                {
                    cam.orthographicSize = treshs[treshIndex+1];
                    zoomOut = false;
                    changeCamSize = false;
                    elapsedTime = 0;
     
                }
            }

            else if (zoomIn)
            {
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / growTime;

                cam.orthographicSize = Mathf.Lerp(treshs[treshIndex+1], treshs[treshIndex], percentageComplete);

                if (cam.orthographicSize <= treshs[treshIndex])
                {
                    zoomIn = false;
                    changeCamSize = false;
                    elapsedTime = 0;
                    treshIndex--;
                }
            }

        }
    }
}
