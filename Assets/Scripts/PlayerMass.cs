using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMass : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI massDisplay;

    public float mass;
    private float disiredMass;

    private float oldMass;
    public float newMass;
    private float elapsedTime;
    
    public float growTime;

    public bool changeSize, grow, shrink;

    public CamFollowPlayer cam;


    private void Start()
    {
        mass = 1;
        newMass = mass;

        transform.localScale = new Vector3(mass, mass, 1);
        massDisplay.text = mass.ToString("0.00");

    }

    private void Update()
    {
        if (changeSize)
        {
            if (grow)
            {
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / growTime;

                mass = Mathf.Lerp(oldMass, disiredMass, percentageComplete);
                transform.localScale = new Vector3(mass, mass, 1);
                massDisplay.text = mass.ToString("0.00");

                if (mass >= disiredMass) 
                {
                    mass = disiredMass;
                    grow = false;
                    elapsedTime = 0;
                    changeSize = false;

                    if (mass != newMass)
                    {
                        ChangeizeOnPlayerMass(newMass);
                    }

                }
            }
            else if (shrink)
            {
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / growTime;

                mass = Mathf.Lerp(oldMass, newMass, percentageComplete);
                transform.localScale = new Vector3(mass, mass, 1);
                massDisplay.text = mass.ToString("0.00");

                if (mass <= disiredMass)
                {
                    mass = disiredMass;
                    shrink = false;
                    elapsedTime = 0;
                    changeSize = false;

                    if (mass != newMass)
                    {
                        ChangeizeOnPlayerMass(newMass);
                    }

                }
            }
        }
        
    }

    public void ChangeizeOnPlayerMass(float _newMass)
    {
        newMass = _newMass;

        if (changeSize != true)
        {
            changeSize = true;
            oldMass = mass;
            disiredMass = newMass;

            if (oldMass < disiredMass)
            {
                grow = true;

            }
            else shrink = true;
        }

    }
}