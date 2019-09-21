using System;
using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    public class EventRelatedTests
    {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            var presenter = new Presenter(mockView, mockLogger);
            mockView.Loaded += Raise.Event<Action>();
            
            mockView.Received()
                .Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void ctor_WhenViewHasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();
            
            var presenter = new Presenter(stubView, mockLogger);
            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");
            
            mockLogger.Received()
                .LogError(Arg.Is<string>(s => s.Contains("fake error")));

        }
    }
}