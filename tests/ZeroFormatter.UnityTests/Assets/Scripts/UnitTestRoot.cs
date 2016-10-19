using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitTestRoot : MonoBehaviour
{
    static Dictionary<string, List<KeyValuePair<string, Action>>> tests = new Dictionary<string, List<KeyValuePair<string, Action>>>();

    public Button clearButton;
    public RectTransform list;
    public Scrollbar listScrollBar;

    public Text logText;
    public Scrollbar logScrollBar;

    void Start()
    {
        Application.logMessageReceived += (string condition, string stackTrace, LogType type) =>
        {
            if (type == LogType.Error || type == LogType.Exception)
            {
                logText.text += "<color=red>" + condition + "</color>\n";
            }
            else
            {
                logText.text += condition + "\n";
            }
            logScrollBar.value = 0;
        };

        clearButton.onClick.AddListener(() =>
        {
            logText.text = "";
        });

        foreach (var ___item in tests)
        {
            var actionList = ___item; // be careful, capture in lambda

            UnityAction groupAction = () =>
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                foreach (var btn in list.GetComponentsInChildren<Button>()) btn.interactable = false;

                logText.text += "<color=yellow>" + actionList.Key + "</color>\n";
                foreach (var item2 in actionList.Value)
                {
                    logText.text += "<color=teal>" + item2.Key + "</color>\n";
                    try
                    {
                        item2.Value();
                        logText.text += "OK" + "\n";
                    }
                    catch (Exception ex)
                    {
                        Debug.LogException(ex);
                    } // NG
                }

                sw.Stop();
                logText.text += "[" + actionList.Key + " Complete]" + sw.Elapsed.TotalMilliseconds + "ms\n\n";
                foreach (var btn in list.GetComponentsInChildren<Button>()) btn.interactable = true;
            };

            Add(actionList.Key, groupAction);
        }

        listScrollBar.value = 1;
        logScrollBar.value = 1;
    }

    void Add(string title, UnityAction test)
    {
        var newButton = GameObject.Instantiate(clearButton);
        newButton.name = title;
        newButton.onClick.RemoveAllListeners();
        newButton.GetComponentInChildren<Text>().text = title;
        newButton.onClick.AddListener(test);

        newButton.transform.SetParent(list);
    }

    public static void AddTest(string group, string title, Action test)
    {
        List<KeyValuePair<string, Action>> list;
        if (!tests.TryGetValue(group, out list))
        {
            list = new List<KeyValuePair<string, Action>>();
            tests[group] = list;
        }

        list.Add(new KeyValuePair<string, Action>(title, test));
    }
}