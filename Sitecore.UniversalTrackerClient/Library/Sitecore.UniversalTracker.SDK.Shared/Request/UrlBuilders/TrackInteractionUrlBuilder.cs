﻿namespace Sitecore.UniversalTrackerClient.Request.UrlBuilders
{
	using System;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public class TrackInteractionUrlBuilder<T> : AbstractTrackUrlBuilder<T>
		where T : class, ITrackInteractionRequest
    {
        public TrackInteractionUrlBuilder(IUTGrammar utGrammar) :
		base(utGrammar)
        {
        }

        protected override string GetEndpointForRequest()
        {
            return this.utGrammar.AnalyticsInteractionEndpoint;
        }


        protected override string GetSpecificPartForRequest(T request)
        {
            return ""; 
        }

        protected override void ValidateSpecificRequest(T request)
        {
            return;
        }
    }
}
