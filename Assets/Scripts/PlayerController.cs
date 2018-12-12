using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    public GameObject explosionEffect;
    public GameObject instantiatedExplosionEffect;

    public bool gameStarted, gameOver;

    private float rotation;
    private Rigidbody rb;

    public static PlayerController instance;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation = Input.GetAxisRaw("Horizontal");

        if (gameStarted && gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    void FixedUpdate()
    {
        if (gameStarted && !gameOver)
        {
            rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(yRotation);
            Quaternion targetRotation = rb.rotation * deltaRotation;
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
            //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameStarted)
        {
            if (other.gameObject.tag == "Enemy")
            {
                instantiatedExplosionEffect = Instantiate(explosionEffect, other.transform.position + new Vector3(0f, 20f + 0f), Quaternion.identity);
                gameOver = true;
                if (gameStarted && gameOver)
                {
                    UIManager.instance.gameOvermenu.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(instantiatedExplosionEffect, 4f);
        print("Particle system destroyed");
    }
}
