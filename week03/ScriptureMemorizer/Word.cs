

using System;
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide this word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show this word
    public void Show()
    {
        _isHidden = false;
    }

    // Returns whether the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the display text for this word:
    // - If visible: original text
    // - If hidden: underscores matching number of letters, preserving punctuation
    public string GetDisplayText()
    {
        if (!_isHidden) return _text;

        var sb = new StringBuilder();
        foreach (char c in _text)
        {
            // Replace letters and digits with underscores, keep punctuation/whitespace as-is
            if (char.IsLetterOrDigit(c))
            {
                sb.Append('_');
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
