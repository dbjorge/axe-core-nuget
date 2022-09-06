#nullable enable

using Deque.AxeCore.Playwright.AxeContent;
using Deque.AxeCore.Playwright.AxeCoreWrapper;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Deque.AxeCore.Playwright
{
    /// <summary>
    /// Extensions for adding Axe to Playwright Locator.
    /// </summary>
    public static class LocatorExtensions
    {
        /// <summary>
        /// Runs Axe against the selected elements from a locator.
        /// </summary>
        /// <param name="locator">The Playwright Locator</param>
        /// <param name="options">Options for running Axe.</param>
        /// <returns>The AxeResults</returns>
        public static async Task<AxeResults> RunAxe(this ILocator locator, AxeRunOptions? options = null)
        {
            IAxeContentProvider axeContentProvider = new DefaultAxeContentProvider();
            IAxeContentEmbedder axeContentEmbedder = new DefaultAxeContentEmbedder(axeContentProvider);

            IAxeCoreWrapper axeCoreWrapper = new DefaultAxeCoreWrapper(axeContentEmbedder);

            return await axeCoreWrapper.RunOnLocator(locator, options);
        }
    }
}
