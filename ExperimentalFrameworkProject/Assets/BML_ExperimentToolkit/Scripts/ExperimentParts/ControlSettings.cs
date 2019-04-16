﻿using System.Collections;
using System.Collections.Generic;
using BML_ExperimentToolkit.Scripts.Managers;
using BML_Utilities;
using UnityEngine;

namespace BML_ExperimentToolkit.Scripts.ExperimentParts {

    [CreateAssetMenu(menuName = MenuNames.BmlAssetMenu + "Create Control Settings Asset")]
    public class ControlSettings : ScriptableObject {
        public List<KeyCode> InterruptKeys;
        public List<KeyCode> BackKeys;
        public List<KeyCode> NextKeys;

        /// <summary>
        /// Allows experimenter to control the experiments and jump between trials.
        /// </summary>
        /// <returns></returns>
        public IEnumerator Run() {
            const bool running = true;

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            while (running) {

                foreach (KeyCode interruptKey in InterruptKeys) {
                    if (Input.GetKeyDown(interruptKey)) {
                        ExperimentEvents.InterruptTrial();
                    }
                }

                foreach (KeyCode backKey in BackKeys) {
                    if (Input.GetKeyDown(backKey)) {
                        ExperimentEvents.GoBackOneTrial();
                    }
                }

                foreach (KeyCode nextKey in NextKeys) {
                    if (Input.GetKeyDown(nextKey)) {
                        ExperimentEvents.SkipToNextTrial();
                    }
                }

                yield return null;

            }
            // ReSharper disable once IteratorNeverReturns
        }

    }
}