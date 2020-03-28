using Shouldly;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Rss
{
    public class RssTests : BaseTest
    {
        [Fact]
        public async Task ListFeeds()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(RssTests)).Location)}/Rss/Data/get_list_feeds.json"));

            var feeds = await PutioApiClient.Rss.ListFeeds();
            feeds.ShouldNotBeNull();
            feeds.Count.ShouldBe(2);

            var firstFeed = feeds.First();
            firstFeed.Id.ShouldBe(45435);
            firstFeed.Title.ShouldBe("Example RSS Feed 2");
            firstFeed.RssSourceUrl.ShouldBe("http://example.com/feed.rss");
            firstFeed.ParentDirectoryId.ShouldBe(1);
            firstFeed.DeleteOldFiles.ShouldBeTrue();
            firstFeed.Keyword.ShouldBe("Keyword1,Keyword2");
            firstFeed.Paused.ShouldBeTrue();
            firstFeed.PausedAt.ShouldNotBeNull();

            firstFeed.PausedAt.Value.Year.ShouldBe(2018);
            firstFeed.PausedAt.Value.Month.ShouldBe(10);
            firstFeed.PausedAt.Value.Day.ShouldBe(5);
            firstFeed.PausedAt.Value.Hour.ShouldBe(16);
            firstFeed.PausedAt.Value.Minute.ShouldBe(58);
            firstFeed.PausedAt.Value.Second.ShouldBe(46);

            firstFeed.CreatedAt.ShouldNotBeNull();
            firstFeed.UpdatedAt.ShouldNotBeNull();
            firstFeed.StartedAt.ShouldNotBeNull();
            

            var secondFeed = feeds.Last();
            secondFeed.Id.ShouldBe(45436);
            secondFeed.Title.ShouldBe("Example RSS Feed 2");
            secondFeed.RssSourceUrl.ShouldBe("http://example.com/feed.rss");
            secondFeed.ParentDirectoryId.ShouldBe(2);
            secondFeed.DeleteOldFiles.ShouldBeFalse();
            secondFeed.Keyword.ShouldBeNull();
            secondFeed.Paused.ShouldBeFalse();
            secondFeed.PausedAt.ShouldBeNull();

            secondFeed.CreatedAt.ShouldNotBeNull();
            secondFeed.CreatedAt.Year.ShouldBe(2018);
            secondFeed.CreatedAt.Month.ShouldBe(10);
            secondFeed.CreatedAt.Day.ShouldBe(5);
            secondFeed.CreatedAt.Hour.ShouldBe(13);
            secondFeed.CreatedAt.Minute.ShouldBe(58);
            secondFeed.CreatedAt.Second.ShouldBe(46);
    
            secondFeed.UpdatedAt.ShouldNotBeNull();
            secondFeed.StartedAt.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetFeed()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(RssTests)).Location)}/Rss/Data/get_feed.json"));

            var feed = await PutioApiClient.Rss.GetFeed(45345);
            feed.ShouldNotBeNull();
            feed.Id.ShouldBe(45345);
            feed.Title.ShouldBe("Test RSS feed");
            feed.RssSourceUrl.ShouldBe("http://example.com/feed.rss");
            feed.ParentDirectoryId.ShouldBe(0);
            feed.DeleteOldFiles.ShouldBeFalse();
            feed.Keyword.ShouldBeNull();
            feed.Paused.ShouldBeFalse();
            feed.PausedAt.ShouldBeNull();
            feed.CreatedAt.ShouldNotBeNull();
            feed.UpdatedAt.ShouldNotBeNull();
            feed.StartedAt.ShouldNotBeNull();
        }
    }
}
