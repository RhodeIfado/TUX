﻿using System;
using UnityEngine;

namespace BML_TUX.Scripts.VariableSystem.VariableTypes {
    [Serializable]
    public class ParticipantVariableVector2 : ParticipantVariable<Vector2> {
        public ParticipantVariableVector2() {
            DataType = SupportedDataType.Vector2;
        }

        public override void SelectValue(string value) {
            throw new NotImplementedException();
        }

        public override void AddValueFieldInEditor() {
            throw new NotImplementedException();
        }
    }
}