using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collider2 : MonoBehaviour
{
    int pisteet = 0;
    // Start is called before the first frame update
    void Start()
    {
        Material mat = gameObject.GetComponent<Renderer>().material;
        mat.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveGameObject()
    {
        gameObject.transform.position = new Vector3(Random.Range(-2, 85), 1, Random.Range(-34, 54));
    }

    private void OnCollisionEnter(Collision collision)
    {
        MoveGameObject();
        Material mat = gameObject.GetComponent<Renderer>().material;
        if (mat.color == Color.blue)
        {
            mat.color = Color.red;
        } else if(mat.color == Color.red)
        {
            mat.color = Color.blue;
        }
        pisteet += 1;
        Debug.Log("Pisteesi tällä hetkellä: " + pisteet);
    }
}
