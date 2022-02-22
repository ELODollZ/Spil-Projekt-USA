using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Made By Editor: Daniel M�nster Nybo (shooting/throwing scripts)
// Ændring af Tobias
// Ændring: Har sat et limit på hvor mange sten man kan kaste
public class Throwing : MonoBehaviour
{
    //Skaber variabler til at kalde i scripts, og sætter hastighed på speed, 
    [SerializeField]
    public GameObject rock;
    public Transform firePoint;
    public float throwingSpeed = 10;
    Vector2 lookDirection;
    float lookAngle;

    [SerializeField] private int CurrentRock;
    [SerializeField] private int MaxRock = 4;
    private int MinRock = 0;

    public Text rockDisplay;

    void Start()
    {
        CurrentRock = 1;  
    }
    void Update()
    {
        rockDisplay.text = CurrentRock.ToString();

        //Ved Space køres funktion af at kalde et objectclone Rock og sætter den ved firepoint.right og så en debug til udskrive i consolen at den faktisk kan tjekke om der bliver trykket på Space
        //Kalder også Rigidbody og sætter en veolcity på Rock clonerne som indsætters ved firePoint.
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentRock > MinRock)
            {
                //Sætter variablen lookDirection til main Camera og bruger Math til at udregne position til LookDirection og omregner fra radians til degres
                lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
                //lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

                firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

                GameObject rockClone = Instantiate(rock);
                rockClone.transform.position = firePoint.position;
                rockClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                rockClone.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * throwingSpeed;

                CurrentRock --;
            }
            else
            {
                Debug.Log("Out of ammo");
            }
        }
    }

    /*
    //variable og prefab
    public Transform KasteStartingsPladsForRock;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public GameObject rockPrefab;
    Transform firePoint;


    //skaber en der bliver kalder indholdet vært update i spillet.
    void Update()
    {

        //laver en funktion der trigger hver gang man trykker på "throwingRockButton1"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //kalder en anden funktion shoot.
            Shoot();
            Debug.Log("throwen");
        }
    }

    void Shoot()
    {
        //funktion der fremkalder et prefab og giver den bevægelse.
        Instantiate(rockPrefab, KasteStartingsPladsForRock.position, KasteStartingsPladsForRock.rotation);

    }
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(rockPrefab, gameObject.transform);
            Rock rock = go.GetComponent<Rock>();
            rock.targetVector = new Vector3(1, 1, 0);
        }
    }
    */

}
