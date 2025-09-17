using FluentAssertions;

namespace NetDeque.Tests;


public class UnitTest1
{

    [Fact]
    public void NewDequeShouldBeEmpty()
    {
        var x = new Deque<int>();

        x.Count.Should().Be(0);
        x.IsEmpty.Should().Be(true);
        // Assert.Equal(0, x.Count);
        // Assert.True(x.IsEmpty);
    }
    [Fact]
    public void AddingItemToBeginning_ShouldAddItemToBeginning()
    {
        var x = new Deque<int>();
        x.AddBeg(3);
        x.AddBeg(4);
        x.PeekBeg().Should().Be(4);
        // Assert.Equal(4, x.PeekBeg());
    }
    [Fact]
    public void InsertionOrder_WhenAddingToBeginning_ShouldBeMaintained()
    {
        var x = new Deque<int>();
        x.AddBeg(3);
        x.AddBeg(4);
        x.RemBeg().Should().Be(4);
        x.RemBeg().Should().Be(3);
        // Assert.Equal(4, x.RemBeg());
        // Assert.Equal(3, x.RemBeg());
    }
    [Fact]
    public void AddingItemToEnd_ShouldAddItemToEnd()
    {
        var x = new Deque<int>();
        x.AddEnd(2);
        x.AddEnd(4);
        x.PeekEnd().Should().Be(4);
        // Assert.Equal(4, x.PeekEnd());
    }

    [Fact]
    public void InsertionOrder_WhenAddingToEnd_ShouldBeMaintained()
    {
        var x = new Deque<int>();
        x.AddEnd(3);
        x.AddEnd(4);
        4.Should().Be(x.RemEnd());
        3.Should().Be(x.RemEnd());
        // Assert.Equal(4, x.RemEnd());
        // Assert.Equal(3, x.RemEnd());
    }

    [Fact]
    public void RemovingFromBeginning_ShouldThrowWhenEmpty()
    {
        var x = new Deque<int>();
        Action act = () =>
        {
            x.RemBeg();
        };

        act.Should().ThrowExactly<InvalidOperationException>();
        // Assert.Throws<InvalidOperationException>(() => x.RemBeg());
    }
    [Fact]
    public void RemovingFromBeginning_ShouldMaintainInsertionOrder()
    {
        var x = new Deque<int>();
        x.AddBeg(1);
        x.AddBeg(2);
        x.AddBeg(3);
        x.RemBeg().Should().Be(3);
        x.RemBeg().Should().Be(2);
        x.RemBeg().Should().Be(1);
        x.Count.Should().Be(0);

        // Assert.Equal(3, x.RemBeg());
        // Assert.Equal(2, x.RemBeg());
        // Assert.Equal(1, x.RemBeg());
        // Assert.Equal(0, x.Count);
    }
    [Fact]
    public void RemovingFromEnd_ShouldThrowWhenEmpty()
    {
        var x = new Deque<int>();
        var act = () => x.RemEnd();

        act.Should().ThrowExactly<InvalidOperationException>();
        // Assert.Throws<InvalidOperationException>(() => x.RemEnd());
    }
    [Fact]
    public void RemovingFromEnd_ShouldMaintainOrder()
    {
        var x = new Deque<int>();
        x.AddEnd(1);
        x.AddEnd(2);
        x.AddEnd(3);

        x.RemEnd().Should().Be(3);
        x.RemEnd().Should().Be(2);
        x.RemEnd().Should().Be(1);
        x.Count.Should().Be(0);

        // Assert.Equal(3, x.RemEnd());
        // Assert.Equal(2, x.RemEnd());
        // Assert.Equal(1, x.RemEnd());
        // Assert.Equal(0, x.Count);
    }

    [Fact]
    public void PeekingEmptyDeque_ShouldThrow()
    {
        var x = new Deque<int>();

        var peek_beg = () => x.PeekBeg();
        var peek_end = () => x.PeekBeg();

        peek_beg.Should().ThrowExactly<InvalidOperationException>();
        peek_end.Should().ThrowExactly<InvalidOperationException>();

        // Assert.Throws<InvalidOperationException>(() => x.PeekBeg());
        // Assert.Throws<InvalidOperationException>(() => x.PeekEnd());
    }

    [Fact]
    public void Peeking_ShouldGiveCorrectValues()
    {
        var x = new Deque<int>();
        x.AddBeg(1000);
        x.AddBeg(2000);
        x.AddBeg(3000);

        x.PeekEnd().Should().Be(1000);
        x.PeekBeg().Should().Be(3000);
        x.Count.Should().Be(3);

        // Assert.Equal(1000, x.PeekEnd());
        // Assert.Equal(3000, x.PeekBeg());
        // Assert.Equal(3, x.Count);
    }

    [Fact]
    public void InsertingAtBeginningAndEnd_ShouldMaintainOrder()
    {
        var x = new Deque<int>();
        x.AddBeg(1);
        x.AddEnd(2);
        x.AddBeg(3);
        x.AddEnd(4);
        x.AddBeg(5);

        // 5 3 1 2 4

        x.RemBeg().Should().Be(5);
        x.RemBeg().Should().Be(3);
        x.RemBeg().Should().Be(1);
        x.RemBeg().Should().Be(2);
        x.RemBeg().Should().Be(4);

        // Assert.Equal(5, x.RemBeg());
        // Assert.Equal(3, x.RemBeg());
        // Assert.Equal(1, x.RemBeg());
        // Assert.Equal(2, x.RemBeg());
        // Assert.Equal(4, x.RemBeg());
    }
    [Fact]
    public void InsertingAndRemoving_ShouldCreateNoGhosts()
    {
        var x = new Deque<int>();
        for (int i = 0; i < 100; i++)
        {
            if ((i & 0b1) == 0)
                x.AddBeg(i);
            else
                x.AddEnd(i);
        }
        for (int i = 0; i < 100; i++)
        {
            if ((i & 0b1) == 0)
                x.RemBeg();
            else
                x.RemEnd();
        }
        x.Count.Should().Be(0);

        // Assert.Equal(0, x.Count);
    }
    [Fact]
    public void BigInsertions_ShouldMaintainGeneralIntegrity()
    {
        var x = new Deque<int>();
        for (int i = 1; i <= 100; i++)
        {
            x.AddBeg(i);
        }
        x.Count.Should().Be(100);
        //Assert.Equal(100, x.Count);

        for (int i = 100; i > 0; i--)
        {
            x.RemBeg().Should().Be(i);
            // Assert.Equal(i, x.RemBeg());
        }

        x.Count.Should().Be(0);
        //Assert.Equal(0, x.Count);

        for (int i = 1; i <= 100; i++)
        {
            x.AddEnd(i);
        }

        x.Count.Should().Be(100);

        // Assert.Equal(100, x.Count);

        for (int i = 100; i > 0; i--)
        {
            x.RemEnd().Should().Be(i);
            // Assert.Equal(i, x.RemEnd());
        }
        x.Count.Should().Be(0);
        //Assert.Equal(0, x.Count);
    }     
    
}
