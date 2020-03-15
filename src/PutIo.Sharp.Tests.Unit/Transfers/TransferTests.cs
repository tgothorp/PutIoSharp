using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace PutIo.Sharp.Tests.Unit.Transfers
{
    public class TransferTests : BaseTest
    {
        [Fact]
        public async Task ListTransfers()
        {
            OverrideApiResponse(HttpStatusCode.OK, System.IO.File.ReadAllText($"{Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(TransferTests)).Location)}/Transfers/Data/get_list_transfers.json"));

            var listTransfers = await PutioApiClient.Transfers.ListTransfers();
            listTransfers.ShouldNotBeNull();
            listTransfers.Transfers.ShouldNotBeNull();
            listTransfers.Transfers.Count().ShouldBe(1);

            var transfer = listTransfers.Transfers.FirstOrDefault();
            transfer.ShouldNotBeNull();
            transfer.Availability.ShouldBe(100);
            transfer.CallbackUrl.ShouldBeNull();
            transfer.ClientIp.ShouldBeNull();
            transfer.CompletionPercent.ShouldBe(0);
            
            transfer.CreatedAt.Year.ShouldBe(2020);
            transfer.CreatedAt.Month.ShouldBe(03);
            transfer.CreatedAt.Day.ShouldBe(15);
            transfer.CreatedAt.Hour.ShouldBe(21);
            transfer.CreatedAt.Minute.ShouldBe(55);
            transfer.CreatedAt.Second.ShouldBe(16);
            
            transfer.CreatedTorrent.ShouldBeFalse();
            transfer.CurrentRatio.ShouldBe(0);
            transfer.DownSpeed.ShouldBe(1571115);
            transfer.DownloadId.ShouldBe(30636472);
            transfer.Downloaded.ShouldBe(132120576);
            transfer.ErrorMessage.ShouldBeNull();
            transfer.EstimatedTime.ShouldBe(21600);
            transfer.FileId.ShouldBeNull();
            transfer.FinishedAt.ShouldBeNull();
            transfer.Hash.ShouldBe("b626e6057167be562230c09e87205a085e5e90de");
            transfer.Id.ShouldBe(59289407);
            transfer.IsPrivate.ShouldBeFalse();
            transfer.Links.Length.ShouldBe(0);
            transfer.Name.ShouldBe("Jojo's Bizzare Adventure (Part IV) - Diamond Is Unbreakable");
            transfer.PeersConnected.ShouldBe(1);
            transfer.PeersGettingFromUs.ShouldBe(0);
            transfer.PeersSendingToUs.ShouldBe(1);
            transfer.PercentDone.ShouldBe(0);
            transfer.SaveParentId.ShouldBe(626119324);
            transfer.SecondsSeeding.ShouldBeNull();
            transfer.Simulated.ShouldBeFalse();
            transfer.Size.ShouldBe(35135736169);
            transfer.Source.ShouldBe("magnet:?REDACTED_TO_AVOID_COPYRIGHT_INFRINGEMENT");
            
            transfer.StartedAt.ShouldNotBeNull();
            transfer.StartedAt.Value.Year.ShouldBe(2020);
            transfer.StartedAt.Value.Month.ShouldBe(03);
            transfer.StartedAt.Value.Day.ShouldBe(15);
            transfer.StartedAt.Value.Hour.ShouldBe(21);
            transfer.StartedAt.Value.Minute.ShouldBe(55);
            transfer.StartedAt.Value.Second.ShouldBe(17);
            
            transfer.Status.ShouldBe("DOWNLOADING");
            transfer.StatusMessage.ShouldBe("↓ 1.5 M/s, ↑ 0.0 B/s | 1 peers, 0 leechers |\n        downloaded: 126.0 M / 32.7 G, uploaded: 0.0 B | availability: 100%");
            transfer.SubscriptionId.ShouldBeNull();
            transfer.TorrentLink.ShouldBe("https://api.put.io/v2/transfers/REDACTED");
            transfer.Tracker.ShouldBeNull();
            transfer.TrackerMessage.ShouldBeNull();
            transfer.Type.ShouldBe("TORRENT");
            transfer.UpSpeed.ShouldBe(0);
            transfer.Uploaded.ShouldBe(0);
        }
    }
}