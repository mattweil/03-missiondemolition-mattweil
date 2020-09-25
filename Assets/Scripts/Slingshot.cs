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
	private Rigidbody projectileRigidbody;
    public float velocityMult = 8f;
	
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

       // projectile.transform.position = launchPos;

        // Set it to isKinematic for now

        projectileRigidbody = projectile.GetComponent<Rigidbody>();                // a

        projectileRigidbody.isKinematic = true; 

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
		if (!aimingMode) return;
		Vector3 mousePos2D = Input.mousePosition;                                  // c
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
        // Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D-launchPos;
        // Limit mouseDelta to the radius of the Slingshot SphereCollider          // d

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude) {

            mouseDelta.Normalize();

            mouseDelta *= maxMagnitude;

        }

        // Move the projectile to this new position

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;



        if ( Input.GetMouseButtonUp(0) ) {

            aimingMode = false;

            projectileRigidbody.isKinematic = false;

            projectileRigidbody.velocity = -mouseDelta * velocityMult;

            projectile = null;

        }

 
    }
}
