using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected GameObject hitVFX;
    // [SerializeField] AudioData[] hitSFX;
    [SerializeField] protected float damage;
    [SerializeField] protected float moveSpeed = 10f;

    [SerializeField] protected Vector2 moveDirection;
    ContactPoint2D[] contacts = new ContactPoint2D[2];
    // public UnityEvent OnAttackPeformed;
    // public Transform circleOrigin;
    // public float radius;


    protected GameObject target;

    protected virtual void OnEnable() 
    {
        StartCoroutine(MoveDirectlyCoroutine());
    }
    
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Character>(out Character character))
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation ;
            character.TakeDamage(damage);
            Debug.Log(character.gameObject.name + "damaged");

            // var contactPoint = collision.GetContact(0);
            PoolManager.Release(hitVFX, collision.GetContact(0).point, Quaternion.LookRotation(collision.GetContact(0).normal));
            // AudioManager.Instance.PlayRandomSFX(hitSFX);
            // gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.TryGetComponent<Character>(out Character character))
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            
        }
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.gameObject.TryGetComponent<Character>(out Character character))
    //     {
    //         // GetPointOfContact();
    //         other.GetContacts(contacts);
    //         Vector3 normal = contacts[0].normal;


            
    //         character.TakeDamage(damage);
    //         Debug.Log(character.gameObject.name + "damaged");

    //         // var contactPoint = collision.GetContact(0);
    //         PoolManager.Release(hitVFX, other.ClosestPoint(transform.position), Quaternion.LookRotation(normal));
    //         // AudioManager.Instance.PlayRandomSFX(hitSFX);
    //         // gameObject.SetActive(false);
    //     }
    // }

    // private Vector3 GetPointOfContact()
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, transform.forward, out hit))
    //     {
    //         return hit.point;
    //     }
    //     return Vector3.zero;
    // }

    IEnumerator MoveDirectlyCoroutine()
    {
        while(gameObject.activeSelf)
        {
            Move();
            yield return null;
        }
    }
    // public void TriggerAttack()
    // {
    //     OnAttackPeformed?.Invoke();
    // }

    // protected void SetTarget(GameObject target) => this.target = target;

    public void Move() => transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
}
