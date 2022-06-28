using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : Entities
{
    private Ray ray;

    public LayerMask mask;
    public GameObject point;

    public Vector3[] path;
    public LineRenderer lr;
    
    private bool MovAct = false;
    private NavMeshPath tempPath;
    private Vector3 endPoint;

    public GameObject inBatCan;
    public Text mainHP;

    public void Start()
    {
        tempPath = new NavMeshPath();
        cameraCam = Camera.main;
    }

    public void Action()
    {
        MovAct = true;

    }
    public override void StartBattle()
    {
        inBattle = true;
        this.GetComponent<movement>().enabled = false;
        inBatCan.SetActive(true);
        this.cStats.actionPoints = this.cStats.actionPoinsMax;
        APUpdate(0);
        APText.APUpadeate(cStats.actionPoinsMax);
    }

    private void FixedUpdate()
    {
        mainHP.text = "HP: " + cStats.HP +"/"+ cStats.maxHP;
        if (MovAct)
        {
            GameObject pointt = null;
            ray = cameraCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit,mask) == true)
            {
                lr.positionCount = 0;
                navMesh.CalculatePath(hit.point, tempPath);
                if (tempPath.corners.Length > 1)
                {
                    lr.positionCount = tempPath.corners.Length;

                    lr.SetPositions(tempPath.corners);

                }
            }
           

            //if (path.Length >= 1)
            //{
            //    lr.positionCount = path.Length;
            //    lr.SetPositions(path);
            //    if (transform.position == pointt.transform.position)
            //    {
                    
            //    }                
            //}
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            Ray ray2 = cameraCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hirt2;
            

            if (Physics.Raycast(ray2, out hirt2, mask) == true)
            {
                    Vector3 pos = hirt2.point; pos.y += 0.2f;
                    pointt = Instantiate(point, pos, Quaternion.identity);
            }
            StartCoroutine(this.UseSkill(pointt.transform));

            path = navMesh.path.corners;
            MovAct = false;
        }

        }
        

    }

    public float pathEndThreshold = 0.1f;
    private bool hasPath = false;
    bool AtEndOfPath()
    {
        hasPath |= navMesh.hasPath;
        if (hasPath && navMesh.remainingDistance <= navMesh.stoppingDistance + pathEndThreshold)
        {
            // Arrived
            hasPath = false;
            return true;
        }

        return false;
    }

    public override void EndBattle()
    {
        inBattle = false;
        inBatCan.SetActive(false);
        this.GetComponent<movement>().enabled = true;
    }
    public void takeDmg(int i)
    {
        cStats.HP -= i;
    }

    public void TrgAnimTouch()
    {
        charAnims.SetTrigger("Touch");
    }
    public void TrgAnimImpact()
    {
        charAnims.SetTrigger("Impact");
    }
    public void TrgAnimAttack()
    {
        charAnims.SetTrigger("Attack");
    }
}
