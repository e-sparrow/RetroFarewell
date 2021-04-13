using System;
using System.Collections.Generic;

namespace Game.Lore.Notes
{
    [Serializable]
    public class Note
    {
        public string name;
        public List<Paragraph> paragraphs;

        public bool hidden;
    }
}