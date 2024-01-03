using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{
    public float mass;
    public bool consumed;

    public bool SetVariables;

    private Color playerColor;
    private Color oldColor;
    private Vector3 playerPos;
    private Vector3 startPos;
    private float elapsedTime;
    public float consumeTime = 0.5f;
    private float oldMass, disiredMass;
    




    private void Start()
    {
        float playerMass = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMass>().mass;

        if (GetComponent<DotColor>().consumeble)
        {
            mass = Random.Range((playerMass / 2), (playerMass * 1.25f));
        }
        else mass = Random.Range((playerMass / 10), (playerMass / 20)); ;
       
        transform.localScale = new Vector3(mass, mass, 1);

    }

    private void Update()
    {
        if (consumed)
        {
            
            if (!SetVariables)
            {
                startPos = transform.position;
                
                playerColor = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color;
                oldColor = GetComponent<SpriteRenderer>().color;
                oldMass = mass;
                disiredMass = 0.3f;
                SetVariables = true;
            }
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / consumeTime;

            transform.position = Vector3.Lerp(startPos, playerPos, percentageComplete);
           
            mass = Mathf.Lerp(oldMass, disiredMass, percentageComplete);
            transform.localScale = new Vector3(mass, mass, 1);
            GetComponent<SpriteRenderer>().color = Color.Lerp(oldColor, playerColor, elapsedTime*4);

            if (mass <= disiredMass)
            {
                Destroy(gameObject);
            }






            // move dot towar player center
            // change dotcolor to players color
            // shrink dot as Player grow
            // destroy dot when in center
        }
    }

}