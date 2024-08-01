using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere_Settings : MonoBehaviour
{
    public GameObject paintpref;
    public GameObject particlepref;
    public float jumpheight = 3.5f;
    Vector3 PaintPoint;
    Animator anim;
    Rigidbody rigid;
    private List<GameObject> paintClones;
    public int maxClones = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        paintClones = new List<GameObject>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("RedCheese"))
        {
            Debug.Log("SphereİsDead");
            gameObject.SetActive(false);
            SceneManager.LoadScene("StartScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PaintPoint = collision.contacts[0].point;
            PaintPoint.y += 0.03f;

            GameObject newPaint = Instantiate(paintpref, PaintPoint, Quaternion.identity);
            newPaint.transform.parent = collision.gameObject.transform;

            GameObject newParticle = Instantiate(particlepref, PaintPoint, Quaternion.identity);
            newParticle.transform.parent = collision.gameObject.transform;
            newParticle.transform.localScale = new Vector3(1, 1, 1);
            newParticle.GetComponent<ParticleSystem>().Play();

            paintClones.Add(newPaint);

            Destroy(newParticle, 0.7f);

            if (paintClones.Count > maxClones)
            {
                GameObject oldPaint = paintClones[0];
                paintClones.RemoveAt(0);
                Destroy(oldPaint);
            }

            rigid.velocity = Vector3.up * jumpheight;
            AnimPlay();
        }
    }

    void AnimPlay()
    {
        anim.SetBool("Jump", true);
        StartCoroutine(ResetJumpAnimation());
    }

    void AnimStop()
    {
        anim.SetBool("Jump", false);
    }

    IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(0.40f);
        AnimStop();
    }
}
