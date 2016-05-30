using UnityEngine;
using System.Collections;

public class sketch : MonoBehaviour {

    public GameObject myPrefab;

	// Use this for initialization
	void Start () {

        int totalCubes = 12;

        int totalDistance = 5;

        for ( int i =0; i<6; i++)
        {
            float perc = i / (float)totalCubes;
            float sin = Mathf.Sin(perc *Mathf.PI/2);
            
            float x = 1.0f +Sin *totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<cubescript>().SetSize(1f * (1.0f-perc));
            newCube.GetComponent<cubescript>().rotateSpeed =0.2f + perc*4.0f; 
        }
       
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
