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
        var x = new NetDeque<int>();
        Assert.Throws<InvalidOperationException>(() => x.RemFirst());
    }
     
}
