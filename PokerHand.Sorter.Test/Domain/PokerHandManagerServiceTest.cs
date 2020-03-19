using Moq;
using PokerHand.Sorter.Domain;
using PokerHand.Sorter.Model;
using Xunit;

namespace PokerHand.Sorter.Test.Domain
{
    public class PokerHandManagerServiceTest
    {
        [Fact]
        public void GetPokerHandsWinner_gets_winner_on_valid_input()
        {
            //given
            var input = "AH 9S 4D TD 8S 4H JS 3C TC 8D";
            var player1WinCount = 1;
            var moqPokerHandSortService = new Mock<IPokerHandSortService>();
            moqPokerHandSortService.Setup(m => m.GetPokerHandsWinner(It.IsAny<PokerHands>())).Returns(player1WinCount);

            var moqPokerHandsProviderService = new Mock<IPokerHandsProviderService>();

            moqPokerHandsProviderService.Setup(m => m.GetPokerHands(It.IsAny<string>())).Returns(new string[] { input });

            var moqConsole = new Mock<IConsole>();

            moqConsole.Setup(m => m.ReadLine()).Returns(input);
            moqConsole.Setup(m => m.WriteLine(It.IsAny<string>())).Verifiable();

            var sut = new PokerHandManagerService(moqPokerHandSortService.Object, moqPokerHandsProviderService.Object,moqConsole.Object);

            //when
            var result = sut.GetPokerHandsWinner();

            //then
            Assert.IsType<PokerHandsResult>(result);
            Assert.True(result.Player1 == player1WinCount);
            moqConsole.Verify(v => v.ReadLine(), Times.Once);
            moqConsole.Verify(v => v.WriteLine(It.IsAny<string>()), Times.Once);
            moqPokerHandsProviderService.Verify(v => v.GetPokerHands(It.IsAny<string>()), Times.Never);
            moqPokerHandSortService.Verify(v => v.GetPokerHandsWinner(It.IsAny<PokerHands>()), Times.Once);
        }
    }
}
