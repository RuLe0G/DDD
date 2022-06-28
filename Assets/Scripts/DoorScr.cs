using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScr : MonoBehaviour
{
    public GameObject brokenObj;
    public Animator animator;
    public CharStats stat;

    public bool isLock;

    public bool isOpen;


    public UnityEngine.AI.NavMeshObstacle obstacle;
    public IEnumerator DestroyDoor()
    {
        yield return new WaitForSeconds(2);
        brokenObj.SetActive(true);
        Destroy(gameObject);

        //Instantiate(brokenObj,transform.position,transform.rotation);


        
    }

    public Player plr;
    public void tryOpen()
    {
        if (isLock)
        {
            if (stat.STR > 15)
                StartCoroutine(DestroyDoor());
            else
            {
                StartCoroutine(DestroyDoor());
                plr.takeDmg(Random.Range(1,3));
            }
        }
        else
        {
            FlipOpen();
        }    
    }

    public void FlipOpen()
    {
        if (!isOpen)
        {
            obstacle.center = new Vector3(obstacle.center.x, obstacle.center.y +100 ,obstacle.center.z);
            animator.SetBool("Open_close", true);
            isOpen = true;
            
        }
        else
        {
            animator.SetBool("Open_close", false);
            isOpen = false;
            obstacle.center = new Vector3(obstacle.center.x, obstacle.center.y - 100, obstacle.center.z);
        }
    }
}
