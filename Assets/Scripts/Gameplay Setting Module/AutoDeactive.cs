using System.Collections;
using UnityEngine;

public class AutoDeactive : MonoBehaviour
{
    [SerializeField] bool destroyGameObject;
    [SerializeField] float lifeTime = 3f;
    WaitForSeconds waitLifeTime;

    private void Awake() 
    {
        waitLifeTime = new WaitForSeconds(lifeTime);
    }

    private void OnEnable() 
    {
        StartCoroutine(DeactivateCoroutine());
    }

    IEnumerator DeactivateCoroutine()
    {
        yield return waitLifeTime;

        if(destroyGameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
