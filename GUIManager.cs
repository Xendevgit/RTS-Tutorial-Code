using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls the in-game Selection HUD and all  object-related items displayed to the player on screen. This gets attached to the player object
public class GUIManager : MonoBehaviour {

    private ObjectInfo primary; //The object information to be displayed

    private Slider UHB; //The slider object that acts as a health bar
    private Slider UEB; //The slider object that acts as an energy bar

    private Text unitNameDisp; //The unit name text object
    private Text unitHealthDisp; //The unit health text object
    private Text unitEnergyDisp; //The unit energy text object
    private Text upatkDisp; //The unit physical attack text object
    private Text updefDisp; //The unit physical defense text object
    private Text ueatkDisp; //The unit energy attack text object
    private Text uedefDisp; //The unit energy defense text object
    private Text urankDisp; //The unit rank text object
    private Text ukillDisp; //The unit kill count text object

    // Use this for initialization
    void Start () {

        UEB = GameObject.Find("UnitEnergyBar").GetComponent<Slider>(); //Assigns the UEB object
        UHB = GameObject.Find("UnitHealthBar").GetComponent<Slider>(); //Assigns the UHB object
        unitNameDisp = GameObject.Find("UnitName").GetComponent<Text>(); //Assigns the unitNameDisp object
        unitHealthDisp = GameObject.Find("HealthDisp").GetComponent<Text>(); //Assigns the unitHealthDisp object
        unitEnergyDisp = GameObject.Find("EnergyDisp").GetComponent<Text>(); //Assigns the unitEnergyDisp object
        upatkDisp = GameObject.Find("PATKDisp").GetComponent<Text>(); //Assigns the upatkDisp object
        updefDisp = GameObject.Find("PDEFDisp").GetComponent<Text>(); //Assigns the updefDisp object
        ueatkDisp = GameObject.Find("EATKDisp").GetComponent<Text>(); //Assigns the ueatkDisp object
        uedefDisp = GameObject.Find("EDEFDisp").GetComponent<Text>(); //Assigns the uedefDisp object
        urankDisp = GameObject.Find("RankDisp").GetComponent<Text>(); //Assigns the urankDisp object
        ukillDisp = GameObject.Find("KillCountDisp").GetComponent<Text>(); //Assigns the ukillDisp object

    }
	
	// Update is called once per frame
	void Update () {

        primary = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>().selectedInfo; //Assigns the primary object

        if (primary.maxEnergy <= 0) //Does the selected object have energy?
        {
            UEB.gameObject.SetActive(false); //Deactivates the Energy Bar
        }

        UHB.maxValue = primary.maxHealth; //Sets the max value of the health bar to be equal to the selected unit's max health
        UHB.value = primary.health; //Sets the value of the health bar to be equal to the selected object's current health

        UEB.maxValue = primary.maxEnergy; //Sets the max value of the energy bar to be equal to the selected unit's max energy
        UEB.value = primary.energy; //Sets the value of the energy bar to be equal to the selected object's current energy

        unitNameDisp.text = primary.objectName; //Displays the unit's name
        unitHealthDisp.text = "HP: " + primary.health; //Displays the unit's health
        unitEnergyDisp.text = "EP: " + primary.energy; //Displays the unit's energy
        upatkDisp.text = "PATK: " + primary.patk; //Displays the unit's physical attack
        updefDisp.text = "PDEF: " + primary.pdef; //Displays the unit's physical defense
        ueatkDisp.text = "EATK: " + primary.eatk; //Displays the unit's energy attack
        uedefDisp.text = "EDEF: " + primary.edef; //Displays the unit's energy defense
        urankDisp.text = "" + primary.rank; //Displays the unit's rank
        ukillDisp.text = "Kills: " + primary.kills; //Displays the unit's kill count
    }
}