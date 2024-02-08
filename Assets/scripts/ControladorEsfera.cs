using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorEsfera : MonoBehaviour
{
    public float speed;

    public int contador;

    public TextMeshProUGUI text;

    public TextMeshProUGUI textfin;

    void Start()
    {
	    contador = 0;
	    updateCounter();
		textfin.text="";
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

		
///	 <summary>

/// OnTriggerEnter is called when the Collider other enters the trigger.

/// </ summary>

/// <param name="other">Ths other Collider involved in this collision.</param>



void OnTriggerEnter(Collider other)
{
if (other.tag == "pickup") {
Destroy(other.gameObject);
contador++;

updateCounter();
}
	}

void updateCounter()
{
	text.text = "Puntos: " + contador;

	int numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;

	if(numPickups == 1){
	textfin.text="Ganaste Buey!!! No te preocupaaare";
		}
	}
}

