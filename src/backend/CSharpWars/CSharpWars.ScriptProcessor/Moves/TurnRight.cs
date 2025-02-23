﻿using CSharpWars.Enums;
using CSharpWars.Scripting.Model;
using CSharpWars.ScriptProcessor.Middleware;

namespace CSharpWars.ScriptProcessor.Moves
{
    /// <summary>
    /// Class containing logic for turning right.
    /// </summary>
    /// <remarks>
    /// Performing this move makes the robot turn clockwise by 90°.
    /// This move does not consume stamina because the robot will not move away from its current location in the arena grid.
    /// </remarks>
    public class TurnRight : Move
    {
        public TurnRight(BotProperties botProperties) : base(botProperties) { }

        public override BotResult Go()
        {
            // Build result based on current properties.
            var botResult = BotResult.Build(BotProperties);

            botResult.Move = PossibleMoves.TurningRight;

            switch (BotProperties.Orientation)
            {
                case PossibleOrientations.North:
                    botResult.Orientation = PossibleOrientations.East;
                    break;
                case PossibleOrientations.East:
                    botResult.Orientation = PossibleOrientations.South;
                    break;
                case PossibleOrientations.South:
                    botResult.Orientation = PossibleOrientations.West;
                    break;
                case PossibleOrientations.West:
                    botResult.Orientation = PossibleOrientations.North;
                    break;
            }

            return botResult;
        }
    }
}