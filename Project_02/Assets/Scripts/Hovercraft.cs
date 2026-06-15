using UnityEngine;

/*
 *  This is an enum to signify what the car type is. 
 */
public enum craft_type
{ 
    average,
    fast,
    cornering
}


///
/*   This is the class file for the hovercraft
 * 
 * 
 * 
 */
///

public class Hovercraft : MonoBehaviour
{
    // Hoverecraft Variables
    public craft_type type = craft_type.average;
    public GameObject laserPrefab;
    public Transform shootPoint_01;
    public Transform shootPoint_02;

    void Update()
    {
        
    // shoot laser from average craft by pressing space
        if(type == craft_type.average)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Laser Fired!");
                laser_shot();
            }
        }
    }

    // TODO: Lazers
    public void laser_shot()
    { 
       Instantiate(
            laserPrefab, 
            shootPoint_01.position, 
            shootPoint_01.rotation
        );

        Instantiate(
            laserPrefab,
            shootPoint_02.position,
            shootPoint_02.rotation
        );
    }

    
    
}



