﻿namespace Sitecore.UniversalTrackerClient.Session
{
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.Response;
	using Sitecore.UniversalTrackerClient.UserRequest;

	public interface ISitecoreUTSessionActions
    {
        Task<UTResponse> TrackEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken));

        Task<UTResponse> TrackLocationEventAsync(ITrackLocationEventRequest request, CancellationToken cancelToken = default(CancellationToken));

        Task<UTResponse> TrackErrorEventAsync(ITrackErrorEventRequest request, CancellationToken cancelToken = default(CancellationToken));

        Task<UTResponse> TrackInteractionAsync(ITrackInteractionRequest request, CancellationToken cancelToken = default(CancellationToken));
    }
}