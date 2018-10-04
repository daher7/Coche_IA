using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrain : MonoBehaviour {

    [SerializeField] int speed = 20;
    [SerializeField] int speed_rotation = 5;
    int marcha = 1;
	
	void Start () {
		
	}
	
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime * speed * marcha);
        // Cuando vamos para atrás es cuando el coche gira.
        if (marcha == -1)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed_rotation);
        }
    }  

    // Detectamos la colisión del coche contra los muros
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("He colisionado con: " + collision.gameObject.tag);

        if(collision.gameObject.tag == "Pared")
        {
            // Colisiona con la pared
            marcha *= -1;
        }
        else if (collision.gameObject.tag == "Target")
        {
            // He encontrado el objetivo
            marcha = 0;
            Debug.Log("DAVID.HT HA ENCONTRADO EL OBJETIVO");
        }
    }
}
