using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Dame.Models.Checker;

namespace Dame.ViewModels
{
    class GameVM
    {
        private CheckerType[,] Board_array;
        private bool player_one_turn;
        private bool players_second_click;
        private List<Button> buttonList;
        private Button prevButton;
        private int row, column, prevRow, prevCol;
        private int p1_check_count, p2_check_count;
        public GameVM()
        {
            //buttonList = Board.Children.Cast<Button>().ToList();
            players_second_click = true;
        }
    }
}
