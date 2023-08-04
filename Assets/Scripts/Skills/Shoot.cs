using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Skills
{
    public class Shoot : MonoBehaviour
    {
        public GameObject bullet;

        private Camera cam;
        private Vector3 playerPos;
        
        public Vector3 target;
        public float rotationSpeed = 5f;

        private bool isRotating = false;


        private void Start()
        {
            cam = Camera.main;
            playerPos = GameObject.Find("Player").transform.position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    target = hit.point;
                    StartRotationCoroutine();
                    Debug.Log("Going to shoot at " + hit.point);
                }
            }
        }
        
        private void StartRotationCoroutine()
        {
            if (target != null)
            {
                StartCoroutine(RotateTowardsTarget());
            }
        }

        private IEnumerator RotateTowardsTarget()
        {
            isRotating = true;

            var startRotation = transform.rotation;
            var targetRotation = Quaternion.LookRotation(target - transform.position);

            var elapsedTime = 0f;

            while (elapsedTime < 1f)
            {
                elapsedTime += Time.deltaTime * rotationSpeed;
                var rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
                rotation.x = 0;
                rotation.z = 0;
                GameObject.Find("Player").gameObject.transform.rotation = rotation;
                yield return null;
            }

            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation,
                gameObject.transform);
            
            isRotating = false;
        }
    }
}
