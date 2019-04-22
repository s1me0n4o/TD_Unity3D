using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    [SerializeField] float speed = 70f;
    private float distanceFactor = 1f;

    public static bool isCollided = false;

    public void SeekTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
           return;
        }
        Vector3 dir = target.position - this.transform.position;
        float distanceThisFrame = distanceFactor * speed * Time.deltaTime;

        //normalized -> however close we are to the target doesnt have effect on how fast we are moving, bcs it should move with const speed
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        //check for overshoot (in order to hit the bullet move pats the target)
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        Destroy(gameObject, 3.5f); //TODO think about something smarter!
    }

    private void HitTarget()
    {
        Destroy(gameObject);
        isCollided = true;
        target.SendMessage("Collided", isCollided); //string refference with EnemyDamage
    }
}
