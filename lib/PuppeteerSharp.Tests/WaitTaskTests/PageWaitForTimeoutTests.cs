using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Nunit;

namespace PuppeteerSharp.Tests.WaitForTests
{
    public class PageWaitForTimeoutTests : PuppeteerPageBaseTest
    {
        public PageWaitForTimeoutTests() : base()
        {
        }

        [Test, Retry(2), PuppeteerTest("waittask.spec", "waittask specs Page.waitForTimeout", "waits for the given timeout before resolving")]
        public async Task WaitsForTheGivenTimeoutBeforeResolving()
        {
            await Page.GoToAsync(TestConstants.EmptyPage);
            var startTime = DateTime.UtcNow;
            await Page.WaitForTimeoutAsync(1000);
            var endTime = DateTime.UtcNow;
            Assert.True((endTime - startTime).TotalMilliseconds > 700);
            Assert.True((endTime - startTime).TotalMilliseconds < 1300);
        }
    }
}
