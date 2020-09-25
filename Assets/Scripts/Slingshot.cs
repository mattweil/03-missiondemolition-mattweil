using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
	[Header("Set in Inspector")]
	public GameObject prefabProjectile;
	
    [Header("Set Dynamically")]                                            
    public GameObject launchPoint;
    public Vector3 launchPos;                                   
    public GameObject projectile;                             
    public bool aimingMode;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    void Awake() {
        Transform launchPointTrans = transform.FindChild("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive( false );
        launchPos = launchPointTrans.position;   

    }
	
    void OnMouseDown() {                         

        // The player has pressed the mouse button while over Slingshot

        aimingMode = true;

        // Instantiate a Projectile

        projectile = Instantiate( prefabProjectile ) as GameObject;

        // Start it at the launchPoint

        projectile.transform.position = launchPos;

        // Set it to isKinematic for now

        projectile.GetComponent<Rigidbody>().isKinematic = true;

    }
	
    void OnMouseEnter() {
		launchPoint.SetActive( true );
        print("Slingshot:OnMouseEnter()");

    }



    void OnMouseExit() {

        print("Slingshot:OnMouseExit()");
		launchPoint.SetActive( false );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
