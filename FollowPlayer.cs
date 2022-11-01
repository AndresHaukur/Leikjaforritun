using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // býr til breytu sem heitir player og gerir hana public svo hægt sé að breyta henni í unity
    private Vector3 offset = new Vector3(0, 5, -7); // býr til breytu sem heitir offset og setur hana sem Vector3 og gerir hana private svo hægt sé að breyta henni í unity
    
    // Start er kallað fyrir fyrsta rammann
    void Start() // þetta er fall sem er kallað í fyrsta ramma
    {
        
    }

    // Update er kallað í einu sinni í hverjum ramma
    void LateUpdate() // breytir update í Lateupdate svo það sé ekki lag í leiknum
    {   // Til að færa mynavel eftir leikmanni
        transform.position = player.transform.position + offset; // færi kameruna á eftir leikmanninum 
        transform.Translate(Vector3.right * Time.deltaTime); // færi kameruna á eftir leikmanninum
    }
}
