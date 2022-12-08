using UnityEngine;

/// <summary>
/// Höndlar það sem gerist þegar Ruby snertir Projectile objectið.
/// </summary>
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // eyðir projectile objectinu ef það fer of langt frá player objectinu.
        if(transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    // kallað á af ProjectileLauncher objectinu til að senda projectile objectið í ákveðna átt.
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy e = other.collider.GetComponent<Enemy>();

        // ef Ruby snertir Enemy objectið þá tekur hún 1 af healthinu sínu.
        if (e != null)
        {
            e.Fix();
        }
        
        Destroy(gameObject);
    }
}
