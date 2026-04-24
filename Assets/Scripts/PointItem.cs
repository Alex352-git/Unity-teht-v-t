using UnityEngine;

public class PointItem : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.AddScore(points);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.AddScore(points);
            Destroy(gameObject);
        }
    }
}