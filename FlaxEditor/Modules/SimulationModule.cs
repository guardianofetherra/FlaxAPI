// Flax Engine scripting API

using System;
using FlaxEditor.Scripting;
using FlaxEditor.States;
using FlaxEditor.Windows;
using FlaxEngine;

namespace FlaxEditor.Modules
{
    /// <summary>
    /// Manages play in-editor feature (game simulation).
    /// </summary>
    /// <seealso cref="FlaxEditor.Modules.EditorModule" />
    public sealed class SimulationModule : EditorModule
    {
        private bool _isPlayModeRequested;
        private bool _isPlayModeStopRequested;
        private EditorWindow _enterPlayFocusedWindow;

        internal SimulationModule(Editor editor)
            : base(editor)
        {
        }

        /// <summary>
        /// Checks if play mode should start only with single frame update and then enter step mode.
        /// </summary>
        public bool ShouldPlayModeStartWithStep => Editor.UI.IsPauseButtonChecked;

        /// <summary>
        /// Returns true if play mode has been requested.
        /// </summary>
        public bool IsPlayModeRequested => _isPlayModeRequested;

        /// <summary>
        /// Requests start playing in editor.
        /// </summary>
        public void RequestStartPlay()
        {
            // Check if is in edit mode
            if (Editor.StateMachine.IsEditMode)
            {
                Editor.Log("[PlayMode] Start");

                // Request to be compiled
                ScriptsBuilder.CheckForCompile();

                // Set flag
                _isPlayModeRequested = true;

                // Update
                Editor.UI.UpdateToolstrip();
            }
        }

        /// <summary>
        /// Requests stop playing in editor.
        /// </summary>
        public void RequestStopPlay()
        {
            // Check if is in play mode
            if (Editor.StateMachine.IsPlayMode)
            {
                Editor.Log("[PlayMode] Stop");

                // Set flag
                _isPlayModeStopRequested = true;

                // Update
                Editor.UI.UpdateToolstrip();
            }
        }

        /// <summary>
        /// Requests the playing start or stop in editor.
        /// </summary>
        public void RequestPlayOrStopPlay()
        {
            // Check if is in play mode
            if (Editor.StateMachine.IsPlayMode)
                RequestStopPlay();
            else
                RequestStartPlay();
        }

        /// <summary>
        /// Requests pause in playing.
        /// </summary>
        public void RequestPausePlay()
        {
            // Check if is in play mode and isn't paused
            if (Editor.StateMachine.IsPlayMode && !Editor.StateMachine.PlayingState.IsPaused)
            {
                Editor.Log("[PlayMode] Pause");

                // Pause
                Editor.StateMachine.PlayingState.IsPaused = true;

                // Update
                Editor.UI.UpdateToolstrip();
            }
        }

        /// <summary>
        /// Request resume in playing.
        /// </summary>
        public void RequestResumePlay()
        {
            // Check if is in play mode and is paused
            if (Editor.StateMachine.IsPlayMode && Editor.StateMachine.PlayingState.IsPaused)
            {
                Editor.Log("[PlayMode] Resume");

                // Resume
                Editor.StateMachine.PlayingState.IsPaused = false;

                // Update
                Editor.UI.UpdateToolstrip();
            }
        }

        /// <summary>
        /// Requests playing single frame in advance.
        /// </summary>
        public void RequestPlayOneFrame()
        {
            // Check if is in play mode and is paused
            if (Editor.StateMachine.IsPlayMode && Editor.StateMachine.PlayingState.IsPaused)
            {
                Editor.Log("[PlayMode] Step one frame");

                // TODO: step one frame using playing state internal logic
                throw new NotImplementedException("Step one frame in playmode");

                // Update
                Editor.UI.UpdateToolstrip();
            }
        }
        
        /// <inheritdoc />
        public override void OnPlayBegin()
        {
            Editor.Windows.FlashMainWindow();
            
            // Pick focused window to restore it
            var gameWin = Editor.Windows.GameWin;
            var editWin = Editor.Windows.EditWin;
            if (editWin != null && editWin.IsSelected)
                _enterPlayFocusedWindow = editWin;
            else if (gameWin != null && gameWin.IsSelected)
                _enterPlayFocusedWindow = gameWin;
            
            // Focus `Game` window
            gameWin?.FocusOrShow();

            Editor.Log("[PlayMode] Enter");
        }

        /// <inheritdoc />
        public override void OnPlayEnd()
        {
            // Restore focused window before play mode
            if (_enterPlayFocusedWindow != null)
            {
                _enterPlayFocusedWindow.FocusOrShow();
                _enterPlayFocusedWindow = null;
            }

            Editor.UI.UncheckPauseButton();

            Editor.Log("[PlayMode] Exit");
        }

        /// <inheritdoc />
        public override void OnUpdate()
        {
            // Check if can enter playing in editor mode
            if (Editor.StateMachine.CurrentState.CanEnterPlayMode)
            {
                // Check if play mode has been requested
                if (_isPlayModeRequested)
                {
                    // Check if editor has been compiled and scripting reloaded (there is no pending reload action)
                    if (ScriptsBuilder.IsReady && !SceneManager.IsAnyAsyncActionPending)
                    {
                        // Clear flag
                        _isPlayModeRequested = false;

                        // Enter play mode
                        Editor.StateMachine.GoToState<PlayingState>();

                        // Check if move just by one frame
                        if (ShouldPlayModeStartWithStep)
                        {
                            RequestPausePlay();
                        }
                    }
                }
                // Check if play mode exit has been requested
                else if (_isPlayModeStopRequested)
                {
                    // Clear flag
                    _isPlayModeStopRequested = false;

                    // Exit play mode
                    Editor.StateMachine.GoToState<EditingSceneState>();
                }
            }
            else
            {
                // Clear flags
                _isPlayModeRequested = false;
                _isPlayModeStopRequested = false;
            }
        }
    }
}
