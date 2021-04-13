using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SimpleSampleCharacterControl : MonoBehaviour
{

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    private List<Collider> m_collisions = new List<Collider>();
    private bool m_wasGrounded;
    private bool m_isGrounded;
    int currentLane = 0;
    Vector3 lanePosition;
    int life =3;
    public TMP_Text lifeText;
    public Image redScreen;
    bool isWalking;

    void Start(){
        m_rigidBody = GetComponent<Rigidbody>();
        isWalking = true;
    }

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void OnCollisionEnter(Collision collision){
            ContactPoint[] contactPoints = collision.contacts;
            for (int i = 0; i < contactPoints.Length; i++)
            {
                if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
                {
                    if (!m_collisions.Contains(collision.collider))
                    {
                        m_collisions.Add(collision.collider);
                    }
                    m_isGrounded = true;
                }
            }
    }

    private void OnCollisionStay(Collision collision){

        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision){
         GameObject other = collision.gameObject;
        
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void Update()
    {
         if(life <= 0){
            SceneManager.LoadScene("GameOverScene"); 
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            ChangeLane(-2);
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
            ChangeLane(+2);
        }else if(Input.GetKeyDown(KeyCode.Space) && m_isGrounded){
            Jumping();
        }
        
        Vector3 targetPosition = new Vector3(lanePosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 4 *Time.deltaTime);

    }

    private void FixedUpdate(){

        m_animator.SetBool("Grounded", m_isGrounded);
        m_wasGrounded = m_isGrounded;

        if(isWalking == true){
            m_rigidBody.velocity = Vector3.forward * 20f; 
            m_animator.SetFloat("MoveSpeed", 20.0f);
            m_wasGrounded = m_isGrounded;
        }else{
            m_rigidBody.velocity = Vector3.forward * 0f; 
            m_animator.SetFloat("MoveSpeed", 0f);
        } 

    }

    private void Jumping(){
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        Invoke("Landing", 0.50f);
    }

    private void Landing(){
        Vector3 jumpEndPoint = new Vector3(transform.position.x, 0, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, jumpEndPoint, 1.5f);
    }

    private void ChangeLane(int direction){
        int targetLane = currentLane + direction;

        if(targetLane < -2 | targetLane > 2){
            return;
        }

        currentLane = targetLane;
        lanePosition = new Vector3(currentLane, 0, 0);
    }

    public void ManageLife(){
        redScreen.enabled = true;
        life = life - 1;
        lifeText.text = "Vidas: " + life.ToString();
        Invoke("DisableRedScreen", 0.25f);
    }

    private void DisableRedScreen(){
        redScreen.enabled = false;
    }

    public void EndGame(){
        isWalking = false;
        transform.rotation =  Quaternion.Euler(0, 180, 0);
        m_animator.SetTrigger("Wave");
        Invoke("CallGameVictoryScene", 1f);    
    }

    private void CallGameVictoryScene(){
        SceneManager.LoadScene("GameVictoryScene");
    }
}
