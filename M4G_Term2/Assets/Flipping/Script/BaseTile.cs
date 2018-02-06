using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : MonoBehaviour {
    public GameObject basetile;
    public Vector2 array;
	
	void Start ()
    {
        for (int i = 0; i < array.x; i++)
        {
            for (int j = 0; j < array.y; j++)
            {
                Instantiate(basetile, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
	}

}
