using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPSGame.Domain.Entities;
using RPSGame.Application.Services;
using RPSGame.Infrastructure.Services;

namespace RPSGame.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        private DefaultMoveEvaluator _evaluator;
        private GameService _gameService;

        [TestInitialize]
        public void Setup()
        {
            _evaluator = new DefaultMoveEvaluator();
            _gameService = new GameService(_evaluator);
        }

        [TestMethod]
        public void RockBeatsScissors()
        {
            var result = _gameService.Play("Rock", "Scissors");
            Assert.AreEqual("Rock beats Scissors!", result);
        }

        [TestMethod]
        public void PaperBeatsRock()
        {
            var result = _gameService.Play("Paper", "Rock");
            Assert.AreEqual("Paper beats Rock!", result);
        }

        [TestMethod]
        public void ScissorsBeatsPaper()
        {
            var result = _gameService.Play("Scissors", "Paper");
            Assert.AreEqual("Scissors beats Paper!", result);
        }

        [TestMethod]
        public void LizardBeatsSpock()
        {
            var result = _gameService.Play("Lizard", "Spock");
            Assert.AreEqual("Lizard beats Spock!", result);
        }

        [TestMethod]
        public void SpockBeatsRock()
        {
            var result = _gameService.Play("Spock", "Rock");
            Assert.AreEqual("Spock beats Rock!", result);
        }

        [TestMethod]
        public void GunBeatsRock()
        {
            var result = _gameService.Play("Gun", "Rock");
            Assert.AreEqual("Gun beats Rock!", result);
        }

        [TestMethod]
        public void LightningBeatsWater()
        {
            var result = _gameService.Play("Lightning", "Water");
            Assert.AreEqual("Lightning beats Water!", result);
        }

        [TestMethod]
        public void DevilBeatsFire()
        {
            var result = _gameService.Play("Devil", "Fire");
            Assert.AreEqual("Devil beats Fire!", result);
        }

        [TestMethod]
        public void WaterBeatsFire()
        {
            var result = _gameService.Play("Water", "Fire");
            Assert.AreEqual("Water beats Fire!", result);
        }

        [TestMethod]
        public void AirBeatsLightning()
        {
            var result = _gameService.Play("Air", "Lightning");
            Assert.AreEqual("Air beats Lightning!", result);
        }

        [TestMethod]
        public void SpongeBeatsRock()
        {
            var result = _gameService.Play("Sponge", "Rock");
            Assert.AreEqual("Sponge beats Rock!", result);
        }

        [TestMethod]
        public void FireBeatsSponge()
        {
            var result = _gameService.Play("Fire", "Sponge");
            Assert.AreEqual("Fire beats Sponge!", result);
        }

        [TestMethod]
        public void DragonBeatsWolf()
        {
            var result = _gameService.Play("Dragon", "Wolf");
            Assert.AreEqual("Dragon beats Wolf!", result);
        }

        [TestMethod]
        public void TreeBeatsPaper()
        {
            var result = _gameService.Play("Tree", "Paper");
            Assert.AreEqual("Tree beats Paper!", result);
        }

        [TestMethod]
        public void HumanBeatsSnake()
        {
            var result = _gameService.Play("Human", "Snake");
            Assert.AreEqual("Human beats Snake!", result);
        }

        [TestMethod]
        public void WolfBeatsHuman()
        {
            var result = _gameService.Play("Wolf", "Human");
            Assert.AreEqual("Wolf beats Human!", result);
        }

        [TestMethod]
        public void SnakeBeatsLizard()
        {
            var result = _gameService.Play("Snake", "Lizard");
            Assert.AreEqual("Snake beats Lizard!", result);
        }

        [TestMethod]
        public void Rock_Beats_Seven_Moves()
        {
            var moveRules = new MoveRules();
            var rockBeats = new List<string> { "Scissors", "Lizard", "Sponge", "Fire", "Snake", "Human", "Wolf" };

            foreach (var move in rockBeats)
            {
                Assert.True(moveRules.Beats("Rock", move));
            }
        }

        [TestMethod]
        public void Rock_Does_Not_Beat_Invalid_Moves()
        {
            var moveRules = new MoveRules();
            var invalidMoves = new List<string> { "Paper", "Spock", "Dragon", "Tree", "Water", "Air", "Lightning" };

            foreach (var move in invalidMoves)
            {
                Assert.False(moveRules.Beats("Rock", move));
            }
        }
    }
}
