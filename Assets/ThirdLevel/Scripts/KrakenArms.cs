using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KrakenArms : MonoBehaviour
{
    public GameObject arm,rock;
    public Transform[] points;

    public float upVeloctiy,Force;

    private KrakenArmRock armRock;
    void Start()
    {
        ArmSpawn();
        armRock = GameObject.FindGameObjectWithTag("krakenArm").GetComponent<KrakenArmRock>();
    }

    private void ArmSpawn()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        for (int i = 0; i < points.Length; i++)
        {
            
            GameObject arms = Instantiate(arm,points[i].position,Quaternion.identity);
            arms.transform.Rotate(180,0,0);
            arms.transform.DOMoveY(-2.5f, 1f).OnComplete(() =>
            {
                arms.transform.DOMoveY(-2.5f, 2f).OnComplete(() =>
                {

                    arms.transform.DOMoveY(-10, 2f).OnComplete(() =>
                    {
                        Destroy(arms);
                    });
                }); 
            });
            
            yield return new WaitForSeconds(5f);

        }
        ArmSpawn();

    }


   
}
