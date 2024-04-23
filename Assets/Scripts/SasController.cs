using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SasController : MonoBehaviour
{

    [SerializeField] private bool needKey = false;

    private Animator mAnimator;
    private Collider mCollider;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mCollider = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider collider)
    {

        //if the collider is the player
        if (collider.gameObject.tag == "Player")
        {
            if (mAnimator != null)
            {
                if(needKey)
                {
                    if (GameManager.instance.hasKey)
                    {
                        StartCoroutine(Open());
                    }
                    return;
                }

                StartCoroutine(Open());

            }
            
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //if the collider is the player
        if (collider.gameObject.tag == "Player")
        {
            if (mAnimator != null)
            {
                if(needKey)
                {
                    if (GameManager.instance.hasKey)
                    {
                        StartCoroutine(Close());
                    }
                    return;
                }

                StartCoroutine(Close());

            }
        }
    }

    IEnumerator Open()
    {

        // Play the animation
        mAnimator.SetTrigger("TrOpen");

        yield return new WaitForSeconds(1.0f);
        mCollider.enabled = false;

    }

    IEnumerator Close()
    {

        // Play the animation
        mAnimator.SetTrigger("TrClose");

        yield return new WaitForSeconds(1.0f);
        mCollider.enabled = true;

    }
}
