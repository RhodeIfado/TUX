﻿using System;
using UnityEditor;

namespace BML_TUX.Scripts.VariableSystem.VariableTypes {
    [Serializable]
    public class ParticipantVariableString : ParticipantVariable<string> {
        public ParticipantVariableString() {
            DataType = SupportedDataType.String;
        }

        public override void SelectValue(string value) {
            Value = value;
        }

        public override void AddValueFieldInEditor() {
            Value = EditorGUILayout.TextField(Value);
        }
    }
}