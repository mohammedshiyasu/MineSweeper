namespace MineSweeperTests
{
    [TestFixture]
    public class MineSweeperTests
    {
        [Test]
        public void TestConstructor()
        {
            var game = new MineSweeper(4, 2);
            Assert.IsNotNull(game);
        }

        [Test]
        public void TestRevealMine()
        {
            var game = new MineSweeper(4, 2);
            bool result = true;

            // Since the mines are placed randomly, we need to check all squares
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result = game.Reveal(i, j);
                    if (!result)
                    {
                        break;
                    }
                }
                if (!result)
                {
                    break;
                }
            }

            Assert.IsFalse(result);
        }

        [Test]
        public void TestRevealSafeSquare()
        {
            var game = new MineSweeper(4, 2);
            bool result = true;

            // Since the mines are placed randomly, we need to check all squares
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result = game.Reveal(i, j);
                    if (result)
                    {
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void TestRevealOutOfBounds()
        {
            var game = new MineSweeper(4, 2);
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Reveal(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Reveal(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Reveal(4, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Reveal(0, 4));
        }
    }
}