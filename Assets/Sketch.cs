using UnityEngine;
using Pathfinding.Serialization.JsonFx;
using System.Collections;

public class Sketch : MonoBehaviour {

    public GameObject myPrefab;
    string _WebsiteURL = "http://cutedoraemon.azurewebsites.net/swagger";

    void Start () {
        string jsonResponse = Request.GET(_WebsiteURL);

        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        Product[] product = JsonReader.Deserialize<Product[]>(jsonResponse);
        
        int totalCubes = product.Length;
        int totalDistance = 10;
        int i = 0;
        foreach (Product Product in product)
        {
            float perc = i / (float)totalCubes;
            i++;
            float x = perc * totalDistance;
            float y = 10.0f;
            float z = 0.0f;
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3( x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeCode>().SetSize((1.0f - perc) *2);
            newCube.GetComponent<CubeCode>().RotateSpeed = perc;
            newCube.GetComponentInChildren<TextMesh>().text = product.ProductName;
        }        
	}
	
	void Update () {
	
	}
}
