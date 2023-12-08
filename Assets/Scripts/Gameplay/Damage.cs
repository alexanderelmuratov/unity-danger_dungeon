using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private string[] damageTags;
    [SerializeField] private int damage;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private string attackSfxKey;
    private Coroutine attackRoutine;
    private float attackTime = 0.5f;

    private IEnumerator AttackRoutine()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(attackSfxKey, transform.position));

        yield return new WaitForSeconds(attackTime);
        attackRoutine = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var tag in damageTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                var healthComponent = collision.gameObject.GetComponent<Health>();

                if (healthComponent)
                {
                    Instantiate(bloodPrefab, collision.collider.transform.position, Quaternion.identity);
                    healthComponent.Damage(damage);

                    if (attackRoutine == null)
                        attackRoutine = StartCoroutine(AttackRoutine());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in damageTags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                var healthComponent = other.gameObject.GetComponent<Health>();

                if (healthComponent)
                {
                    Instantiate(bloodPrefab, gameObject.transform.position, Quaternion.identity);
                    healthComponent.Damage(damage);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
