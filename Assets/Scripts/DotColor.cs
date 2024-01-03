using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotColor : MonoBehaviour
{
    public SpriteRenderer dot;

    public bool consumeble = true;
    private float timer = 8;

    ColorsInGame colorsInGame;
    public int colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        colorsInGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<ColorsInGame>();
        dot = GetComponent<SpriteRenderer>();

        if (consumeble)
        {
            colorIndex = Random.Range(0, colorsInGame.dotColor.Length - 1);
            dot.color = colorsInGame.dotColor[colorIndex];
        }   
    }

    private void Update()
    {
        if (!consumeble)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                consumeble = true;
                GainColor();
            }
            

        }
    }
    public void GainColor()
    {
        colorIndex = Random.Range(0, colorsInGame.dotColor.Length - 1);

        dot.color = colorsInGame.dotColor[colorIndex];
    }


}
