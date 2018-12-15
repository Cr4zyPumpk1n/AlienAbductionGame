using UnityEngine;

public class Interacable : MonoBehaviour
{
    // Defining the radius the player can interact with the object
    public float radius = 5f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
