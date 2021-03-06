﻿using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTSearch : IUTEvent
    {
        /// <summary>
        /// Gets or sets the keywords for the search.
        /// </summary>
        /// <value>
        /// The keywords.
        /// </value>
        string Keywords { get; }

        IUTSearch DeepCopyUTSearch();
    }
   
}
