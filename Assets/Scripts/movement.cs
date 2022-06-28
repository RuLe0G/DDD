    using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    public bool alive = true;
    private NavMeshAgent _agent;
    [SerializeField]
    [Range(1f, 400f)]
    private float mSpeed = 4;
    [SerializeField]
    [Range(1f, 500f)]
    private float aSpeed = 100;

    [SerializeField]
    private bool _select = true;

    [SerializeField]
    private Transform _point;

    public LayerMask _mask;
    public LayerMask _pointmask;
    public Camera _cam;

    public Animator animator;



    void Start()
    {
        _cam = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = mSpeed;
        _agent.angularSpeed = aSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {

        
            if (_agent.remainingDistance <= _agent.stoppingDistance) { animator.SetBool("movSpeed", false); };

            if (_select == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) == true)
                {
                    Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray,out hit, _mask) == true)
                    {
                        Vector3 pos = hit.point; pos.y += 0.2f;
                        Instantiate(_point, pos, Quaternion.identity);
                    }
                    attract();
                }

            
            }
        }
    }

    void attract()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, 1000f, _pointmask);

        if (hits.Length > 0)
        {
            Vector3 target = hits.Last().transform.position;

            for (int i = 0; i < hits.Length - 1; i++)
            {
                Destroy(hits[i].gameObject);
            }

            foreach (Collider h in hits)
            {
                if (h != hits.Last())
                {
                    Destroy(h.gameObject);
                }
            }
            _agent.velocity = Vector3.zero;
            _agent.SetDestination(target);
            animator.SetBool("movSpeed", true);
        }
        else
        {
            _agent.isStopped = true;
            _agent.ResetPath();
            animator.SetBool("movSpeed", false);
        }
    }
}