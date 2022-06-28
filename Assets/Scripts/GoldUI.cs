using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public static GoldUI Instance { get; private set; }

    private class ActiveText
    {
        public Text UItext;
        public float maxTime;
        public float Timer;
        public Vector3 unitPosition;

        public void moveText(Camera camera)
        {
            float delta = 1.0f - (Timer / maxTime);
            Vector3 pos = unitPosition - new Vector3(delta, delta, 0.0f);
            pos = camera.WorldToScreenPoint(pos);
            pos.z = 0.0f;

            UItext.transform.position = pos;
        }
    }

    public Text _TextPref;

    const int POOL_SIZE = 16;

    Queue<Text> _TextPool = new Queue<Text>();
    List<ActiveText> _activeTexts = new List<ActiveText>();


    private void Awake()
    {
        Instance = this;
    }

    Camera _camera;
    Transform _transform;

    private void Start()
    {
        _camera = Camera.main;
        _transform = this.transform;

        for (int i = 0; i < POOL_SIZE; i++)
        {
            Text temp = Instantiate(_TextPref, _transform);
            temp.gameObject.SetActive(false);
            _TextPool.Enqueue(temp);
        }
    }

    private void Update()
    {
        for (int i = 0; i < _activeTexts.Count; i++)
        {
            ActiveText at = _activeTexts[i];
            at.Timer -= Time.deltaTime;

            if (at.Timer <= 0.0f)
            {
                at.UItext.gameObject.SetActive(false);
                _TextPool.Enqueue(at.UItext);
                _activeTexts.RemoveAt(i);
                --i;
            }
            else
            {
                var color = at.UItext.color;
                color.a = at.Timer / at.maxTime;
                at.UItext.color = color;

                at.moveText(_camera);
            }
        }
    }

    public void AddText(string amount, Vector3 unitPos)
    {
        var t = _TextPool.Dequeue();
        t.text = amount;
        t.gameObject.SetActive(true);

        ActiveText at = new ActiveText() { maxTime = 3f };
        at.Timer = at.maxTime;
        at.UItext = t;
        at.unitPosition = unitPos + Vector3.up;

        at.moveText(_camera);
        _activeTexts.Add(at);
    }
}
