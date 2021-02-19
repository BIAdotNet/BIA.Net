// <copyright file="IViewQueryCustomizer.cs" company="Safran">
//     Copyright (c) Safran. All rights reserved.
// </copyright>

namespace Safran.BIATemplate.Domain.RepoContract
{
    using BIA.Net.Core.Domain.RepoContract.QueryCustomizer;
    using Safran.BIATemplate.Domain.ViewModule.Aggregate;

    /// <summary>
    /// interface use to customize the request on Member entity.
    /// </summary>
    public interface IViewQueryCustomizer : IQueryCustomizer<View>
    {
    }
}
