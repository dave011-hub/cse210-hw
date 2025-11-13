

using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;
    private bool _hasRange;

       public Reference(string book, int chapter)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = -1;
        _verseEnd = -1;
        _hasRange = false;
    }

    // Constructor for single verse (book, chapter, verse)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
        _hasRange = true;
    }

    // Constructor for verse range (book, chapter, startVerse, endVerse)
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
        _hasRange = true;
    }

   
    public string GetDisplayText()
    {
        if (!_hasRange)
        {
            return $"{_book} {_chapter}";
        }
        else
        {
            if (_verseStart == _verseEnd)
            {
                return $"{_book} {_chapter}:{_verseStart}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
            }
        }
    }
}
