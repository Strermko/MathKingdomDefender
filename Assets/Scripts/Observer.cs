using UnityEngine;


public class Observer : MonoBehaviour
{
    // Serialized object, for more clear code and separated scripts to pointed object
    [Header("Main Game Objects")]
    [SerializeField] GameObject lifes;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject answers;
    [SerializeField] GameObject points;
    [SerializeField] GameObject effects;
    [SerializeField] GameObject buttons;

    [Header("Parameters")]
    [Range(0f, 100f)][SerializeField] float timerSpeed = 10;
    [Range(0f, 100f)][SerializeField] float timerSpeedBoost = 10;
    [SerializeField] int pointsToAdd;


    private Lifes _lifes;
    private Timer _timer;
    private Answers _answers;
    private Points _points;
    private Effects _effects;
    private Buttons _buttons;
    private int clickCounter; // <=== Find the way to remove it
    private SceneLoader sceneLoader;

    void Start() { StartConfiguration(); }

    void Update() { Observe(); }

    private void StartConfiguration()
    {
        // Get classes from gameObjects
        _lifes = lifes.GetComponent<Lifes>();
        _timer = timer.GetComponent<Timer>();
        _answers = answers.GetComponent<Answers>();
        _points = points.GetComponent<Points>();
        _points.SetValue(0); //<<<--Temporary, before I find a way to memorize this--// 
        _effects = effects.GetComponent<Effects>();
        _buttons = buttons.GetComponent<Buttons>();

        // Bassic function and components
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        ResetFields();
    }

    private void Observe()
    {
        if (_timer.SliderMovement(timerSpeed)) { _lifes.RemoveHealth(); }
        if (_lifes.IsDead()) sceneLoader.LoadScene("GameOver");
    }

    public void ClickEvent()
    {
        _answers.SetBoxValue(clickCounter, _buttons.ClickEvent());
        CheckAnswers();
    }

    private void CheckAnswers()
    {
        if (clickCounter == 2)
        {
            if (_answers.CheckAnswers())
            {
                _points.IncreaseValue(pointsToAdd);
                _effects.GoodOut();
                _timer.AddVelocity(timerSpeedBoost);
            }
            else { _effects.BadOut(); _lifes.RemoveHealth(); }
            ResetFields();
        }
        else { clickCounter += 1; }
    }



    private void ResetFields()
    {
        _answers.ResetValues();
        _timer.ResetValue();
        _buttons.ResetValues();

        clickCounter = 0; // <=== Find a way to remove this..
    }
}