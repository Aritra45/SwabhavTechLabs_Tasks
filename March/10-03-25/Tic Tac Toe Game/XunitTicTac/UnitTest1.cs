using Tic_Tac_Toe_Game;

namespace XunitTicTac
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var check = new Game();
            bool result1 = check.IsWinner(Tic_Tac_Toe_Game.MarkType.X);
            Assert.False(result1);

            bool result2 = check.CheckRow(MarkType.X);
            Assert.False(result2);
        }
    }
}