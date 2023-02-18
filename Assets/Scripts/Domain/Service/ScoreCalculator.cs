using System;
using Domain.Model;
using UnityEngine;

namespace Domain.Service
{
    public class ScoreCalculator
    {
        public int Calc(Board board)
        {
            var blockCount = 0;
            
            for (int y = Board.DEFAULT_ATTIC_HEIGHT; y < Board.DEFAULT_HEIGHT; y++)
            {
                for (int x = 0; x < Board.DEFAULT_WIDTH; x++)
                {
                    if (board.board[y,x] == Board.State.Block || board.board[y,x] == Board.State.Trap)
                    {
                        blockCount++;
                    }
                }
            }
            
            return (int)(blockCount*100f / ((Board.DEFAULT_HEIGHT - Board.DEFAULT_ATTIC_HEIGHT) * Board.DEFAULT_WIDTH));
        }
    }
}