using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class console : MonoBehaviour
{
    //public Animator animator;
    public TMP_Text outputText;
    //public TextMeshPro inputText;
    public Rigidbody2D playerBody;
    public GameObject playerObject;
    public GameObject flyingCube;
    public TMP_InputField inputField;
    public static bool isConsoleOn;
    public int indexOfCodes;
    public GameObject canvas;
    public AudioSource jojoSoundtrack;
    public GameObject music;
    //Requiered scripts for codes:
    public MusicPlayer musicPlayer;
    public Attack attackDamage;
    public PlayerController playerSpeedCode;
    public Damageable invincibilityCode;
    public Transform player;
    //Requered bools for codes:
    public bool flightIsOn;
    public bool strengthHasBeenAdded;
    public bool speedHasBeenAdded;
    public bool godModeIsOn;
    public static bool jojoSoundtrackHasBeenSwitched;
    void Start()
    {
        strengthHasBeenAdded = false;
        speedHasBeenAdded = false;
        godModeIsOn = false;
        jojoSoundtrackHasBeenSwitched = false;
        canvas.SetActive(false);
        outputText.text = "Enter code";
        isConsoleOn = false;
        indexOfCodes = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isConsoleOn = !isConsoleOn;
            canvas.SetActive(isConsoleOn);
        }

        if (Input.GetKeyDown(KeyCode.Return) && inputField.text != "..." && isConsoleOn)
        {
            //animator.Play("consoleAnimation");
            if (indexOfCodes < 9 )
            {
                ConsoleInput();
                indexOfCodes++;
            }
            else if(indexOfCodes == 9)
            {
                inputField.text = "Clear, or reset the console.";
                ConsoleInput();
                indexOfCodes++;
            }
            else if(inputField.text == "clear")
            {
                outputText.text = "Enter text";
                indexOfCodes = -1;
            }
            else
            {
                Debug.Log("Just clear the console you know the code lol");
            }
        }
    }
    public void ConsoleInput()
    {
        outputText.text += "\n" + inputField.text;
        switch (inputField.text)
        {
            case "addStrength":
                if(!strengthHasBeenAdded)
                {
                    //Adds strength to over 9000.
                    attackDamage.attackDamage = 9000;
                    outputText.text += "---Strength is over 9000!!!";
                    strengthHasBeenAdded = !strengthHasBeenAdded;
                }
                else
                {
                    //Sets the strength to normal.
                    attackDamage.attackDamage = 15;
                    outputText.text += "---Strength is set to normal!";
                    strengthHasBeenAdded = !strengthHasBeenAdded;
                }
                break;
            case "addSpeed":
                if (!speedHasBeenAdded)
                {
                    //Doubles the speed.
                    playerSpeedCode.walkSpeed = 15;
                    playerSpeedCode.runSpeed = 25;
                    outputText.text += "---The speed has doubled!";
                    speedHasBeenAdded = !speedHasBeenAdded;
                }
                else
                {
                    //Sets the speed to normal again.
                    playerSpeedCode.walkSpeed = 5;
                    playerSpeedCode.runSpeed = 7;
                    outputText.text += "---The speed has been set to normal!";
                    speedHasBeenAdded = !speedHasBeenAdded;
                }

                break;
            case "god":
                if (!godModeIsOn)
                {
                    //Makes the player invincible.
                    invincibilityCode.isInvincible = true;
                    invincibilityCode.invincibilityTime = 100000000f;
                    outputText.text += "---Youre invincible!";
                    godModeIsOn = !godModeIsOn;
                }
                else
                {
                    //Makes the player no longer invincible.
                    invincibilityCode.isInvincible = false;
                    invincibilityCode.invincibilityTime = 0.5f;
                    outputText.text += "---Youre no longer invincible!";
                    godModeIsOn = !godModeIsOn;
                }
                break;
            case "clear":
                //Clears thew console and resets the line counter.
                outputText.text = "Enter text";
                indexOfCodes = -1;
                break;
            case "jojoSoundtrack":
                if (!jojoSoundtrackHasBeenSwitched)
                {
                    //Replaces the game soundtrack with a jojo soundtrack.
                    outputText.text += "---Sounds replaced with those made in heaven.";
                    jojoSoundtrack.Play();
                    music.SetActive(false);
                    jojoSoundtrackHasBeenSwitched = !jojoSoundtrackHasBeenSwitched;
                }
                else
                {
                    musicPlayer.playOnlyOnce = true;
                    //Sets the soundstrack to its original state.
                    outputText.text += "---Sounds have been switched to the normal set.";
                    jojoSoundtrack.Stop();
                    music.SetActive(true);
                    jojoSoundtrackHasBeenSwitched = !jojoSoundtrackHasBeenSwitched;
                }
                break;
            case "status":
                indexOfCodes = 4;
                outputText.text = "";
                if (strengthHasBeenAdded)
                {
                    outputText.text += "Strength code true\n";
                }
                else
                {
                    outputText.text += "Strength code\t\t\tfalse\n";
                }

                if (speedHasBeenAdded)
                {
                    outputText.text += "Speed code\t\t\ttrue\n";
                }
                else
                {
                    outputText.text += "Speed code\t\t\tfalse\n";
                }

                if (godModeIsOn)
                {
                    outputText.text += "God code\t\t\ttrue\n";
                }
                else
                {
                    outputText.text += "God code\t\t\tfalse\n";
                }

                if (jojoSoundtrackHasBeenSwitched)
                {
                    outputText.text += "Jojo code\t\t\ttrue\n";
                }
                else
                {
                    outputText.text += "Jojo code\t\t\tfalse\n";
                }
                if (flightIsOn)
                {
                    outputText.text += "flight code\t\t\ttrue\n";
                }
                else
                {
                    outputText.text += "flight code\t\t\tfalse\n";
                }
                break;
            case "help":
                outputText.text = "addStrength\t\t\tAdds strength to your character.\n" +
                                  "addSpeed\t\t\tAdds speed to your character.\n" +
                                  "clear\t\t\t\tClears the console.\n" +
                                  "god\t\t\t\tMakes the player invincible.\n" +
                                  "flight\t\t\t\tGives the player wings.\n" +
                                  "secret :)\t\t\tAint noone gonna know what this one does.\n" +
                                  "status\t\t\t\tShows all the enabled codes.\n";
                indexOfCodes = 7;
                break;
            case "flight":
                {
                    if (!flightIsOn)
                    {
                        outputText.text += "---Flight has been activated!";
                        indexOfCodes++;
                        playerBody.bodyType = RigidbodyType2D.Kinematic;
                        GameObject wings = Instantiate(flyingCube, player.position, Quaternion.identity);
                        playerObject.transform.SetParent(wings.transform);
                        flightIsOn = !flightIsOn;
                    }
                    else
                    {
                        playerBody.bodyType = RigidbodyType2D.Dynamic;
                        outputText.text += "---Flight has been disabled!";
                        indexOfCodes++;
                        playerObject.transform.SetParent(null);
                        Destroy(GameObject.Find("wings(Clone)"));
                        flightIsOn = !flightIsOn;
                    }
                    break;
                }
            default:
                break;
        }
        inputField.text = "...";
    }
}
