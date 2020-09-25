using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
	
	public GameObject launchPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    void Awake() {

        Transform launchPointTrans = transform.Find("LaunchPoint");        
        launchPoint = launchPointTrans.gameObject;

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
