using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class console : MonoBehaviour
{
    public TMP_Text outputText;
    //public TextMeshPro inputText;
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
    //Requered bools for codes:
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
            else
            {
                Debug.Log("Cannot add more lines into the code, the console needs to be cleared, or reset.");
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
                    attackDamage.attackDamage = 10;
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
            default:
                break;
        }
        inputField.text = "...";
    }
}
