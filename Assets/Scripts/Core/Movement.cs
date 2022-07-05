using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Core
{
  public class Movement : MonoBehaviour
  {
    [SerializeField] private AudioSource flyingSFX;
    private Transform _body;

    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private NavMeshAgent _navMeshAgent;
    private CharacterController _characterController;


    // Use this for initialization
    void Start()
    {
      // Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
      //   var path = pathfinder.GetPath();
      //   _body = transform.Find("Body");
      //   StartCoroutine(FollowPath(path));

      _navMeshAgent = GetComponent<NavMeshAgent>();
      _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        if (!EventSystem.current.IsPointerOverGameObject()) //if not clicked on an UI
        {
          MoveToCursor();
        }
      }

      //WASD for movement as well
      float horizontal = speed * Input.GetAxisRaw("Horizontal");
      float vertical = speed * Input.GetAxisRaw("Vertical");

      Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
      if (direction.magnitude >= 0.1f)
      {
        _navMeshAgent.ResetPath();
        _characterController.Move(direction * speed * Time.deltaTime);

        //rotate player to where it's moving
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
      }
    }

    private void MoveToCursor()
    {
      // GameAssets.SFX.PlayOneShot(GameAssets.FlyingSFX);
      flyingSFX.Play();

      if (Camera.main != null)
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
          _navMeshAgent.destination = hit.point;


          if (hit.collider.CompareTag("Ground Block"))
          {
            // print("hit ground");
            GameObject effect = Instantiate(GameAssets.PointToClickEffect, hit.point + new Vector3(0, 0, 0),
              Quaternion.identity);
          }
        }
      }
    }
  }
}
