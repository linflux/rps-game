using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPSGame.Domain.Entities;

namespace RPSGame.Tests
{
    [TestClass]
    public class MoveUnitTests
    {
        // Example setup for test cases
        private Rock _rock;
        private Paper _paper;
        private Scissors _scissors;
        private Lizard _lizard;
        private Spock _spock;
        private Gun _gun;
        private Lightning _lightning;
        private Devil _devil;
        private Water _water;
        private Air _air;
        private Sponge _sponge;
        private Fire _fire;
        private Dragon _dragon;
        private Tree _tree;
        private Human _human;
        private Wolf _wolf;
        private Snake _snake;

        [TestInitialize]
        public void Setup()
        {
            // Instantiate all moves
            _rock = new Rock();
            _paper = new Paper();
            _scissors = new Scissors();
            _lizard = new Lizard();
            _spock = new Spock();
            _gun = new Gun();
            _lightning = new Lightning();
            _devil = new Devil();
            _water = new Water();
            _air = new Air();
            _sponge = new Sponge();
            _fire = new Fire();
            _dragon = new Dragon();
            _tree = new Tree();
            _human = new Human();
            _wolf = new Wolf();
            _snake = new Snake();
        }

        // Example Test for Rock
        [TestMethod]
        public void RockBeatsScissorsAndLizard()
        {
            Assert.IsTrue(_rock.Beats(_scissors));
            Assert.IsTrue(_rock.Beats(_lizard));
        }

        [TestMethod]
        public void RockIsBeatenByPaperAndSpock()
        {
            Assert.IsFalse(_rock.Beats(_paper));
            Assert.IsFalse(_rock.Beats(_spock));
        }

        [TestMethod]
        public void RockTiesWithRock()
        {
            Assert.IsFalse(_rock.Beats(_rock));
        }

        // Example Test for Paper
        [TestMethod]
        public void PaperBeatsRockAndSpock()
        {
            Assert.IsTrue(_paper.Beats(_rock));
            Assert.IsTrue(_paper.Beats(_spock));
        }

        [TestMethod]
        public void PaperIsBeatenByScissorsAndLizard()
        {
            Assert.IsFalse(_paper.Beats(_scissors));
            Assert.IsFalse(_paper.Beats(_lizard));
        }

        [TestMethod]
        public void PaperTiesWithPaper()
        {
            Assert.IsFalse(_paper.Beats(_paper));
        }

        // Example Test for all new moves (Gun, Lightning, etc.)
        [TestMethod]
        public void GunBeatsRockDevilAndAir()
        {
            Assert.IsTrue(_gun.Beats(_rock));
            Assert.IsTrue(_gun.Beats(_devil));
            Assert.IsTrue(_gun.Beats(_air));
        }

        [TestMethod]
        public void GunIsBeatenByPaperAndWater()
        {
            Assert.IsFalse(_gun.Beats(_paper));
            Assert.IsFalse(_gun.Beats(_water));
        }

        [TestMethod]
        public void GunTiesWithGun()
        {
            Assert.IsFalse(_gun.Beats(_gun));
        }

        [TestMethod]
        public void LightningBeatsWaterSpongeAndDevil()
        {
            Assert.IsTrue(_lightning.Beats(_water));
            Assert.IsTrue(_lightning.Beats(_sponge));
            Assert.IsTrue(_lightning.Beats(_devil));
        }

        [TestMethod]
        public void LightningIsBeatenByTreeAndAir()
        {
            Assert.IsFalse(_lightning.Beats(_tree));
            Assert.IsFalse(_lightning.Beats(_air));
        }

        [TestMethod]
        public void LightningTiesWithLightning()
        {
            Assert.IsFalse(_lightning.Beats(_lightning));
        }

        // Repeat similar tests for Devil, Water, Air, Sponge, Fire, Dragon, Tree, Human, Wolf, and Snake

        [TestMethod]
        public void DevilBeatsSpongeFireAndAir()
        {
            Assert.IsTrue(_devil.Beats(_sponge));
            Assert.IsTrue(_devil.Beats(_fire));
            Assert.IsTrue(_devil.Beats(_air));
        }

        [TestMethod]
        public void DevilIsBeatenByGunAndLightning()
        {
            Assert.IsFalse(_devil.Beats(_gun));
            Assert.IsFalse(_devil.Beats(_lightning));
        }

        [TestMethod]
        public void DevilTiesWithDevil()
        {
            Assert.IsFalse(_devil.Beats(_devil));
        }
    }
}
