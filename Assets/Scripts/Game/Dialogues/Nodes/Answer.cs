﻿using System;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class Answer : Node
    {
        public Action onAnswerChoosen = () => { };
    }
}
