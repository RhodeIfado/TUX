﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using bmlTUX.Scripts.ExperimentParts;
using UnityEngine;

namespace bmlTUX.Scripts.Managers {



    public class BlockSequenceRunner {
        readonly ExperimentRunner runner;
        readonly List<Block> blocks;

        Block currentlyRunningBlock;
        public bool Running = false;

        public BlockSequenceRunner(ExperimentRunner runner, List<Block> blocks) {
            OnEnable();
            this.runner = runner;
            this.blocks = blocks;
        }


        void OnEnable() {
            ExperimentEvents.OnBlockCompleted += BlockDoneRunning;
            ExperimentEvents.OnJumpToBlock += JumpToBlock;
        }

        void OnDisable() {
            ExperimentEvents.OnBlockCompleted -= BlockDoneRunning;
            ExperimentEvents.OnJumpToBlock -= JumpToBlock;
        }


        public void Start() {

            if (blocks.Count <= 0) {
                throw new InvalidDataException("Runner blocks not created correctly");
            }

            Running = true;
            //Debug.Log("Starting to run Blocks");
            StartRunningBlock(blocks[0]);
        }


        void StartRunningBlock(Block block) {

            currentlyRunningBlock = block;
            Debug.Log("");
            Debug.Log($"*****\nStarting Block {BlockIndex(currentlyRunningBlock)} of {blocks.Count}");
            ExperimentEvents.BlockHasStarted(block);
            ExperimentEvents.StartPart(block);

        }

        IEnumerator RunPostBlock() {
            
            FinishBlock();
            GoToNextBlock();
            yield return null;
        }



        void GoToNextBlock() {
            int newIndex = BlockIndex(currentlyRunningBlock) + 1;

            if (newIndex > blocks.Count - 1) {
                DoneBlockSequence();
            }
            else {
                Block nextBlock = blocks[newIndex];
                StartRunningBlock(nextBlock);
            }
        }

        void FinishBlock() {
            int blockNum = BlockIndex(currentlyRunningBlock);
            Debug.Log($"Done block {blockNum + 1}\n {currentlyRunningBlock.AsString()}");
            currentlyRunningBlock.Complete = true;
            ExperimentEvents.UpdateBlock(blocks, BlockIndex(currentlyRunningBlock));
        }

        void BlockDoneRunning(Block unused) {
            runner.StartCoroutine(RunPostBlock());
        }

        void DoneBlockSequence() {
            Debug.Log("---------------\nDone all blocks");

            ExperimentEvents.BlockSequenceHasCompleted(blocks);
            ExperimentEvents.EndExperiment();
            Running = false;
            OnDisable();
        }

        void JumpToBlock(int jumpToIndex) {
            Debug.Log("Got jump event");
            FinishBlock();
            StartRunningBlock(blocks[jumpToIndex]);
        }

        int BlockIndex(Block block) {
            return blocks.IndexOf(block);
        }

    }
}