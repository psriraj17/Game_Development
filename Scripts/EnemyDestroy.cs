using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public string PropertyName;

    public Material rend;
    private bool die = false;

    private float transparencyLevel;
    [SerializeField] private Renderer[] renderers = new Renderer[0];
    private float currentDis = 0f;
    private float targerDis = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Debug.Log("domndom");
            //transparencyLevel = 1f;
        }
    }

    void Update()
    {
        if (die) {
            currentDis = Mathf.Lerp(currentDis, targerDis, 0.1f * Time.deltaTime);
            foreach ( Renderer rendereer in renderers)
            {
                rendereer.material.SetFloat(PropertyName, currentDis);
            }

            // float currentValue = rend.GetFloat(PropertyName);
            // rend
            //     .SetFloat(PropertyName,
            //     Mathf.Lerp(currentValue, transparencyLevel, 0.5f * Time.deltaTime));

        }
    }

    private void OnDestroy()
    {
    }
    public void Die(){
        die = true;
        Debug.Log("die");
        //transparencyLevel = 1f;
        StartCoroutine(Kill());
    }

    private IEnumerator Kill() {
        Debug.Log("kill");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject,5f);
    }
}
