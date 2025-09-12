namespace NetDeque.Tests;


public class UnitTest1
{

    [Fact]
    public void NewDequeShouldBeEmpty()
    {
        var x = new Deque<int>();
        Assert.Equal(0, x.Count);
        Assert.True(x.IsEmpty);
    }
    [Fact]
    public void AddingItemToBeginning_ShouldAddItemToBeginning()
    {
        var x = new Deque<int>();
        x.AddBeg(3);
        x.AddBeg(4);
        Assert.Equal(4, x.PeekBeg());
    }
    [Fact]
    public void InsertionOrder_WhenAddingToBeginning_ShouldBeMaintained()
    {
        var x = new Deque<int>();
        x.AddBeg(3);
        x.AddBeg(4);
        Assert.Equal(4, x.RemBeg());
        Assert.Equal(3, x.RemBeg());
    }
    [Fact]
    public void AddingItemToEnd_ShouldAddItemToEnd()
    {
        var x = new Deque<int>();
        x.AddEnd(2);
        x.AddEnd(4);
        Assert.Equal(4, x.PeekEnd());
    }

    [Fact]
    public void InsertionOrder_WhenAddingToEnd_ShouldBeMaintained()
    {
        var x = new Deque<int>();
        x.AddEnd(3);
        x.AddEnd(4);
        Assert.Equal(4, x.RemEnd());
        Assert.Equal(3, x.RemEnd());
    }

    [Fact]
    public void RemovingFromBeginning_ShouldThrowWhenEmpty()
    {
        var x = new Deque<int>();
        Assert.Throws<InvalidOperationException>(() => x.RemBeg());
    }
    [Fact]
    public void RemovingFromBeginning_ShouldMaintainInsertionOrder()
    {
        var x = new Deque<int>();
        x.AddBeg(1);
        x.AddBeg(2);
        x.AddBeg(3);
        Assert.Equal(3, x.RemBeg());
        Assert.Equal(2, x.RemBeg());
        Assert.Equal(1, x.RemBeg());
        Assert.Equal(0, x.Count);
    }
    [Fact]
    public void RemovingFromEnd_ShouldThrowWhenEmpty()
    {
        var x = new Deque<int>();
        Assert.Throws<InvalidOperationException>(() => x.RemEnd());
    }
    [Fact]
    public void RemovingFromEnd_ShouldMaintainOrder()
    {
        var x = new Deque<int>();
        x.AddEnd(1);
        x.AddEnd(2);
        x.AddEnd(3);
        Assert.Equal(3, x.RemEnd());
        Assert.Equal(2, x.RemEnd());
        Assert.Equal(1, x.RemEnd());
        Assert.Equal(0, x.Count);
    }

    [Fact]
    public void PeekingEmptyDeque_ShouldThrow()
    {
        var x = new Deque<int>();
        Assert.Throws<InvalidOperationException>(() => x.PeekBeg());
        Assert.Throws<InvalidOperationException>(() => x.PeekEnd());
    }

    [Fact]
    public void Peeking_ShouldGiveCorrectValues()
    {
        var x = new Deque<int>();
        x.AddBeg(1000);
        x.AddBeg(2000);
        x.AddBeg(3000);
        Assert.Equal(1000, x.PeekEnd());
        Assert.Equal(3000, x.PeekBeg());
        Assert.Equal(3, x.Count);
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
        Assert.Equal(5, x.RemBeg());
        Assert.Equal(3, x.RemBeg());
        Assert.Equal(1, x.RemBeg());
        Assert.Equal(2, x.RemBeg());
        Assert.Equal(4, x.RemBeg());
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
        Assert.Equal(0, x.Count);
    }
    [Fact]
    public void BigInsertions_ShouldMaintainGeneralIntegrity()
    {
        var x = new Deque<int>();
        for (int i = 1; i <= 100; i++)
        {
            x.AddBeg(i);
        }
        Assert.Equal(100, x.Count);

        for (int i = 100; i > 0; i--)
        {
            Assert.Equal(i, x.RemBeg());
        }
        Assert.Equal(0, x.Count);

        for (int i = 1; i <= 100; i++)
        {
            x.AddEnd(i);
        }
        Assert.Equal(100, x.Count);

        for (int i = 100; i > 0; i--)
        {
            Assert.Equal(i, x.RemEnd());
        }
        Assert.Equal(0, x.Count);

    }     
    
}
