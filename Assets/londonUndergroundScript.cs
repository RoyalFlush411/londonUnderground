using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using londonUnderground;

public class londonUndergroundScript : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable submitButton;
    public KMSelectable changeLine1;
    public KMSelectable changeStation1;
    public KMSelectable changeLine2;
    public KMSelectable changeStation2;
    public KMSelectable changeLine3;
    public KMSelectable changeStation3;

    //Line information
    public string[] bakerlooStations;
    int bakerloo1Index = 0;
    int bakerloo2Index = 0;
    int bakerloo3Index = 0;
    public string[] centralStations;
    int central1Index = 0;
    int central2Index = 0;
    int central3Index = 0;
    public string[] circleStations;
    int circle1Index = 0;
    int circle2Index = 0;
    int circle3Index = 0;
    public string[] districtStations;
    int district1Index = 0;
    int district2Index = 0;
    int district3Index = 0;
    public string[] hammersmithStations;
    int hammersmith1Index = 0;
    int hammersmith2Index = 0;
    int hammersmith3Index = 0;
    public string[] jubileeStations;
    int jubilee1Index = 0;
    int jubilee2Index = 0;
    int jubilee3Index = 0;
    public string[] metropolitanStations;
    int metro1Index = 0;
    int metro2Index = 0;
    int metro3Index = 0;
    public string[] northernStations;
    int northern1Index = 0;
    int northern2Index = 0;
    int northern3Index = 0;
    public string[] piccadillyStations;
    int piccadilly1Index = 0;
    int piccadilly2Index = 0;
    int piccadilly3Index = 0;
    public string[] victoriaStations;
    int victoria1Index = 0;
    int victoria2Index = 0;
    int victoria3Index = 0;

    //Line Arrays
    public string[] lineOptions;
    int line1OptionsIndex = 10;
    int line1ColorIndex = 10;
    int line2OptionsIndex = 10;
    int line2ColorIndex = 10;
    int line3OptionsIndex = 10;
    int line3ColorIndex = 10;
    public string noStations;

    //Departure/Destination Lines
    int departureLine = 0;
    int destinationLine = 0;
    int departureStationIndex = 0;
    int destinationStationIndex = 0;

    //New Arrays
    private string[] departureOptions;
    private string departureStation = "";
    private string[] destinationOptions;
    private string destinationStation = "";

    //Screen text
    public TextMesh line1Line;
    public TextMesh line1Station;
    public TextMesh line2Line;
    public TextMesh line2Station;
    public TextMesh line3Line;
    public TextMesh line3Station;
    public TextMesh departureText;
    public TextMesh destinationText;

    //Colours
    public Color[] lineColors;
    public Texture lightOn;
    public Texture lightOff;
    public Renderer light1;
    public Renderer light2;
    public Renderer light3;
    int levelsPassed = 0;
    private bool moduleSolved = false;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        submitButton.OnInteract += delegate () { OnsubmitButton(); return false; };
        changeLine1.OnInteract += delegate () { OnchangeLine1(); return false; };
        changeStation1.OnInteract += delegate () { OnchangeStation1(); return false; };
        changeLine2.OnInteract += delegate () { OnchangeLine2(); return false; };
        changeStation2.OnInteract += delegate () { OnchangeStation2(); return false; };
        changeLine3.OnInteract += delegate () { OnchangeLine3(); return false; };
        changeStation3.OnInteract += delegate () { OnchangeStation3(); return false; };
    }

    void Start()
    {
        line1OptionsIndex = 10;
        line2OptionsIndex = 10;
        line3OptionsIndex = 10;
        line1ColorIndex = 10;
        line2ColorIndex = 10;
        line3ColorIndex = 10;
        line1Station.text = noStations;
        line2Station.text = noStations;
        line3Station.text = noStations;
        line1Line.text = lineOptions[line1OptionsIndex];
        line1Line.color = lineColors[line1ColorIndex];
        line2Line.text = lineOptions[line2OptionsIndex];
        line2Line.color = lineColors[line2ColorIndex];
        line3Line.text = lineOptions[line3OptionsIndex];
        line3Line.color = lineColors[line3ColorIndex];
        SelectDeparture();
        SelectDestination();
    }

    void SelectDeparture()
    {
        if (levelsPassed == 1 || levelsPassed == 2)
        {
            departureLine = destinationLine;
        }
        else
        {
            departureLine = UnityEngine.Random.Range(0,10);
        }
        if (departureLine == 0)
        {
            departureOptions = new string[bakerlooStations.Length];
            bakerlooStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 1)
        {
            departureOptions = new string[centralStations.Length];
            centralStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 2)
        {
            departureOptions = new string[circleStations.Length];
            circleStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 3)
        {
            departureOptions = new string[districtStations.Length];
            districtStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 4)
        {
            departureOptions = new string[hammersmithStations.Length];
            hammersmithStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 5)
        {
            departureOptions = new string[jubileeStations.Length];
            jubileeStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 6)
        {
            departureOptions = new string[metropolitanStations.Length];
            metropolitanStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 7)
        {
            departureOptions = new string[northernStations.Length];
            northernStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 8)
        {
            departureOptions = new string[piccadillyStations.Length];
            piccadillyStations.CopyTo(departureOptions, 0 );
        }
        else if (departureLine == 9)
        {
            departureOptions = new string[victoriaStations.Length];
            victoriaStations.CopyTo(departureOptions, 0 );
        }
        if (levelsPassed == 1 || levelsPassed == 2)
        {
            departureStationIndex = destinationStationIndex;
        }
        else
        {
            departureStationIndex = UnityEngine.Random.Range(0, departureOptions.Length);
        }
        departureStation = departureOptions[departureStationIndex];
        departureText.text = departureStation;
        Debug.LogFormat("[The London Underground #{0}] Your departure station is {1}.", moduleId, departureStation);
        departureLogging();
    }

    void SelectDestination()
    {
        destinationLine = UnityEngine.Random.Range(0,10);
        if (destinationLine == 0)
        {
            destinationOptions = new string[bakerlooStations.Length];
            bakerlooStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 1)
        {
            destinationOptions = new string[centralStations.Length];
            centralStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 2)
        {
            destinationOptions = new string[circleStations.Length];
            circleStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 3)
        {
            destinationOptions = new string[districtStations.Length];
            districtStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 4)
        {
            destinationOptions = new string[hammersmithStations.Length];
            hammersmithStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 5)
        {
            destinationOptions = new string[jubileeStations.Length];
            jubileeStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 6)
        {
            destinationOptions = new string[metropolitanStations.Length];
            metropolitanStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 7)
        {
            destinationOptions = new string[northernStations.Length];
            northernStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 8)
        {
            destinationOptions = new string[piccadillyStations.Length];
            piccadillyStations.CopyTo(destinationOptions, 0 );
        }
        else if (destinationLine == 9)
        {
            destinationOptions = new string[victoriaStations.Length];
            victoriaStations.CopyTo(destinationOptions, 0 );
        }
        destinationStationIndex = UnityEngine.Random.Range(0, destinationOptions.Length);
        destinationStation = destinationOptions[destinationStationIndex];

        if (destinationStation == departureStation)
        {
            SelectDestination();
        }
        else
        {
            destinationText.text = destinationStation;
            Debug.LogFormat("[The London Underground #{0}] Your destination station is {1}.", moduleId, destinationStation);
            destinationLogging();
        }
    }

    void departureLogging()
    {
        if (bakerlooStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Bakerloo line.", moduleId, departureStation);
        }
        if (centralStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Central line.", moduleId, departureStation);
        }
        if (circleStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Circle line.", moduleId, departureStation);
        }
        if (districtStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the District line.", moduleId, departureStation);
        }
        if (hammersmithStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Hammersmith & City line.", moduleId, departureStation);
        }
        if (jubileeStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Jubilee line.", moduleId, departureStation);
        }
        if (metropolitanStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Metropolitan line.", moduleId, departureStation);
        }
        if (northernStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Northern line.", moduleId, departureStation);
        }
        if (piccadillyStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Piccadilly line.", moduleId, departureStation);
        }
        if (victoriaStations.Any(departureStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Victoria line.", moduleId, departureStation);
        }
    }

    void destinationLogging()
    {
        if (bakerlooStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Bakerloo line.", moduleId, destinationStation);
        }
        if (centralStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Central line.", moduleId, destinationStation);
        }
        if (circleStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Circle line.", moduleId, destinationStation);
        }
        if (districtStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the District line.", moduleId, destinationStation);
        }
        if (hammersmithStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Hammersmith & City line.", moduleId, destinationStation);
        }
        if (jubileeStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Jubilee line.", moduleId, destinationStation);
        }
        if (metropolitanStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Metropolitan line.", moduleId, destinationStation);
        }
        if (northernStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Northern line.", moduleId, destinationStation);
        }
        if (piccadillyStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Piccadilly line.", moduleId, destinationStation);
        }
        if (victoriaStations.Any(destinationStation.Contains))
        {
            Debug.LogFormat("[The London Underground #{0}] {1} is on the Victoria line.", moduleId, destinationStation);
        }
    }

    public void OnchangeLine1()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, changeLine1.transform);
        changeLine1.AddInteractionPunch(.5f);
        if (moduleSolved)
        {
            return;
        }
        line1OptionsIndex = (line1OptionsIndex + 1) % 11;
        line1ColorIndex = (line1ColorIndex + 1) % 11;
        line1Line.text = lineOptions[line1OptionsIndex];
        line1Line.color = lineColors[line1ColorIndex];
        if (line1Line.text == "Bakerloo")
        {
            bakerloo1Index = UnityEngine.Random.Range(0, bakerlooStations.Length);
            line1Station.text = bakerlooStations[bakerloo1Index];
        }
        else if (line1Line.text == "Central")
        {
            central1Index = UnityEngine.Random.Range(0, centralStations.Length);
            line1Station.text = centralStations[central1Index];
        }
        else if (line1Line.text == "Circle")
        {
            circle1Index = UnityEngine.Random.Range(0, circleStations.Length);
            line1Station.text = circleStations[circle1Index];
        }
        else if (line1Line.text == "District")
        {
            district1Index = UnityEngine.Random.Range(0, districtStations.Length);
            line1Station.text = districtStations[district1Index];
        }
        else if (line1Line.text == "Hammersmith & City")
        {
            hammersmith1Index = UnityEngine.Random.Range(0, hammersmithStations.Length);
            line1Station.text = hammersmithStations[hammersmith1Index];
        }
        else if (line1Line.text == "Jubilee")
        {
            jubilee1Index = UnityEngine.Random.Range(0, jubileeStations.Length);
            line1Station.text = jubileeStations[jubilee1Index];
        }
        else if (line1Line.text == "Metropolitan")
        {
            metro1Index = UnityEngine.Random.Range(0, metropolitanStations.Length);
            line1Station.text = metropolitanStations[metro1Index];
        }
        else if (line1Line.text == "Northern")
        {
            northern1Index = UnityEngine.Random.Range(0, northernStations.Length);
            line1Station.text = northernStations[northern1Index];
        }
        else if (line1Line.text == "Piccadilly")
        {
            piccadilly1Index = UnityEngine.Random.Range(0, piccadillyStations.Length);
            line1Station.text = piccadillyStations[piccadilly1Index];
        }
        else if (line1Line.text == "Victoria")
        {
            victoria1Index = UnityEngine.Random.Range(0, victoriaStations.Length);
            line1Station.text = victoriaStations[victoria1Index];
        }
        else
        {
            line1Station.text = noStations;
        }
        line1Station.color = lineColors[line1ColorIndex];
    }

    public void OnchangeStation1()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, changeStation1.transform);
        changeStation1.AddInteractionPunch(.5f);
        if (moduleSolved)
        {
            return;
        }
        if (line1Line.text == "Bakerloo")
        {
            bakerloo1Index = (bakerloo1Index + 1) % bakerlooStations.Length;
            line1Station.text = bakerlooStations[bakerloo1Index];
        }
        else if (line1Line.text == "Central")
        {
            central1Index = (central1Index + 1) % centralStations.Length;
            line1Station.text = centralStations[central1Index];
        }
        else if (line1Line.text == "Circle")
        {
            circle1Index = (circle1Index + 1) % circleStations.Length;
            line1Station.text = circleStations[circle1Index];
        }
        else if (line1Line.text == "District")
        {
            district1Index = (district1Index + 1) % districtStations.Length;
            line1Station.text = districtStations[district1Index];
        }
        else if (line1Line.text == "Hammersmith & City")
        {
            hammersmith1Index = (hammersmith1Index + 1) % hammersmithStations.Length;
            line1Station.text = hammersmithStations[hammersmith1Index];
        }
        else if (line1Line.text == "Jubilee")
        {
            jubilee1Index = (jubilee1Index + 1) % jubileeStations.Length;
            line1Station.text = jubileeStations[jubilee1Index];
        }
        else if (line1Line.text == "Metropolitan")
        {
            metro1Index = (metro1Index + 1) % metropolitanStations.Length;
            line1Station.text = metropolitanStations[metro1Index];
        }
        else if (line1Line.text == "Northern")
        {
            northern1Index = (northern1Index + 1) % northernStations.Length;
            line1Station.text = northernStations[northern1Index];
        }
        else if (line1Line.text == "Piccadilly")
        {
            piccadilly1Index = (piccadilly1Index + 1) % piccadillyStations.Length;
            line1Station.text = piccadillyStations[piccadilly1Index];
        }
        else if (line1Line.text == "Victoria")
        {
            victoria1Index = (victoria1Index + 1) % victoriaStations.Length;
            line1Station.text = victoriaStations[victoria1Index];
        }
        else
        {
            line1Station.text = noStations;
        }
    }

    public void OnchangeLine2()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, changeLine2.transform);
        changeLine2.AddInteractionPunch(.5f);
        if (moduleSolved)
        {
            return;
        }
        line2OptionsIndex = (line2OptionsIndex + 1) % 11;
        line2ColorIndex = (line2ColorIndex + 1) % 11;
        line2Line.text = lineOptions[line2OptionsIndex];
        line2Line.color = lineColors[line2ColorIndex];
        if (line2Line.text == "Bakerloo")
        {
            bakerloo2Index = UnityEngine.Random.Range(0, bakerlooStations.Length);
            line2Station.text = bakerlooStations[bakerloo2Index];
        }
        else if (line2Line.text == "Central")
        {
            central2Index = UnityEngine.Random.Range(0, centralStations.Length);
            line2Station.text = centralStations[central2Index];
        }
        else if (line2Line.text == "Circle")
        {
            circle2Index = UnityEngine.Random.Range(0, circleStations.Length);
            line2Station.text = circleStations[circle2Index];
        }
        else if (line2Line.text == "District")
        {
            district2Index = UnityEngine.Random.Range(0, districtStations.Length);
            line2Station.text = districtStations[district2Index];
        }
        else if (line2Line.text == "Hammersmith & City")
        {
            hammersmith2Index = UnityEngine.Random.Range(0, hammersmithStations.Length);
            line2Station.text = hammersmithStations[hammersmith2Index];
        }
        else if (line2Line.text == "Jubilee")
        {
            jubilee2Index = UnityEngine.Random.Range(0, jubileeStations.Length);
            line2Station.text = jubileeStations[jubilee2Index];
        }
        else if (line2Line.text == "Metropolitan")
        {
            metro2Index = UnityEngine.Random.Range(0, metropolitanStations.Length);
            line2Station.text = metropolitanStations[metro2Index];
        }
        else if (line2Line.text == "Northern")
        {
            northern2Index = UnityEngine.Random.Range(0, northernStations.Length);
            line2Station.text = northernStations[northern2Index];
        }
        else if (line2Line.text == "Piccadilly")
        {
            piccadilly2Index = UnityEngine.Random.Range(0, piccadillyStations.Length);
            line2Station.text = piccadillyStations[piccadilly2Index];
        }
        else if (line2Line.text == "Victoria")
        {
            victoria2Index = UnityEngine.Random.Range(0, victoriaStations.Length);
            line2Station.text = victoriaStations[victoria2Index];
        }
        else
        {
            line2Station.text = noStations;
        }
        line2Station.color = lineColors[line2ColorIndex];
    }

    public void OnchangeStation2()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, changeStation2.transform);
        changeStation2.AddInteractionPunch(.5f);
        if (moduleSolved)
        {
            return;
        }
        if (line2Line.text == "Bakerloo")
        {
            bakerloo2Index = (bakerloo2Index + 1) % bakerlooStations.Length;
            line2Station.text = bakerlooStations[bakerloo2Index];
        }
        else if (line2Line.text == "Central")
        {
            central2Index = (central2Index + 1) % centralStations.Length;
            line2Station.text = centralStations[central2Index];
        }
        else if (line2Line.text == "Circle")
        {
            circle2Index = (circle2Index + 1) % circleStations.Length;
            line2Station.text = circleStations[circle2Index];
        }
        else if (line2Line.text == "District")
        {
            district2Index = (district2Index + 1) % districtStations.Length;
            line2Station.text = districtStations[district2Index];
        }
        else if (line2Line.text == "Hammersmith & City")
        {
            hammersmith2Index = (hammersmith2Index + 1) % hammersmithStations.Length;
            line2Station.text = hammersmithStations[hammersmith2Index];
        }
        else if (line2Line.text == "Jubilee")
        {
            jubilee2Index = (jubilee2Index + 1) % jubileeStations.Length;
            line2Station.text = jubileeStations[jubilee2Index];
        }
        else if (line2Line.text == "Metropolitan")
        {
            metro2Index = (metro2Index + 1) % metropolitanStations.Length;
            line2Station.text = metropolitanStations[metro2Index];
        }
        else if (line2Line.text == "Northern")
        {
            northern2Index = (northern2Index + 1) % northernStations.Length;
            line2Station.text = northernStations[northern2Index];
        }
        else if (line2Line.text == "Piccadilly")
        {
            piccadilly2Index = (piccadilly2Index + 1) % piccadillyStations.Length;
            line2Station.text = piccadillyStations[piccadilly2Index];
        }
        else if (line2Line.text == "Victoria")
        {
            victoria2Index = (victoria2Index + 1) % victoriaStations.Length;
            line2Station.text = victoriaStations[victoria2Index];
        }
        else
        {
            line2Station.text = noStations;
        }
    }

    public void OnchangeLine3()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, changeLine3.transform);
        changeLine3.AddInteractionPunch(.5f);
        if (moduleSolved)
        {
            return;
        }
        line3OptionsIndex = (line3OptionsIndex + 1) % 11;
        line3ColorIndex = (line3ColorIndex + 1) % 11;
        line3Line.text = lineOptions[line3OptionsIndex];
        line3Line.color = lineColors[line3ColorIndex];
        if (line3Line.text == "Bakerloo")
        {
            bakerloo3Index = UnityEngine.Random.Range(0, bakerlooStations.Length);
            line3Station.text = bakerlooStations[bakerloo3Index];
        }
        else if (line3Line.text == "Central")
        {
            central3Index = UnityEngine.Random.Range(0, centralStations.Length);
            line3Station.text = centralStations[central3Index];
        }
        else if (line3Line.text == "Circle")
        {
            circle3Index = UnityEngine.Random.Range(0, circleStations.Length);
            line3Station.text = circleStations[circle3Index];
        }
        else if (line3Line.text == "District")
        {
            district3Index = UnityEngine.Random.Range(0, districtStations.Length);
            line3Station.text = districtStations[district3Index];
        }
        else if (line3Line.text == "Hammersmith & City")
        {
            hammersmith3Index = UnityEngine.Random.Range(0, hammersmithStations.Length);
            line3Station.text = hammersmithStations[hammersmith3Index];
        }
        else if (line3Line.text == "Jubilee")
        {
            jubilee3Index = UnityEngine.Random.Range(0, jubileeStations.Length);
            line3Station.text = jubileeStations[jubilee3Index];
        }
        else if (line3Line.text == "Metropolitan")
        {
            metro3Index = UnityEngine.Random.Range(0, metropolitanStations.Length);
            line3Station.text = metropolitanStations[metro3Index];
        }
        else if (line3Line.text == "Northern")
        {
            northern3Index = UnityEngine.Random.Range(0, northernStations.Length);
            line3Station.text = northernStations[northern3Index];
        }
        else if (line3Line.text == "Piccadilly")
        {
            piccadilly3Index = UnityEngine.Random.Range(0, piccadillyStations.Length);
            line3Station.text = piccadillyStations[piccadilly3Index];
        }
        else if (line3Line.text == "Victoria")
        {
            victoria3Index = UnityEngine.Random.Range(0, victoriaStations.Length);
            line3Station.text = victoriaStations[victoria3Index];
        }
        else
        {
            line3Station.text = noStations;
        }
        line3Station.color = lineColors[line3ColorIndex];
    }

    public void OnchangeStation3()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, changeStation3.transform);
        changeStation3.AddInteractionPunch(.5f);
        if (moduleSolved)
        {
            return;
        }
        if (line3Line.text == "Bakerloo")
        {
            bakerloo3Index = (bakerloo3Index + 1) % bakerlooStations.Length;
            line3Station.text = bakerlooStations[bakerloo3Index];
        }
        else if (line3Line.text == "Central")
        {
            central3Index = (central3Index + 1) % centralStations.Length;
            line3Station.text = centralStations[central3Index];
        }
        else if (line3Line.text == "Circle")
        {
            circle3Index = (circle3Index + 1) % circleStations.Length;
            line3Station.text = circleStations[circle3Index];
        }
        else if (line3Line.text == "District")
        {
            district3Index = (district3Index + 1) % districtStations.Length;
            line3Station.text = districtStations[district3Index];
        }
        else if (line3Line.text == "Hammersmith & City")
        {
            hammersmith3Index = (hammersmith3Index + 1) % hammersmithStations.Length;
            line3Station.text = hammersmithStations[hammersmith3Index];
        }
        else if (line3Line.text == "Jubilee")
        {
            jubilee3Index = (jubilee3Index + 1) % jubileeStations.Length;
            line3Station.text = jubileeStations[jubilee3Index];
        }
        else if (line3Line.text == "Metropolitan")
        {
            metro3Index = (metro3Index + 1) % metropolitanStations.Length;
            line3Station.text = metropolitanStations[metro3Index];
        }
        else if (line3Line.text == "Northern")
        {
            northern3Index = (northern3Index + 1) % northernStations.Length;
            line3Station.text = northernStations[northern3Index];
        }
        else if (line3Line.text == "Piccadilly")
        {
            piccadilly3Index = (piccadilly3Index + 1) % piccadillyStations.Length;
            line3Station.text = piccadillyStations[piccadilly3Index];
        }
        else if (line3Line.text == "Victoria")
        {
            victoria3Index = (victoria3Index + 1) % victoriaStations.Length;
            line3Station.text = victoriaStations[victoria3Index];
        }
        else
        {
            line3Station.text = noStations;
        }
    }

    public void OnsubmitButton()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, submitButton.transform);
        submitButton.AddInteractionPunch();
        if (moduleSolved)
        {
            return;
        }
        StationChecker1();
    }

    void LevelChecker()
    {
        if (levelsPassed == 0)
        {
            GetComponent<KMBombModule>().HandleStrike();
            light1.material.mainTexture = lightOff;
            light2.material.mainTexture = lightOff;
            light3.material.mainTexture = lightOff;
            Debug.LogFormat("[The London Underground #{0}] Module reset.", moduleId);
        }
        else if (levelsPassed == 1)
        {
            light1.material.mainTexture = lightOn;
            Audio.PlaySoundAtTransform("mindTheGap", transform);
        }
        else if (levelsPassed == 2)
        {
            light2.material.mainTexture = lightOn;
            Audio.PlaySoundAtTransform("mindTheGap", transform);
        }
        else if (levelsPassed == 3)
        {
            light3.material.mainTexture = lightOn;
            Audio.PlaySoundAtTransform("mindTheGap", transform);
            GetComponent<KMBombModule>().HandlePass();
            moduleSolved = true;
            Debug.LogFormat("[The London Underground #{0}] Module disarmed.", moduleId);
        }
        if (moduleSolved == false)
        {
            Start();
        }
        else
        {
            line1OptionsIndex = 10;
            line2OptionsIndex = 10;
            line3OptionsIndex = 10;
            line1ColorIndex = 10;
            line2ColorIndex = 10;
            line3ColorIndex = 10;
            line1Station.text = noStations;
            line2Station.text = noStations;
            line3Station.text = noStations;
            line1Line.text = lineOptions[line1OptionsIndex];
            line1Line.color = lineColors[line1ColorIndex];
            line2Line.text = lineOptions[line2OptionsIndex];
            line2Line.color = lineColors[line2ColorIndex];
            line3Line.text = lineOptions[line3OptionsIndex];
            line3Line.color = lineColors[line3ColorIndex];
            destinationText.text = noStations;
            departureText.text = noStations;
        }
    }
    void StationChecker1()
    {
        if (line1Line.text == "Bakerloo")
        {
            if (bakerlooStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                    Start();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Central")
        {
            if (centralStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Circle")
        {
            if (circleStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "District")
        {
            if (districtStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Hammersmith & City")
        {
            if (hammersmithStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Jubilee")
        {
            if (jubileeStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Metropolitan")
        {
            if (metropolitanStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Northern")
        {
            if (northernStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Piccadilly")
        {
            if (piccadillyStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line1Line.text == "Victoria")
        {
            if (victoriaStations.Any(departureStation.Contains))
            {
                if (line1Station.text == destinationStation && line2Station.text == " " && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}. Journey complete.", moduleId, line1Line.text, line1Station.text);
                    LevelChecker();
                }
                else if (line2Station.text != " ")
                {
                    StationChecker2();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}. That journey is not possible.", moduleId, line1Line.text, line1Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else
        {
            Debug.LogFormat("[The London Underground #{0}] Strike! You have not entered any stations.", moduleId);
            levelsPassed = 0;
            LevelChecker();
        }
    }

    void StationChecker2()
    {
        if (line2Line.text == "Bakerloo")
        {
            if (bakerlooStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Central")
        {
            if (centralStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Circle")
        {
            if (circleStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "District")
        {
            if (districtStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Hammersmith & City")
        {
            if (hammersmithStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Jubilee")
        {
            if (jubileeStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Metropolitan")
        {
            if (metropolitanStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Northern")
        {
            if (northernStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Piccadilly")
        {
            if (piccadillyStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line2Line.text == "Victoria")
        {
            if (victoriaStations.Any(line1Station.text.Contains))
            {
                if (line2Station.text == destinationStation && line3Station.text == " ")
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2} and the {3} line to {4}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    LevelChecker();
                }
                else if (line3Station.text != " ")
                {
                    StationChecker3();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2} and the {3} line to {4}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
    }

    void StationChecker3()
    {
        if (line3Line.text == "Bakerloo")
        {
            if (bakerlooStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Central")
        {
            if (centralStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Circle")
        {
            if (circleStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "District")
        {
            if (districtStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Hammersmith & City")
        {
            if (hammersmithStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Jubilee")
        {
            if (jubileeStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Metropolitan")
        {
            if (metropolitanStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Northern")
        {
            if (northernStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Piccadilly")
        {
            if (piccadillyStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
        else if (line3Line.text == "Victoria")
        {
            if (victoriaStations.Any(line2Station.text.Contains))
            {
                if (line3Station.text == destinationStation)
                {
                    levelsPassed++;
                    Debug.LogFormat("[The London Underground #{0}] Correct! You took the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. Journey complete.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    LevelChecker();
                }
                else
                {
                    Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                    levelsPassed = 0;
                    LevelChecker();
                }
            }
            else
            {
                Debug.LogFormat("[The London Underground #{0}] Strike! You attempted to take the {1} line to {2}, the {3} line to {4} and the {5} line to {6}. That journey is not possible.", moduleId, line1Line.text, line1Station.text, line2Line.text, line2Station.text, line3Line.text, line3Station.text);
                levelsPassed = 0;
                LevelChecker();
            }
        }
    }

#pragma warning disable 414
	private string TwitchHelpMessage = "Select a line and station for the top row with !{0} top circle embankment, substitute top for with middle or bottom for the middle and bottom rows respectivly. Use Hammersmith for the Hammersmith & City line. Submit with !{0} submit";
#pragma warning disable 414

	private IEnumerator ProcessTwitchCommand(string command)
	{
		command = command.Replace("’", "'");
		var commands = command.ToLowerInvariant().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (commands.Length < 3 && commands[0] != "submit")
			yield break;
		else if (commands[0] == "top")
		{
			var station = command.ToLowerInvariant().Substring(commands[0].Length + commands[1].Length + 1);
			yield return null;
			bool lineCorrect = false;
			int iteration = 0;
			while (!(lineCorrect || iteration == 11))
			{
				yield return changeLine1;
				yield return null;
				yield return changeLine1;
				yield return null;
				iteration++;
				if ((lineOptions[line1OptionsIndex].ToLowerInvariant() == commands[1]) || (commands[1] == "hammersmith" && lineOptions[line1OptionsIndex].ToLowerInvariant() == "hammersmith & city"))
					lineCorrect = true;
			}
			if (!lineCorrect)
			{
				yield return string.Format("sendtochaterror The specified line {0}, does not exist.", commands[1]);
				yield break;
			}
			else
			{
				switch (commands[1])
				{
					case "bakerloo":
						yield return null;
						bool bakerlooStationCorrect = false;
						iteration = 0;
						while (!(bakerlooStationCorrect || iteration == bakerlooStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								bakerlooStationCorrect = true;
						}
						if (!bakerlooStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "central":
						yield return null;
						bool centralStationCorrect = false;
						iteration = 0;
						while (!(centralStationCorrect || iteration == centralStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null; ;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								centralStationCorrect = true;
						}
						if (!centralStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "circle":
						yield return null;
						bool circleStationCorrect = false;
						iteration = 0;
						while (!(circleStationCorrect || iteration == circleStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								circleStationCorrect = true;
						}
						if (!circleStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "district":
						yield return null;
						bool districtStationCorrect = false;
						iteration = 0;
						while (!(districtStationCorrect || iteration == districtStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								districtStationCorrect = true;
						}
						if (!districtStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "hammersmith":
						yield return null;
						bool hammersmithStationCorrect = false;
						iteration = 0;
						while (!(hammersmithStationCorrect || iteration == hammersmithStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								hammersmithStationCorrect = true;
						}
						if (!hammersmithStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "jubilee":
						yield return null;
						bool jubileeStationCorrect = false;
						iteration = 0;
						while (!(jubileeStationCorrect || iteration == jubileeStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								jubileeStationCorrect = true;
						}
						if (!jubileeStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "metropolitan":
						yield return null;
						bool metropolitanStationCorrect = false;
						iteration = 0;
						while (!(metropolitanStationCorrect || iteration == metropolitanStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								metropolitanStationCorrect = true;
						}
						if (!metropolitanStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "northern":
						yield return null;
						bool northernStationCorrect = false;
						iteration = 0;
						while (!(northernStationCorrect || iteration == northernStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								northernStationCorrect = true;
						}
						if (!northernStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "piccadilly":
						yield return null;
						bool piccadillyStationCorrect = false;
						iteration = 0;
						while (!(piccadillyStationCorrect || iteration == piccadillyStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								piccadillyStationCorrect = true;
						}
						if (!piccadillyStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "victoria":
						yield return null;
						bool victoriaStationCorrect = false;
						iteration = 0;
						while (!(victoriaStationCorrect || iteration == victoriaStations.Length))
						{
							yield return changeStation1;
							yield return null;
							yield return changeStation1;
							yield return null;
							iteration++;
							if (line1Station.text.ToLowerInvariant().Trim() == station.Trim())
								victoriaStationCorrect = true;
						}
						if (!victoriaStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
				}
			}
		}
		else if (commands[0] == "middle")
		{
			var station = command.ToLowerInvariant().Substring(commands[0].Length + commands[1].Length + 1);
			yield return null;
			bool lineCorrect = false;
			int iteration = 0;
			while (!(lineCorrect || iteration == 11))
			{
				yield return changeLine2;
				yield return null;
				yield return changeLine2;
				yield return null;
				iteration++;
				if ((lineOptions[line2OptionsIndex].ToLowerInvariant() == commands[1]) || (commands[1] == "hammersmith" && lineOptions[line2OptionsIndex].ToLowerInvariant() == "hammersmith & city"))
					lineCorrect = true;
			}
			if (!lineCorrect)
			{
				yield return string.Format("sendtochaterror The specified line {0}, does not exist.", commands[1]);
				yield break;
			}
			else
			{
				switch (commands[1])
				{
					case "bakerloo":
						yield return null;
						bool bakerlooStationCorrect = false;
						iteration = 0;
						while (!(bakerlooStationCorrect || iteration == bakerlooStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								bakerlooStationCorrect = true;
						}
						if (!bakerlooStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "central":
						yield return null;
						bool centralStationCorrect = false;
						iteration = 0;
						while (!(centralStationCorrect || iteration == centralStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								centralStationCorrect = true;
						}
						if (!centralStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "circle":
						yield return null;
						bool circleStationCorrect = false;
						iteration = 0;
						while (!(circleStationCorrect || iteration == circleStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								circleStationCorrect = true;
						}
						if (!circleStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "district":
						yield return null;
						bool districtStationCorrect = false;
						iteration = 0;
						while (!(districtStationCorrect || iteration == districtStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								districtStationCorrect = true;
						}
						if (!districtStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "hammersmith":
						yield return null;
						bool hammersmithStationCorrect = false;
						iteration = 0;
						while (!(hammersmithStationCorrect || iteration == hammersmithStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								hammersmithStationCorrect = true;
						}
						if (!hammersmithStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "jubilee":
						yield return null;
						bool jubileeStationCorrect = false;
						iteration = 0;
						while (!(jubileeStationCorrect || iteration == jubileeStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								jubileeStationCorrect = true;
						}
						if (!jubileeStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "metropolitan":
						yield return null;
						bool metropolitanStationCorrect = false;
						iteration = 0;
						while (!(metropolitanStationCorrect || iteration == metropolitanStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								metropolitanStationCorrect = true;
						}
						if (!metropolitanStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "northern":
						yield return null;
						bool northernStationCorrect = false;
						iteration = 0;
						while (!(northernStationCorrect || iteration == northernStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								northernStationCorrect = true;
						}
						if (!northernStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "piccadilly":
						yield return null;
						bool piccadillyStationCorrect = false;
						iteration = 0;
						while (!(piccadillyStationCorrect || iteration == piccadillyStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								piccadillyStationCorrect = true;
						}
						if (!piccadillyStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "victoria":
						yield return null;
						bool victoriaStationCorrect = false;
						iteration = 0;
						while (!(victoriaStationCorrect || iteration == victoriaStations.Length))
						{
							yield return changeStation2;
							yield return null;
							yield return changeStation2;
							yield return null;
							iteration++;
							if (line2Station.text.ToLowerInvariant().Trim() == station.Trim())
								victoriaStationCorrect = true;
						}
						if (!victoriaStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
				}
			}
		}
		else if (commands[0] == "bottom")
		{
			var station = command.ToLowerInvariant().Substring(commands[0].Length + commands[1].Length + 1);
			yield return null;
			bool lineCorrect = false;
			int iteration = 0;
			while (!(lineCorrect || iteration == 11))
			{
				yield return changeLine3;
				yield return null;
				yield return changeLine3;
				yield return null;
				iteration++;
				if ((lineOptions[line3OptionsIndex].ToLowerInvariant() == commands[1]) || (commands[1] == "hammersmith" && lineOptions[line3OptionsIndex].ToLowerInvariant() == "hammersmith & city"))
					lineCorrect = true;
			}
			if (!lineCorrect)
			{
				yield return string.Format("sendtochaterror The specified line {0}, does not exist.", commands[1]);
				yield break;
			}
			else
			{
				switch (commands[1])
				{
					case "bakerloo":
						yield return null;
						bool bakerlooStationCorrect = false;
						iteration = 0;
						while (!(bakerlooStationCorrect || iteration == bakerlooStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								bakerlooStationCorrect = true;
						}
						if (!bakerlooStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "central":
						yield return null;
						bool centralStationCorrect = false;
						iteration = 0;
						while (!(centralStationCorrect || iteration == centralStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								centralStationCorrect = true;
						}
						if (!centralStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "circle":
						yield return null;
						bool circleStationCorrect = false;
						iteration = 0;
						while (!(circleStationCorrect || iteration == circleStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								circleStationCorrect = true;
						}
						if (!circleStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "district":
						yield return null;
						bool districtStationCorrect = false;
						iteration = 0;
						while (!(districtStationCorrect || iteration == districtStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								districtStationCorrect = true;
						}
						if (!districtStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "hammersmith":
						yield return null;
						bool hammersmithStationCorrect = false;
						iteration = 0;
						while (!(hammersmithStationCorrect || iteration == hammersmithStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								hammersmithStationCorrect = true;
						}
						if (!hammersmithStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "jubilee":
						yield return null;
						bool jubileeStationCorrect = false;
						iteration = 0;
						while (!(jubileeStationCorrect || iteration == jubileeStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								jubileeStationCorrect = true;
						}
						if (!jubileeStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "metropolitan":
						yield return null;
						bool metropolitanStationCorrect = false;
						iteration = 0;
						while (!(metropolitanStationCorrect || iteration == metropolitanStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								metropolitanStationCorrect = true;
						}
						if (!metropolitanStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "northern":
						yield return null;
						bool northernStationCorrect = false;
						iteration = 0;
						while (!(northernStationCorrect || iteration == northernStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								northernStationCorrect = true;
						}
						if (!northernStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "piccadilly":
						yield return null;
						bool piccadillyStationCorrect = false;
						iteration = 0;
						while (!(piccadillyStationCorrect || iteration == piccadillyStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								piccadillyStationCorrect = true;
						}
						if (!piccadillyStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
					case "victoria":
						yield return null;
						bool victoriaStationCorrect = false;
						iteration = 0;
						while (!(victoriaStationCorrect || iteration == victoriaStations.Length))
						{
							yield return changeStation3;
							yield return null;
							yield return changeStation3;
							yield return null;
							iteration++;
							if (line3Station.text.ToLowerInvariant().Trim() == station.Trim())
								victoriaStationCorrect = true;
						}
						if (!victoriaStationCorrect)
						{
							yield return string.Format("sendtochaterror The specified station, {0}, does not exist.", station);
							yield break;
						}
						break;
				}
			}
		}
		else if (commands[0] == "submit")
		{
			yield return null;
			yield return submitButton;
			yield return null;
			yield return submitButton;
		}
		else
		{
			yield break;
		}
	}
}
