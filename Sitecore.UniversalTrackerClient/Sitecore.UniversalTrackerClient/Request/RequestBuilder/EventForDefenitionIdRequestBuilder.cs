﻿
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System.Collections.Generic;

    public class EventForDefenitionIdRequestBuilder<T> : AbstractEventRequestBuilder<T>
        where T : class, ITrackEventRequest
    {
        
        protected EventForDefenitionIdRequestBuilder()
        {

        }

        public EventForDefenitionIdRequestBuilder(string defenitionId)
        {
            ItemIdValidator.ValidateItemId(defenitionId, this.GetType().Name + ".defenitionId");
            this.DefinitionId(defenitionId);
        }

        public override T Build()
        {
            BaseValidator.CheckNullAndThrow(this.EventParametersAccumulator.DefinitionId, this.GetType().Name + ".utDefinitionId");
            BaseValidator.CheckNullAndThrow(this.EventParametersAccumulator.Timestamp, this.GetType().Name + ".utTimestamp");

            Dictionary<string, string> customParameters = null;

            if (this.FieldsRawValuesByName != null)
            {
                customParameters = new Dictionary<string, string>(this.FieldsRawValuesByName);
            }

            this.EventParametersAccumulator = new UTEvent(
                    this.EventParametersAccumulator.Timestamp,
                    customParameters,
                    this.EventParametersAccumulator.DefinitionId,
                    this.EventParametersAccumulator.ItemId,
                    this.EventParametersAccumulator.EngagementValue,
                    this.EventParametersAccumulator.ParentEventId,
                    this.EventParametersAccumulator.Text,
                    this.EventParametersAccumulator.Duration
                );

            TrackEventParameters result =
                new TrackEventParameters(null, this.EventParametersAccumulator);
            var convertedResult = result as T;
            return convertedResult;
        }
    }
}

