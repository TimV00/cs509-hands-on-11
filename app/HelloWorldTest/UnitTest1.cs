namespace HelloWorldTest;

using HelloWorld;
using Xunit;
using FluentAssertions;
using Moq;
using AutoFixture;

public class UnitTest1
{
    private readonly Fixture _fixture = new Fixture();

    [Fact]
    public void f1_AddsOne()
    {
        var result = A.f1(1);
        result.Should().Be(2);
    }

    [Fact]
    public void f2_AddsTwo()
    {
        var result = A.f2(1);
        result.Should().Be(3);
    }

    [Fact]
    public void f3_AddsThree()
    {
        var result = TestA.ExposeF3(1);
        result.Should().Be(4);
    }

    [Fact]
    public void f4_AddsFour()
    {
        var x = Math.Abs(_fixture.Create<int>());
        var result = A.f4(x);
        result.Should().Be(x + 4);
    }

    [Fact]
    public void f5_IntegerDivision()
    {
        var result = A.f5(5, 2);
        result.Should().Be(2.0);
    }

    [Fact]
    public void f5_DivisionByZero()
    {
        Action act = () => A.f5(5, 0);
        act.Should().Throw<DivideByZeroException>();
    }

    [Fact]
    public void f5_TruncatesDecimal()
    {
        var result = A.f5(7, 2);
        result.Should().Be(3.0); // would be 3.5 if cast correctly
    }

    [Fact]
    public void f6_ThrowsOnNegative()
    {
        var negativeX = -_fixture.Create<int>().ToString().Length;
        Action act = () => A.f6(-1);
        act.Should().Throw<Exception>().WithMessage("x can't be negative");
    }

    [Fact]
    public void f6_ThrowsOnAnyNegative()
    {
        var x = -Math.Abs(_fixture.Create<int>()) - 1; // guaranteed negative
        Action act = () => A.f6(x);
        act.Should().Throw<Exception>().WithMessage("x can't be negative");
    }

    [Fact]
    public void f6_AddsFive()
    {
        var x = Math.Abs(_fixture.Create<int>()); // guaranteed non-negative
        var result = A.f6(x);
        result.Should().Be(x + 5);
    }

    [Fact]
    public void f7_AppendsMoreStuff()
    {
        var input = _fixture.Create<string>();
        var result = A.f7(input);
        result.Should().Be(input + " more stuff");
        result.Should().EndWith(" more stuff");
        result.Should().StartWith(input);
    }

    [Fact]
    public void f7_EmptyString()
    {
        var result = A.f7("");
        result.Should().Be(" more stuff");
    }

    [Fact]
    public void f7_NullString_ThrowsOrHandles()
    {
        Action act = () => A.f7(null);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void g1_CallsF8_WithMock()
    {
        var x = _fixture.Create<int>();

        var mockA = new Mock<A>();
        mockA.Setup(a => a.f8(x)).Returns(x + 8);

        var result = B.g1(x, mockA.Object);

        result.Should().Be(x + 8);
        mockA.Verify(a => a.f8(x), Times.Once);
    }
}

public class TestA : A
{
    public static int ExposeF3(int x) => f3(x);
}