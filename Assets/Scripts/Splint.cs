using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splint : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    [SerializeField] private GameObject splintFire;
    private ParticleSystem splintFirePart;
    private bool onFire = false;

    private bool coveredInSolution = false;

    void Start()
    {
        part = FireParticles.particlesManager.particles;
        collisionEvents = new List<ParticleCollisionEvent>();
        splintFirePart = transform.GetChild(0).GetComponent<ParticleSystem>();
        
        splintFirePart.Stop();
    }

    private void OnParticleCollision(GameObject other) {
        //Spawn particles
        if (coveredInSolution)
        {
            Debug.Log("Particles touched");
            if (part.GetCollisionEvents(gameObject, collisionEvents) > 0)
            {
                StopAllCoroutines();
                splintFirePart.Play();
                splintFire.transform.position = collisionEvents[0].intersection;
                onFire = true;

            }
            else
            {
                if (!onFire)
                {
                    StartCoroutine(SetParticlesFalse());
                }
                onFire = false;
            }
        }
    }
    private IEnumerator SetParticlesFalse()
    {
        yield return new WaitForSeconds(1);
        splintFirePart.Stop();
    }
    public void CoverInSolution(Solution solution)
    {
        coveredInSolution = true;
        var colorOverLifeTimeModule = splintFirePart.colorOverLifetime;
        colorOverLifeTimeModule.color = solution.getBurnColor();
    }
}
