using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;

    private void Start()
    {
        if(target != null) 
        { 
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Controleer of het projectiel het doelwit heeft bereikt
        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            
            // Vernietig het projectiel
            Destroy(gameObject);
        }
    }
}