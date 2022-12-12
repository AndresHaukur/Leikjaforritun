using UnityEngine;

/// <summary>
/// mun höndla það sem gerist þegar Ruby snertir HealthCollectible objectið.
/// </summary>
public class HealthCollectible : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
