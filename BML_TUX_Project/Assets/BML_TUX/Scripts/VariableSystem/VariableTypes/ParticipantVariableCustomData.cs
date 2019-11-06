﻿using System;

namespace BML_TUX.Scripts.VariableSystem.VariableTypes {
    [Serializable]
    public class ParticipantVariableCustomData : ParticipantVariable<CustomSupportedDataType> {
        public ParticipantVariableCustomData() {
            DataType = SupportedDataType.CustomDataTypeNotYetImplemented;
        }

        public override void SelectValue(string value) {
            throw new NotImplementedException();
        }

        public override void AddValueFieldInEditor() {
            throw new NotImplementedException();
        }
    }
}