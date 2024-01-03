
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
   
    private Camera cam;

    [SerializeField]
    private bool followSmooth = true;
    
    [SerializeField]
    private float smoothSpeed = 0.125f;

    [SerializeField]
    private Vector3 offset;

   


    private void Start()
    {
        cam = Camera.main;
      
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            if (followSmooth)
            {
                Vector3 desiredPosition = player.transform.position + offset;
                Vector3 smothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smothedPosition;
            }

            else transform.position = player.transform.position;
        }
        
             
    }

}
