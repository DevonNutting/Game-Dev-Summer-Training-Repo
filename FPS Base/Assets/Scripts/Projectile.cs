using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Target":
                Debug.Log("TARGET");
                Destroy(this.gameObject);
                break;

            case "Wall":
                Debug.Log("WALL");
                Destroy(this.gameObject);
                break;

            default:
                break;
        }
    }
}
