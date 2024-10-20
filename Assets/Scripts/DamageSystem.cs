using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageSystem : MonoBehaviour
{
    public float _health = 0;
    bool oneTimeBool = false;

    public bool TakeHit(float damage, Transform transform)
    {
        _health = _health - damage;
        Handheld.Vibrate();
        AudioManager.instance.PlaySFX("Hit");

        if (_health <= 0 && !oneTimeBool)
        {
            oneTimeBool = true;

            transform.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("DestroyAfterTime", 0.1f);

            return false;
        }

        return false;
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject); 
    }

    private void OnDestroy()
    {
        GameManager.instance.UpdateGameState(GameState.Death);
    }
}
