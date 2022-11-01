using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f; // setur hraðann á leikmanninum í 20 og gerir það public svo það er hægt að breyta því í unity
    private float turnSpeed = 45.0f; // býr til breytu sem heitir turnSpeed og gerir hana public svo hægt sé að breyta henni í unity
    private float horizontalInput; // býr til breytu sem heitir horizontalInput og gerir hana public svo hægt sé að breyta henni í unity
    private float forwardInput; // býr til breytu sem heitir forwardInput og gerir hana public svo hægt sé að breyta henni í unity


    // Start er kallað fyrir fyrsta rammann
    void Start()
    {
        
    }

    // Update er kallað í einu sinni í hverjum ramma
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // býr til breytu sem heitir horizontalInput og setur hana sem input á horizontal axis
        forwardInput = Input.GetAxis("Vertical"); // býr til breytu sem heitir forwardInput og setur hana sem input á vertical axis


        // hérna færum við farartækið áfram
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // færi leikmanninum áfram
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); // snýr leikmanninum og lætur hann ekki renna eftir gólfinu

    }
}
