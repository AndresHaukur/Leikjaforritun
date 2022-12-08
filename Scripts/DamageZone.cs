using UnityEngine;

/// <summary>
/// þessi scripta er tengd DamageZone objectinu sem er sett á skjáinn og þegar Ruby snertir það þá tekur hún skaða.
/// </summary>
public class DamageZone : MonoBehaviour 
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            // ef Ruby snertir DamageZone objectið þá tekur hún 1 af healthinu sínu.
            controller.ChangeHealth(-1);
        }
    }
}
