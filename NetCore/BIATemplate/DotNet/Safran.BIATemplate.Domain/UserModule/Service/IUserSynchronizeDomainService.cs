// <copyright file="IUserSynchronizeDomainService.cs" company="Safran">
//     Copyright (c) Safran. All rights reserved.
// </copyright>

namespace Safran.BIATemplate.Domain.UserModule.Service
{
    using System.Threading.Tasks;

    /// <summary>
    /// The interface defining the user synchronize domain service.
    /// </summary>
    public interface IUserSynchronizeDomainService
    {
        /// <summary>
        /// Synchronize the users in DB from the AD User group.
        /// </summary>
        /// <param name="fullSynchro">If true resynchronize existing user</param>
        /// <returns>The result of the task.</returns>
        Task SynchronizeFromADGroupAsync(bool fullSynchro = false);
    }
}