using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableController : MonoBehaviour
{
    [SerializeField] GameObject tableLine;

    [SerializeField] List<TableLine> lines = new List<TableLine>();

    public List<TableLine> Lines
    {
        get
        {
            return lines;
        }
        set
        {
            lines = value;
        }
    }

    public void RecreateTable(int countLines)
    {
        lines.Clear();

        TableLine line;

        for (int i = 0; i < countLines; i++)
        {
            line = Instantiate(tableLine, transform).GetComponent<TableLine>();

            Lines.Add(line);
        }
    }

    public void UpdateTable(List<Trader> traders)
    {
        int tradersCount = traders.Count;
        for (int i = 0; i < tradersCount; i++)
        {
            lines[i].Name.text = traders[i].TraderStandart.name;
            lines[i].Position.text = (tradersCount - i).ToString();
            lines[i].Gold.text = traders[i].Gold.ToString();
        }
    }


}
