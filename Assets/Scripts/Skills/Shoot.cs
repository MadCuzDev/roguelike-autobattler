using UnityEngine;
using UnityEngine.AI;

namespace Skills
{
    public class Shoot : MonoBehaviour
    {
        public GameObject bullet;

        private NavMeshAgent navMeshAgent;
        private Camera cam;
        private Vector3 playerPos;
        private bool shotQueued;


        private void Start()
        {
            navMeshAgent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
            cam = Camera.main;
            playerPos = GameObject.Find("Player").transform.position;
        }
    
        private void Update()
        {
            if (navMeshAgent.remainingDistance < 10 && shotQueued)
            {
                Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
                shotQueued = false;
                Debug.Log("Shot at " + navMeshAgent.destination);
                navMeshAgent.ResetPath();
            }
        
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (Vector3.Distance(hit.point, playerPos) < 10)
                    {
                        navMeshAgent.ResetPath();
                        GameObject.Find("Player").transform.LookAt(hit.point);
                        var transformRotation = GameObject.Find("Player").transform.rotation;
                        transformRotation.x = 0;
                        transformRotation.z = 0;
                        GameObject.Find("Player").transform.rotation = transformRotation;
                        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
                        return;
                    }
                    navMeshAgent.SetDestination(hit.point);
                    shotQueued = true;
                    Debug.Log("Going to shoot at " + hit.point);
                }
            }
        }

    }
}
