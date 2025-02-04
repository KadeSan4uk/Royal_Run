using UnityEngine;

public class PlayerCollisionHanrdler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
