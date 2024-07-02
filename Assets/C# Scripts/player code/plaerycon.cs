using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;

public class plaerycon : MonoBehaviour
{
    private basevalue basevalue;

    // player's footsteps audio
    private EventInstance playerFootsteps;

    // Start is called before the first frame update
    void Awake()
    {
        basevalue = GetComponent<basevalue>();
        Door_Quit.door_use_to_quit = false;
    }

    private void Start()
    {
        // initialize the footstpes instance 
        playerFootsteps = AudioManager.instance.CreateInstance(FModEvents.instance.playerFootstepsEvent);
    }

    // Update is called once per frame
    void Update()
    {
        stairs();
        if (Input.GetButtonDown("Jump") && basevalue.JumpCount > 0)
        {
            //basevalue.pcd.enabled = true;
            basevalue.jumpPressed = true;
            playJummEvent();
        }
        if (Input.GetButtonDown("Attack") && basevalue.AttackCount > 0)
        {
            basevalue.Attackpressed = true;
        }
        if (Input.GetButtonDown("Crouch") | Input.GetButtonDown("up"))
        {
            basevalue.Crouchpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && basevalue.opendoor == true)
        {
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            basevalue.opendoor = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            basevalue.panel.SetActive(true);
            basevalue.isstop = true;
            basevalue.hp.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            basevalue.panel.SetActive(false);
            basevalue.pane2.SetActive(false);
            basevalue.isstop = false;
            basevalue.hp.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && Door_Quit.door_use_to_quit == true && Door_Quit.Takeshield == true)
        {
            Time.timeScale = 1;

            MenuButton.isFoward = 0;
            MenuButton.sceneIndex();
            Door_Quit.door_use_to_quit = false;
            SceneManager.LoadScene("LoadingScene");
            basevalue.destroy = false;
            
          
           
        }

        playFootsteps();
        if (basevalue.isstop)
        {
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        if (!basevalue.isstop)
        {
            if (!basevalue.isHurt)
            {
                basevalue.isGround = Physics2D.OverlapCircle(basevalue.groundChack.position, 0.2f, basevalue.ground);
                move();
                Crouch();
                Jump();
                Attack();
            }
        }

    }

    // Player Movement
    void move()
    {        
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        basevalue.rb.velocity = new Vector2(horizontalMove * basevalue.speed, basevalue.rb.velocity.y);
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }

    // Player Jump
    void Jump()
    {
        if (basevalue.isGround)
        {
            basevalue.JumpCount = basevalue.JumpCountRest;
            basevalue.isJump = false;
        }
        if (basevalue.jumpPressed && basevalue.isGround)
        {
            basevalue.isJump = true;
            basevalue.rb.velocity = new Vector2(basevalue.rb.velocity.x, basevalue.jumpforce);
            basevalue.JumpCount--;
            basevalue.jumpPressed = false;
        }
        else if (basevalue.jumpPressed && basevalue.JumpCount > 0 && basevalue.isJump)
        {
            basevalue.rb.velocity = new Vector2(basevalue.rb.velocity.x, basevalue.jumpforce);
            basevalue.JumpCount--;
            basevalue.jumpPressed = false;
        }
    }

    // Player Crouch
    void Crouch()
    {
        if (basevalue.Crouchpressed)
        {
            if (!basevalue.isstairs)
            {
                if (!Physics2D.OverlapCircle(basevalue.CrouchChack.position, 0.02f, basevalue.ground))
                {
                    if (Input.GetButton("Crouch"))
                    {
                        basevalue.isCrouch = true;
                        basevalue.box.enabled = false;
                    }
                    else
                    {
                        basevalue.isCrouch = false;
                        basevalue.box.enabled = true;
                    }
                }
            }

        }
       
    }
    void stairs() 
    {
        if (basevalue.isstairs)
        {
            basevalue.stairsstop = true;
            if (Input.GetButton("Crouch") && basevalue.Crouchpressed)
            {
                basevalue.rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                basevalue.rb.velocity = new Vector2(basevalue.rb.velocity.x, -basevalue.speed);
                basevalue.stairsmove = true;
                basevalue.stairsstop = false;
            }
            else if (Input.GetButton("up") && basevalue.Crouchpressed)
            {
                basevalue.rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                basevalue.rb.velocity = new Vector2(basevalue.rb.velocity.x, basevalue.speed);
                basevalue.stairsmove = true;
                basevalue.stairsstop = false;
            }
            else
            {
                basevalue.stairsstop = true;
                basevalue.stairsmove = false;
                basevalue.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
        else
        {
            basevalue.stairsstop = false;
            basevalue.stairsmove = false;
            basevalue.rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            basevalue.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    // Player Attack
    void Attack()
    {
        if (basevalue.Attackpressed && basevalue.AttackCount > 0)
        {
            basevalue.isAttack = true;
            basevalue.Attackpressed = false;
            basevalue.AttackCount--;
        }

    }

    // End of Player Attack and Recovery of Attack times
    void noattack()
    {
        basevalue.isAttack = false;
        basevalue.AttackCount = basevalue.AttackCountRest;
    }

    // assign Player's transfrom position when enter a new scene 
    void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        if (basevalue.destroy)
        {
            if (basevalue.SceneMangerTransForm == null)
            {
                if (basevalue.Player == null)
                {
                    basevalue.Player = GameObject.Find("player") as GameObject;
                }
                basevalue.SceneMangerTransForm = GameObject.Find("system") as GameObject;
                if (basevalue.SceneMangerTransForm == null)
                {
                    return;
                }
                else 
                {
                    basevalue.Player.transform.position = new Vector3(basevalue.SceneMangerTransForm.gameObject.transform.position.x, basevalue.SceneMangerTransForm.gameObject.transform.position.y, basevalue.SceneMangerTransForm.gameObject.transform.position.z);
                }
               
            }


        }
        else { return; }
    }

    // assignment of play footsteps event
    void playFootsteps()
    {
        // start footsteps event if player has velocity.x & is on the ground
        if (basevalue.isGround)
        {
            if (basevalue.rb.velocity.x > 0.1 || basevalue.rb.velocity.x < -0.1)
            {
                // get the playback state
                PLAYBACK_STATE playbackState;
                playerFootsteps.getPlaybackState(out playbackState);

                // start playerFootsteps event when playback state stopped
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                    playerFootsteps.start();
                }
            }
            else
            {
                playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            }
        }
        // otherwise, stop the footsteps event
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    // play jump Event
    void playJummEvent()
    {
        if (basevalue.jumpPressed == true)
        {
            AudioManager.instance.PlayOneShot(FModEvents.instance.jumpEvent, this.transform.position);
        }
    }

}
