using System.Collections;
using UnityEngine;

public class DestroyingBlocksController : MonoBehaviour
{
    public float timeBeforeDestroy = 0.5f;
    public float timeToRegeneration = 2f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyingBlock"))
        {
            StartCoroutine(DestroyingBlock(collision.gameObject));
        }
    }
    
    IEnumerator DestroyingBlock(GameObject destroyingBlock)
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        destroyingBlock.SetActive(false);

        yield return new WaitForSeconds(timeToRegeneration);
        destroyingBlock.SetActive(true);
    }
}
