

using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    // Constructor: accepts Reference and the scripture text (single string)
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split on spaces to preserve punctuation on tokens (so punctuation stays attached to words)
        // This is simple and matches the typical class requirement.
        string[] tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string token in tokens)
        {
            _words.Add(new Word(token));
        }
    }

    // Returns the reference + the scripture display text (with hidden words replaced)
    public string GetDisplayText()
    {
        // Build scripture text by joining each word's display text with spaces
        var displayWords = _words.Select(w => w.GetDisplayText());
        string scriptureLine = string.Join(" ", displayWords);

        return $"{_reference.GetDisplayText()}\n\n{scriptureLine}";
    }

    // Hides up to 'count' random unhidden words.
    // If there are fewer than count unhidden words, hides them all.
    public void HideRandomWords(int count)
    {
        
        List<int> unhiddenIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                unhiddenIndices.Add(i);
        }

        if (unhiddenIndices.Count == 0) return;

        // Shuffle and take up to count indices
        for (int i = 0; i < count && unhiddenIndices.Count > 0; i++)
        {
            int pickIndex = _rand.Next(unhiddenIndices.Count);
            int wordIndex = unhiddenIndices[pickIndex];

            _words[wordIndex].Hide();

            // Remove that index so we don't pick it again
            unhiddenIndices.RemoveAt(pickIndex);
        }
    }

    // Returns true if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (var w in _words)
        {
            if (!w.IsHidden()) return false;
        }
        return true;
    }
}
