using NUnit.Framework;
using System.Globalization;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ForNode : ContainingNode
{
    public TMP_Text text;
    public int ExecuteXTimes;
    public override async Task GoThroughNodes()
    {
        Task[] tasks = new Task[ExecuteXTimes]; 
        for (int i = 0; i < ExecuteXTimes; i++)
        {
            tasks[i] = base.GoThroughNodes();
        }
        await Task.WhenAll(tasks);
    }

    public void OnValueChanged(string text)
    {
        if (!string.IsNullOrEmpty(text) && int.TryParse(text, out _) && int.Parse(text) > 0)
        {
            ExecuteXTimes = int.Parse(text);
        }
        else 
        {
            ExecuteXTimes = 1;
        }
        Debug.Log(ExecuteXTimes);
        this.text.text = ExecuteXTimes.ToString();
    }
}
