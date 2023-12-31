using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Blank : MonoBehaviour, IDropHandler
{
    public Word word;
    public string targetText;

    public bool SetRight()
    {
        if (word != null)
        {
            return string.Equals(word.text.text, targetText, StringComparison.OrdinalIgnoreCase);
            
            // return word.text.text == targetText;
        }
        else
        {
            return false;
        }
    }
    
    public bool IsSet()
    {
        return word != null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped in blank");
        if (eventData.pointerDrag != null)
        {
            if (word != null && word != eventData.pointerDrag.GetComponent<Word>().copy)
            {
                Destroy(word.gameObject);
            }
            word = eventData.pointerDrag.GetComponent<Word>().copy;
            word.transform.position = transform.position;
            word.Contrast();
            word.inBlank = true;
            word.transform.SetParent(transform);
        }
    }
}
