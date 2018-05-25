﻿namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;

    public interface IInteractionParametersBuilder<T> : IBaseRequestParametersBuilder<T>
     where T : class
    {
        IInteractionParametersBuilder<T> AddEvents(Collection<IUTEvent> utEvents);
        IInteractionParametersBuilder<T> AddEvents(IUTEvent utEvent);

        IInteractionParametersBuilder<T> CampaignId(string campaignId);
        IInteractionParametersBuilder<T> ChannelId(string channelId);
        IInteractionParametersBuilder<T> EngagementValue(int engagementValue);
        IInteractionParametersBuilder<T> StartDateTime(DateTime startDateTime);
        IInteractionParametersBuilder<T> EndDateTime(DateTime endDateTime);
        IInteractionParametersBuilder<T> Initiator(InteractionInitiator initiator);
        IInteractionParametersBuilder<T> UserAgent(string userAgent);
        IInteractionParametersBuilder<T> VenueId(string venueId);
      
    }
}
