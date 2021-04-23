using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

namespace Character
{

    public class MovementComponent : MonoBehaviour
    {

        HealthSystem healthSystem = new HealthSystem(100);
        public HealthBar healthBar;

        [SerializeField] private float WalkSpeed;
        [SerializeField] private float JumpForce;

        private Vector2 InputVector = Vector2.zero;
        private Vector3 MoveDirection = Vector3.zero;

        //Comp
        private Animator PlayerAnimator;
        private PlayerController PlayerController;
        private Rigidbody PlayerRigidbody;


        public LayerMask wallLayer;

        private bool onSelect;


    



        //Reference 
        private Transform PlayerTransform;


        //Animator Hashes
        private readonly int MovementXHash = Animator.StringToHash("MovementX");
        private readonly int MovementZHash = Animator.StringToHash("MovementZ");
        private readonly int IsJumpingHash = Animator.StringToHash("IsJumping");
        private readonly int IsCollectingHash = Animator.StringToHash("IsCollecting");
        private readonly int IsRunningHash = Animator.StringToHash("IsRunning");


        //NPC
        private readonly int VampaireDanceHash = Animator.StringToHash("dance");
        private readonly int OtherGuyDanceHash = Animator.StringToHash("dance");


        private void Awake()
        {
            PlayerController = GetComponent<PlayerController>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();

            PlayerTransform = transform;
        }
        private void Start()
        {
            healthBar.Setup(healthSystem);
        }
        private void Update()
        {
            if (PlayerController.IsJumping) return;

            if (!(InputVector.magnitude > 0)) MoveDirection = Vector3.zero;

            MoveDirection = PlayerTransform.forward * InputVector.y + PlayerTransform.right * InputVector.x;

            float currentSpeed = WalkSpeed;

            Vector3 movementDirection = MoveDirection * (currentSpeed * Time.deltaTime);

            PlayerTransform.position += movementDirection;
        }

        public void OnMovement(InputValue value)
        {
            if (PlayerController.IsJumping) return;
            PlayerAnimator.SetBool("IsRunning", false);

            InputVector = value.Get<Vector2>();

            PlayerAnimator.SetFloat(MovementXHash, InputVector.x);
            PlayerAnimator.SetFloat(MovementZHash, InputVector.y);
        }

        public void OnSprint(InputValue value)
        {
            
            if (value.isPressed)
            {
                Debug.Log("Sprinting");
                PlayerAnimator.SetBool("IsRunning", true);
                return;
            }
           
          

            //// Debug.Log(value);
            //   if (PlayerController.IsJumping) return;
            //     InputVector = value.Get<Vector2>();
            // PlayerAnimator.SetBool(IsRunningHash, true);
            // PlayerAnimator.SetFloat(MovementXHash, InputVector.x);
            //     PlayerAnimator.SetFloat(MovementZHash, InputVector.y);

            //// PlayerAnimator.SetBool(IsRunningHash, false);
        }

        public void Damage()
        {
            if (healthSystem.GetHealth()<=0)
            {
                SceneManager.LoadScene("Lose");
            }
            healthSystem.Damage(3);

        }
        public void OnJump(InputValue button)
        {
            PlayerController.IsJumping = true;
            //Debug.Log("isJumping");
            PlayerAnimator.SetBool(IsJumpingHash, true);
            PlayerAnimator.SetBool("IsRunning", false);
            PlayerRigidbody.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
        }

        public void OnSelect(InputValue button)
        {
            //onSelect = true;
            //PlayerController.IsCollecting = true;
            //PlayerAnimator.SetBool(IsCollectingHash, true);
            ////StartCoroutine(wait());

        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == 9)
            {
                Debug.Log("Wall");
                Damage();
            }
            if (!other.gameObject.CompareTag("Ground") && !PlayerController.IsJumping) return;
            
            PlayerController.IsJumping = false;
            PlayerAnimator.SetBool(IsJumpingHash, false);
        }

        

        //    void OnTriggerEnter(Collider other)
        //    {
        //        Vampire.SetBool(VampaireDanceHash, true);
        //        OtherGuy.SetBool(OtherGuyDanceHash, true);
        //        Vampire2.SetBool(VampaireDanceHash, true);
        //        OtherGuy2.SetBool(OtherGuyDanceHash, true);
        //        // Debug.Log(other.tag);
        //        if (other.tag == "Blue" && onSelect)
        //        {

        //            StartCoroutine(blue());
        //        }
        //        //if (other.tag == "Blue" && onUnSelect)
        //        //{

        //        //    StartCoroutine(unblue());
        //        //}
        //        if (other.tag == "Green" && onSelect)
        //        {
        //            StartCoroutine(green());
        //        }
        //        //if (other.tag == "Green" && onUnSelect)
        //        //{

        //        //    StartCoroutine(ungreen());
        //        //}
        //        if (other.tag == "Yellow" && onSelect)
        //        {
        //            StartCoroutine(yellow());
        //        }
        //        //if (other.tag == "Yellow" && onUnSelect)
        //        //{
        //        //    StartCoroutine(unyellow());
        //        //}
        //        if (other.tag == "Red" && onSelect)
        //        {
        //            StartCoroutine(red());
        //        }
        //        //if (other.tag == "Red" && onUnSelect)
        //        //{
        //        //    StartCoroutine(unred());
        //        //}
        //        if (other.tag == "Final" && onSelect)
        //        {
        //            SceneManager.LoadScene("Restart");
        //        }

        //    }
        //    IEnumerator wait()
        //    {

        //        yield return new WaitForSeconds(1.0f);
        //        PlayerController.IsCollecting = false;
        //        PlayerAnimator.SetBool(IsCollectingHash, false);
        //        onSelect = false;

        //    }
        //    IEnumerator blue()
        //    {
        //        blueCounter++;

        //        blueText = BlueUI.GetComponent<TextMeshProUGUI>();
        //        blueText.text = blueCounter.ToString();
        //        Blue.gameObject.SetActive(true);
        //        yield return new WaitForSeconds(2f);
        //        Vampire.SetBool(VampaireDanceHash, false);
        //        OtherGuy.SetBool(OtherGuyDanceHash, false);
        //        Vampire2.SetBool(VampaireDanceHash, false);
        //        OtherGuy2.SetBool(OtherGuyDanceHash, false);
        //        Blue.gameObject.SetActive(false);
        //        Debug.Log(blueCounter);
        //    }
        //    IEnumerator unblue()
        //    {
        //        if (blueCounter>0)
        //        {
        //            blueCounter--;
        //            blueText = BlueUI.GetComponent<TextMeshProUGUI>();
        //            blueText.text = blueCounter.ToString();
        //            Blue.gameObject.SetActive(true);
        //            yield return new WaitForSeconds(2f);
        //            Blue.gameObject.SetActive(false);
        //            Debug.Log(blueCounter);
        //        }

        //    }
        //    IEnumerator red()
        //    {
        //        redCounter++;
        //        redText = RedUI.GetComponent<TextMeshProUGUI>();
        //        redText.text = redCounter.ToString();
        //        Red.gameObject.SetActive(true);
        //        yield return new WaitForSeconds(2f);
        //        Vampire.SetBool(VampaireDanceHash, false);
        //        OtherGuy.SetBool(OtherGuyDanceHash, false);
        //        Vampire2.SetBool(VampaireDanceHash, false);
        //        OtherGuy2.SetBool(OtherGuyDanceHash, false);
        //        Red.gameObject.SetActive(false);
        //    }
        //    IEnumerator unred()
        //    {
        //        if (redCounter > 0)
        //        {
        //            redCounter--;
        //            redText = RedUI.GetComponent<TextMeshProUGUI>();
        //            redText.text = redCounter.ToString();
        //            Red.gameObject.SetActive(true);
        //            yield return new WaitForSeconds(2f);

        //            Red.gameObject.SetActive(false);
        //        }

        //    }
        //    IEnumerator green()
        //    {
        //        greenCounter++;
        //        greenText = GreenUI.GetComponent<TextMeshProUGUI>();
        //        greenText.text = greenCounter.ToString();
        //        Green.gameObject.SetActive(true);
        //        yield return new WaitForSeconds(2f);
        //        Vampire.SetBool(VampaireDanceHash, false);
        //        OtherGuy.SetBool(OtherGuyDanceHash, false);
        //        Vampire2.SetBool(VampaireDanceHash, false);
        //        OtherGuy2.SetBool(OtherGuyDanceHash, false);
        //        Green.gameObject.SetActive(false);
        //    }
        //    IEnumerator ungreen()
        //    {
        //        if (greenCounter>0)
        //        {
        //        greenCounter--;
        //        greenText = GreenUI.GetComponent<TextMeshProUGUI>();
        //        greenText.text = greenCounter.ToString();
        //        Green.gameObject.SetActive(true);
        //        yield return new WaitForSeconds(2f);
        //        Green.gameObject.SetActive(false);
        //        }

        //    }
        //    IEnumerator yellow()
        //    {
        //        yellowCounter++;
        //        yellowText = YellowUI.GetComponent<TextMeshProUGUI>();
        //        yellowText.text = yellowCounter.ToString();
        //        Yellow.gameObject.SetActive(true);
        //        yield return new WaitForSeconds(6.0f);
        //        Vampire.SetBool(VampaireDanceHash, false);
        //        OtherGuy.SetBool(OtherGuyDanceHash, false);
        //        Vampire2.SetBool(VampaireDanceHash, false);
        //        OtherGuy2.SetBool(OtherGuyDanceHash, false);
        //        Yellow.gameObject.SetActive(false);
        //    }
        //    IEnumerator unyellow()
        //    {
        //        if (yellowCounter>0)
        //        {
        //            yellowCounter--;
        //            yellowText = YellowUI.GetComponent<TextMeshProUGUI>();
        //            yellowText.text = yellowCounter.ToString();
        //            Yellow.gameObject.SetActive(true);
        //            yield return new WaitForSeconds(2f);
        //            Yellow.gameObject.SetActive(false);
        //        }

        //    }
    }
}
